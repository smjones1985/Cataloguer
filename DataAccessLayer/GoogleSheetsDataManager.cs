using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;


namespace DataAccessLayer
{
    public class GoogleSheetsDataManager : IDataManager
    {
        public string SheetId { get; set; }
        private SheetsService service;
        private SheetsService Service
        {
            get
            {
                if (service == null)
                {
                    EstablishCredentials();
                }
                return service;
            }
            set
            {
                service = value;
            }
        }

        public GoogleSheetsDataManager()
        {
       
        }

        public IList<IList<object>> GetAllData() 
        {
            return GetSheetData(SheetId, "Sheet1!A:B");
          
        }

        public IList<object> GetDataById(string id)
        {
            var responseObjects =  GetSheetData(SheetId, "Sheet1!A:A");
            for (int i = 0; i < responseObjects.Count; i++)
            {
                if(responseObjects[0].ToString() == id)
                {
                    var searchById = GetSheetData(SheetId, String.Format("Sheet1!A{0}:B{0}", i));
                    if(searchById != null && searchById.Any())
                    {
                        return searchById.First();
                    }
                }
            }
            return null;
        }


        public void InsertData(string id, object catalogueItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(string id, object catalogueItem)
        {
            throw new NotImplementedException();
        }

        public object CreateTable(string name)
        {
            throw new NotImplementedException();
        }

        public void Configure(object configuration)
        {
            SheetId = configuration.GetType().GetProperty("SheetId").GetValue(configuration).ToString();
        }

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.Spreadsheets, SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";



        public void EstablishCredentials()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentialsUpdated.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            Service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


        }

        public bool InsertRecord(string spreadSheetId, string range, object insertObject)
        {
            string newId = Guid.NewGuid().ToString();
            IList<IList<Object>> valueData = new List<IList<object>>();
            valueData.Add(new List<object>() { newId, insertObject });

            ValueRange insertRecord = new ValueRange();
            insertRecord.Values = valueData;

            SpreadsheetsResource.ValuesResource.AppendRequest request =
                    Service.Spreadsheets.Values.Append(insertRecord, spreadSheetId, range);

            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;

            var response = request.Execute();

            if (response.Updates.UpdatedRows != null && response.Updates.UpdatedRows > 0)
            {
                return true;
            }
            return false;
        }

        public void UpdateRecord(string id, String spreadsheetId, String range, object newData)
        {
        }


        public IList<IList<Object>> GetSheetData(String spreadsheetId, String range)
        {
            // Define request parameters.
            //spreadsheetId = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms";
            //range = "Class Data!A2:E";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    Service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            return values;
        }

        public void CreateSheet(string sheetName)
        {
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.Properties = new SpreadsheetProperties()
            {
                Title = sheetName
            };
            SpreadsheetsResource.CreateRequest createRequest = Service.Spreadsheets.Create(spreadsheet);
            var response = createRequest.Execute();
            if (response == null || response.SpreadsheetId == null)
            {
                throw new Exception("SpreadSheet creation failed");
            }
        }
    }
}


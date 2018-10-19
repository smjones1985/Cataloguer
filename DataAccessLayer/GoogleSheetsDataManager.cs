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
using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class GoogleSheetsDataManager : GoogleSheets, IDataManager
    {
        public string SheetId { get; set; }
        public const string SHEET_NAME = "CatalogueData";
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

        public bool Readiness
        {
            get
            {
                var id = Properties.Settings.Default["SheetId"];
                return !(id == null || String.IsNullOrEmpty(id.ToString()));
            }
        }


        public GoogleSheetsDataManager()
        {
       
        }

        public IList<T> GetAllData<T>() 
        {
            return Convert<T>(GetSheetData(SheetId, "Sheet1!A:B"));
        }

        public T GetDataById<T>(string id)
        {
            var responseObjects =  GetSheetData(SheetId, "Sheet1!A:A");
            for (int i = 0; i < responseObjects.Count; i++)
            {
                if(responseObjects[0].ToString() == id)
                {
                    var searchById = GetSheetData(SheetId, String.Format("Sheet1!A{0}:B{0}", i));
                    if(searchById != null && searchById.Any())
                    {
                        return Convert<T>(searchById.First());
                    }
                }
            }
            return default(T);
        }


        public T InsertData<T>(string id, T catalogueItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(string id, object catalogueItem)
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

        public void Configure()
        {
            var id = Properties.Settings.Default["SheetId"];
            if (id == null || String.IsNullOrEmpty(id.ToString()))
            {
                id = CreateSheet(SHEET_NAME);
                if(String.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception("Unable to create data sheet");
                }
                Properties.Settings.Default["SheetId"] = id.ToString();
                Properties.Settings.Default.Save();
            }
            SheetId = id.ToString();
        }

        public int GetRecordCount()
        {
            return GetSheetData(SheetId, "Sheet1!A").Count;
        }

        private List<T> Convert<T>(IList<IList<object>> sheetData)
        {
            List<T> returnList = new List<T>();
            foreach (var item in sheetData)
            {
                returnList.Add(JsonConvert.DeserializeObject<T>(item.ElementAt(1).ToString()));
            }
            return returnList;
        }

        private T Convert<T>(IList<object> sheetItem)
        {
            return JsonConvert.DeserializeObject<T>(sheetItem.ElementAt(1).ToString());
        }
    }
}


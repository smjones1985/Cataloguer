using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataManager : IDataManager
    {
        public string SheetId { get; set; }
        public  IGoogleSheetsManager GoogleSheetsManager { get; set; }

       
        public DataManager(IGoogleSheetsManager googleSheetsManager)
        {
            this.GoogleSheetsManager = googleSheetsManager;
        }

        public IList<IList<object>> GetAllData()
        {
            return GoogleSheetsManager.GetData(SheetId, "Sheet1!A:B");
        }

        public IList<object> GetDataById(string id)
        {
            var responseObjects =  GoogleSheetsManager.GetData(SheetId, "Sheet1!A:A");
            for (int i = 0; i < responseObjects.Count; i++)
            {
                if(responseObjects[0].ToString() == id)
                {
                    var searchById = GoogleSheetsManager.GetData(SheetId, String.Format("Sheet1!A{0}:B{0}", i));
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

        public void Configure(object configuration)
        {
            SheetId = configuration.GetType().GetProperty("SheetId").GetValue(configuration).ToString();
        }
    }
}

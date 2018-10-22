using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public class CatalogueActions : ICatalogueActions
    {
        private IDataManager DataManager { get; set; }

        public CatalogueActions(IDataManager dataManager)
        {
            DataManager = dataManager;
        }

        public void ConfigureApplication()
        {
            DataManager.Configure();
        }

        private List<CatalogueRecord> Convert(IList<IList<object>> sheetData)
        {
            List<CatalogueRecord> returnList = new List<CatalogueRecord>();
            foreach (var item in sheetData)
            {
                returnList.Add(JsonConvert.DeserializeObject<CatalogueRecord>(item.ElementAt(1).ToString()));
            }
            return returnList;
        }

        public bool IsApplicationReady()
        {
            return DataManager.Readiness;
        }

        public void AddRecord(string description)
        {
            CatalogueRecord catalogueRecord = new CatalogueRecord() { Id = Guid.NewGuid(), Description = description};
            DataManager.InsertData(catalogueRecord.Id.ToString(), catalogueRecord);
        }
        //add a method that calls the datamanager to get all records. 
        public void CollectRecords()
        {
            DataManager.GetAllData();

        }
        //add methods to add and delete records using the data manager
        // Don't we already have that on line 40?

        public void DeleteRecord()
        {

        }
    }
}

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

        public bool IsApplicationReady()
        {
            return DataManager.Readiness;
        }

        public CatalogueRecord AddRecord(string description)
        {
            CatalogueRecord catalogueRecord = new CatalogueRecord() { Id = Guid.NewGuid(), Description = description};
            return DataManager.InsertData(catalogueRecord.Id.ToString(), catalogueRecord);
        }

        public CatalogueRecord GetRecordById(string id)
        {
            return DataManager.GetDataById<CatalogueRecord>(id);
        }

        //add a method that calls the datamanager to get all records. 
        public List<CatalogueRecord> CollectRecords()
        {

            return DataManager.GetAllData<CatalogueRecord>();
            
        }
        //add methods to add and delete records using the data manager
        // Something like this?
        public void DeleteRecord(string id)
        {
            DataManager.DeleteData(id);
        }

        public List<CatalogueRecord> GetRecordsByCategory(Categories category)
        {
            var catalogeRecords = CollectRecords();
            List<CatalogueRecord> MatchedRecords = new List<CatalogueRecord>();
            foreach (CatalogueRecord record in catalogeRecords)
            {
                if ( record.Category == category)
                {
                    MatchedRecords.Add(record);
                }
            }

            return MatchedRecords;
        }
    }
}

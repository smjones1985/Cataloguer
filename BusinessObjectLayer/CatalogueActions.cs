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
            throw new NotImplementedException();
        }

        public CatalogueRecord GetRecordById(string id)
        {
            return DataManager.GetDataById<CatalogueRecord>(id);
        }

        //add a method that calls the datamanager to get all records. 
        public IList<CatalogueRecord> CollectRecords()
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
            var catalogueRecords = CollectRecords();
            List<CatalogueRecord> MatchedRecords = new List<CatalogueRecord>();
            foreach (CatalogueRecord record in catalogueRecords)
            {
                if ( record.Category == category)
                {
                    MatchedRecords.Add(record);
                }
            }
            return MatchedRecords;
        }

        public CatalogueRecord AddRecord(string description, Categories category)
        {
            CatalogueRecord catalogueRecord = new CatalogueRecord() { Id = Guid.NewGuid(), Description = description, Category = category };
            return DataManager.InsertData(catalogueRecord.Id.ToString(), catalogueRecord);
        }
    }
}

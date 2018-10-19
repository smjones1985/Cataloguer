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
        //public void CollectRecords()
        //{
        //    DataManager.GetAllData();
            
        //}
        //add methods to add and delete records using the data manager
        // Don't we already have that on line 40?

        //public void DeleteRecord()
        //{
            
        //}
    }
}

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
        public IDataManager DataManager { get; set; }

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
    }
}

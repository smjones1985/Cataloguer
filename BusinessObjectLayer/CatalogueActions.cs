using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public class CatalogueActions
    {
        public IDataManager DataManager { get; set; }

        public ISettingsManager SettingsManager { get; set; }

        public Settings ConfigureApplication()
        {
            Settings currentSettings;
            SettingsManager = new SettingsManager();
            //SettingsObj = SettingsManager.Read();
            // Check if settings object is null
            //if not null, assign to current settings and return
            // if true call settings.manager.create

            // Call read again

            // Call the DataAccessLayer to create a sheet

            //store sheet name inside of 

            throw new NotImplementedException();
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

    }
}

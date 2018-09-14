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

        public void ConfigureApplication()
        {
            var id = Properties.Settings.Default["SheetId"];

            // Check if settings object is null
            //if null or empty, 
            // Call the DataAccessLayer to create a sheet
            // store sheet id in settings
            //  Properties.Settings.Default["SheetId"] = x
            //  then save change like so:
            //  Properties.Settings.Default.Save();

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

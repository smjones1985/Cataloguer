using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public class Settings
    {
        public void ConfigureApplications()
        {
            

            SettingsManager settingsManager = new SettingsManager();
            SettingsObj = settingsManager.Read();
            // Check if settings object is null

            // if true call settings.manager.create

            // Call read again

            // Call the DataAccessLayer to create a sheet
        }


    }
}

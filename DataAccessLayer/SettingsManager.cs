using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class SettingsManager : ISettingsManager
    {
        public bool Save(object settings)
        {
            //serialize puts the object in to a string that is in JSON format. Google JSON for more info and examples
            var stringOfObject = JsonConvert.SerializeObject(settings);

            //use File static class to check if file exists. If it does not, create it.
            //a lot of what I do all the time is research. Get ready to be morefamiliar with StackOverflow

            return false;//this should eventually return true if no exceptions were throw and everything was saved correctly
        }

        public object Read()
        {

            //use File static class to read the file
            throw new NotImplementedException();
        }
    }
}

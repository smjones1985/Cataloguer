using BusinessObjectLayer;
using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloguerTest
{
    public class TestDataManager : IDataManager
    {
        public bool Readiness => throw new NotImplementedException();
        private IList<IList<object>> testList;

        private IList<IList<object>> TestList
        {
            get
            {
                if(testList == null)
                {
                    var testId = Guid.Parse("{6cd6f2d8-0111-4c14-b2bd-6868b5122fba}");
                    var testDescription = "TestDescription1";
                    object testObj = new object();
                    CatalogueRecord catalogueRecord = new CatalogueRecord() { Id = testId, Description = testDescription };
                    testList = new List<IList<object>>();
                    List<object> dataMembers = new List<object>() { testId, JsonConvert.SerializeObject(catalogueRecord) };
                    testList.Add(dataMembers);
                }
                return testList;
            }
        }

        public void Configure()
        {
            
        }

        public IList<T> GetAllData<T>()
        {
            throw new NotImplementedException();
        }

        public T GetDataById<T>(string id)
        {
            foreach (var item in TestList)
            {
                string searchId = item[0].ToString();
                if(id == searchId)
                {
                    return Convert<T>(item);
                }
            }
            return default(T);
        }

        public T InsertData<T>(string id, T catalogueItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(string id, object catalogueItem)
        {
            throw new NotImplementedException();
        }

        public int GetRecordCount()
        {
            throw new NotImplementedException();
        }

        private List<T> Convert<T>(IList<IList<object>> sheetData)
        {
            List<T> returnList = new List<T>();
            foreach (var item in sheetData)
            {
                returnList.Add(JsonConvert.DeserializeObject<T>(item.ElementAt(1).ToString()));
            }
            return returnList;
        }

        private T Convert<T>(IList<object> sheetItem)
        {
            return JsonConvert.DeserializeObject<T>(sheetItem.ElementAt(1).ToString());
        }
    }
}

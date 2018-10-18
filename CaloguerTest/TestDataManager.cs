using BusinessObjectLayer;
using DataAccessLayer;
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
                    var testId = Guid.NewGuid();
                    var testDescription = "TestDescription1";
                    testList = new List<IList<object>>
                    {
                        new List<object>() { testId, testDescription }
                    };
                }
                return testList;
            }
        }

        public void Configure()
        {
            
        }

        public IList<IList<object>> GetAllData()
        {
            throw new NotImplementedException();
        }

        public IList<object> GetDataById(string id)
        {
            throw new NotImplementedException();
        }

        public void InsertData(string id, object catalogueItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(string id, object catalogueItem)
        {
            throw new NotImplementedException();
        }
    }
}

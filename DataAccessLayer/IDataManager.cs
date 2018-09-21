
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IDataManager
    {
        bool Readiness { get;}

        void InsertData(string id, object catalogueItem);

        IList<object> GetDataById(string id);

        void UpdateData(string id, object catalogueItem);

        IList<IList<object>> GetAllData();

        void Configure();
    }
}
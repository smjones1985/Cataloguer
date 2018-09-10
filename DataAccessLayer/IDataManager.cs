
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IDataManager
    {
        void Configure(object configuration);

        void InsertData(string id, object catalogueItem);

        IList<object> GetDataById(string id);

        void UpdateData(string id, object catalogueItem);

        IList<IList<object>> GetAllData();

    }
}
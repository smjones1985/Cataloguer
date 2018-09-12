
using BusinessObjectLayer;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IDataManager
    {
        void Configure(object configuration);

        void InsertData(string id, object catalogueItem);

        CatalogueRecord GetDataById(string id);

        void UpdateData(string id, object catalogueItem);

        IList<CatalogueRecord> GetAllData();

    }
}
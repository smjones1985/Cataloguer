using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessObjectLayer
{
    public interface ICatalogueActions
    {
        void ConfigureApplication();
        bool IsApplicationReady();
        CatalogueRecord AddRecord(string description, Categories category);
        CatalogueRecord GetRecordById(string id);
        void DeleteRecord(string id);
        
        List<CatalogueRecord> GetRecordsByCategory(Categories category);
    }
}
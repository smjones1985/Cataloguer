using DataAccessLayer;

namespace BusinessObjectLayer
{
    public interface ICatalogueActions
    {
        void ConfigureApplication();
        bool IsApplicationReady();
        void AddRecord(string description);
    }
}
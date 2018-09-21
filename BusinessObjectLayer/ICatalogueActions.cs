using DataAccessLayer;

namespace BusinessObjectLayer
{
    public interface ICatalogueActions
    {
        IDataManager DataManager { get; set; }

        void ConfigureApplication();
        bool IsApplicationReady();
    }
}
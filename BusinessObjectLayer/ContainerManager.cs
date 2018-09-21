using DataAccessLayer;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public static class ContainerManager
    {
        static Container container;

        public static void IntializeContainer()
        {
            if (container == null)
            {
                // 1. Create a new Simple Injector container
                container = new Container();

                // 2. Configure the container (register)
                container.Register<ICatalogueActions, CatalogueActions>();
                container.Register<IDataManager, GoogleSheetsDataManager>();
                // 3. Verify your configuration
                container.Verify();
            }
        }

        public static T ProvideImplementation<T>(T catalogueActions)
        {
            return (T) container.GetInstance(serviceType: typeof(CatalogueActions));
        }
    }
}

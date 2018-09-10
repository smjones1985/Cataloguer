using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class ContainerManager
    {
        static readonly Container container;

        static ContainerManager()
        {
            // 1. Create a new Simple Injector container
            container = new Container();

            // 2. Configure the container (register)
            container.Register<IDataManager, DataManager>();
            container.Register<IGoogleSheetsManager, GoogleSheetsManager>();

            // 3. Verify your configuration
            container.Verify();
        }
    }
}

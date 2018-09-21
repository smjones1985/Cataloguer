using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjectLayer;
using DataAccessLayer;

namespace Cataloguer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICatalogueActions CatalogueActions { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BusinessObjectLayer.ContainerManager.IntializeContainer();
            ReadyCheck();
        }

        private void ReadyCheck()
        {
            if (CatalogueActions == null)
            {
                CatalogueActions = BusinessObjectLayer.ContainerManager.ProvideImplementation(CatalogueActions);
            }

            if (!CatalogueActions.IsApplicationReady())
            {
                var result = MessageBox.Show("In order to run this application, you need to connect\n" +
                    "to google to allow you to create a sheet. Do you want to continue?", "Setup", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Cancel)
                {
                    this.Close();
                    return;
                }
                CatalogueActions.ConfigureApplication();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

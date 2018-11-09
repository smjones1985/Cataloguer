using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using BusinessObjectLayer;


namespace Cataloguer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Categories Category;

        public ICatalogueActions CatalogueActions { get; set; }

        public ObservableCollection<CatalogueRecord> CatalogueRecords  { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            OptionalWindow optionalWindow = new OptionalWindow();
            optionalWindow.Show();
            this.Close();
        }

        public MainWindow(Categories category)
        {
            InitializeComponent();
            this.Category = category;
            BusinessObjectLayer.ContainerManager.IntializeContainer();
            ReadyCheck();
            if (CatalogueRecords == null)
            {
                CatalogueRecords = new ObservableCollection<CatalogueRecord>();
            }
            dataGrideForCatalogue.ItemsSource = CatalogueRecords;
            var records = CatalogueActions.GetRecordsByCategory(category);
            records.ForEach(record => CatalogueRecords.Add(record));
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

        private void addRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(itemEntryText.Text))
            {
                CatalogueRecords.Add(new CatalogueRecord() { Description = itemEntryText.Text, Id = Guid.NewGuid(), Category = this.Category});
            }
        }

        //private void DeleteRecordButton_Click(object sender, RoutedEvent e)
        //{
        //    if (!String.IsNullOrEmpty(itemEntryText.Text))
        //    {
        //        CatalogueRecords.
        //    }
        //}
    }
}

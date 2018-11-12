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
using System.Windows.Shapes;
using BusinessObjectLayer;

namespace Cataloguer
{
    /// <summary>
    /// Interaction logic for OptionalWindow.xaml
    /// </summary>
    public partial class OptionalWindow : Window
    {
        public OptionalWindow()
        {
            InitializeComponent();
        }

        private void Button_Games_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindowObj = new MainWindow(Categories.Games);
            mainWindowObj.Show();
            
            this.Close();

        }

        private void Button_Music_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindowObj = new MainWindow(Categories.Music);
            mainWindowObj.Show();

            this.Close();
        }

        private void Button_Movies_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindowObj = new MainWindow(Categories.Movies);
            mainWindowObj.Show();

            this.Close();
        }

        private void Button_Books_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindowObj = new MainWindow(Categories.Books);
            mainWindowObj.Show();

            this.Close();
        }
    }
}

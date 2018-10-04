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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        
        public Page1(string text)
        {
            InitializeComponent();
            if(text != null)
            {
                main_Title.Text = "Hi, "+text;
            }
        }

        private void Feeling_tracker_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Feeling());
        }

        private void Exercise_tracker_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sleep_Tracker_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Food_Tracker_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

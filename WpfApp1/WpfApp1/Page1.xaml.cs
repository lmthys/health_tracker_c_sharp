using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
            Fill();
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
            this.NavigationService.Navigate(new Sleeping());

        }

        private void Food_Tracker_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           


        }
        private void Fill()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Verion=3;");
            m_dbConnection.Open();

            DataTable dataTable;

            string sql = "select * from feeling_table;";
            SQLiteCommand c = new SQLiteCommand(sql, m_dbConnection);

            using (SQLiteDataAdapter dataApapter = new SQLiteDataAdapter(c))
            {
                dataTable = new DataTable();
                dataApapter.Fill(dataTable);
                this.Overall_data.ItemsSource = dataTable.AsDataView();
            }

            sql = "select * from sleeping_table;";
            c = new SQLiteCommand(sql, m_dbConnection);

            using (SQLiteDataAdapter dataApapter = new SQLiteDataAdapter(c))
            {
                dataApapter.Fill(dataTable);
                this.Overall_data.ItemsSource = dataTable.AsDataView();
            }
        }
    }
}

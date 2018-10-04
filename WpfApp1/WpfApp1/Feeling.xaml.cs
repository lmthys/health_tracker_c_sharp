using System;
using System.Collections.Generic;
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
    /// Interaction logic for Feeling.xaml
    /// </summary>
    public partial class Feeling : Page
    {
        public Feeling()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // temp
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Verion=3;");
            m_dbConnection.Open();
            string sql = "create table feeling_table (date varchar(20), score int)";
            SQLiteCommand c = new SQLiteCommand(sql, m_dbConnection);
            c.ExecuteNonQuery();
            // staying forever
            string sql_1 = "insert into feeling_table (date, score) values (" + DateTime.Now.ToString() + "," + slider.Value + ")";
            c = new SQLiteCommand(sql_1, m_dbConnection);
            c.ExecuteNonQuery();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

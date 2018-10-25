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
    /// Interaction logic for Sleeping.xaml
    /// </summary>
    public partial class Sleeping : Page
    {
        public Sleeping()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // temp
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Verion=3;");
            m_dbConnection.Open();
            // staying forever
            string sql_1 = "insert into sleeping_table (date, hours_slept) values (" + "\"" + DateTime.Now.ToString() + "\"" + "," + Hours_Slept.Text + ");";
            SQLiteCommand c = new SQLiteCommand(sql_1, m_dbConnection);
            c.ExecuteNonQuery();
            m_dbConnection.Close();

            Page1 p = new Page1("Larisa");
            this.NavigationService.Navigate(p);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

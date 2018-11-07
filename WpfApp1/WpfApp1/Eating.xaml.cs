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
    /// Interaction logic for Eating.xaml
    /// </summary>
    public partial class Eating : Page
    {
        public Eating()
        {
            InitializeComponent();
        }


        private void Calories_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Submit_Butt_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Verion=3;");
            m_dbConnection.Open();
            // staying forever
            string sql_1 = "insert into eating_table (date, meal, calories_eaten) values (" + "\"" + DateTime.Now.ToString() + "\"" + "," + "\"" + MealChooser.Text + "\"" + "," + Calories.Text + ");";
            SQLiteCommand c = new SQLiteCommand(sql_1, m_dbConnection);
            c.ExecuteNonQuery();
            m_dbConnection.Close();

            Page1 p = new Page1("Larisa");
            this.NavigationService.Navigate(p);
        }
    }
}

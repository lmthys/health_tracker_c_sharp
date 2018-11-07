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
    /// Interaction logic for Exercise.xaml
    /// </summary>
    public partial class Exercise: Page
    {
        public Exercise()
        {
            InitializeComponent();
        }

        private void WorkoutMinutes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Submit_Butt_Click(object sender, RoutedEventArgs e)
        {
            // temp
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Verion=3;");
            m_dbConnection.Open();
            // staying forever
            string sql_1 = "insert into exercise_table (date, hours_exercise) values (" + "\"" + DateTime.Now.ToString() + "\"" + "," + WorkoutMinutes.Text + ");";
            SQLiteCommand c = new SQLiteCommand(sql_1, m_dbConnection);
            c.ExecuteNonQuery();
            m_dbConnection.Close();

            Page1 p = new Page1("Larisa");
            this.NavigationService.Navigate(p);
        }
    }
}

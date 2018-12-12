using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using OxyPlot;
using OxyPlot.Axes;
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
using System;
using System.Diagnostics;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public ChartValues<ObservablePoint> Feeling { get; set; }
        public ChartValues<ObservablePoint> Sleeping { get; set; }
        public ChartValues<ObservablePoint> Eating { get; set; }
        public ChartValues<ObservablePoint> Exercise { get; set; }

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
            this.NavigationService.Navigate(new Exercise());
        }

        private void Sleep_Tracker_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Sleeping());

        }

        private void Food_Tracker_Click(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new Eating()); 
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           


        }
        private void Fill()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Verion=3;");
            m_dbConnection.Open();

            //List<ObservablePoint> feeling_values = new List<double>();
            Feeling = new ChartValues<ObservablePoint>();
            Sleeping = new ChartValues<ObservablePoint>();
            Eating = new ChartValues<ObservablePoint>();
            Exercise = new ChartValues<ObservablePoint>();


            string sql = "select * from feeling_table;";
            SQLiteCommand c = new SQLiteCommand(sql, m_dbConnection);

            using (SQLiteDataReader dataReader = c.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    int x = dataReader.GetInt32(0);
                    float y = dataReader.GetFloat(2);
                    Feeling.Add(new ObservablePoint(Convert.ToDouble(x), Convert.ToDouble(y)));
                }
                //feeling_values.Add(Convert.ToDouble(dataReader["feeling_score"]));
            }

            List<double> sleeping_values = new List<double>();

            sql = "select * from sleeping_table;";
            c = new SQLiteCommand(sql, m_dbConnection);

            using (SQLiteDataReader dataReader = c.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    int x = dataReader.GetInt32(0);
                    float y = dataReader.GetFloat(2);
                    Sleeping.Add(new ObservablePoint(Convert.ToDouble(x), Convert.ToDouble(y)));
                }
                //sleeping_values.Add(Convert.ToDouble(dataReader["hours_slept"]));
            }

            List<double> exercise_values = new List<double>();

            sql = "select * from exercise_table;";
            c = new SQLiteCommand(sql, m_dbConnection);

            using (SQLiteDataReader dataReader = c.ExecuteReader())
            {
                while(dataReader.Read())
                {
                    int x = dataReader.GetInt32(0);
                    float y = dataReader.GetFloat(2);
                    Exercise.Add(new ObservablePoint(Convert.ToDouble(x), Convert.ToDouble(y)));
                }
                //exercise_values.Add(Convert.ToDouble(dataReader["hours_exercise"]));
            }

            List<double> eating_values = new List<double>();

            sql = "select * from eating_table;";
            c = new SQLiteCommand(sql, m_dbConnection);

            using (SQLiteDataReader dataReader = c.ExecuteReader())
            {
                while(dataReader.Read())
                {
                    int x = dataReader.GetInt32(0);
                    float y = (dataReader.GetFloat(3)/100);
                    Eating.Add(new ObservablePoint(Convert.ToDouble(x), Convert.ToDouble(y)));
                }
                //eating_values.Add(Convert.ToDouble(dataReader["calories_eaten"]));
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Feeling Values",
                    Values = Feeling
                },
                new LineSeries
                {
                    Title = "Hours of Sleep",
                    Values = Sleeping
                },
                new LineSeries
                {
                    Title = "Hours of Exercise",
                    Values = Exercise
                },
                new LineSeries
                {
                    Title = "Number of Calories Eaten (Scaled)",
                    Values = Eating
                }
            };
            


            DataContext = this; 
        }

        private void Output_Report_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists(@" ~/Documents/490/health_tracker_c_sharp/health.pdf"))
            {
                File.Delete(@" ~/Documents/490/health_tracker_c_sharp/health.pdf");
            }
            string output = "python makePrintOut.py";
            ProcessStartInfo proc0 = new ProcessStartInfo();
            proc0.FileName = "C:\\Users\\lmand\\AppData\\Local\\Programs\\Python\\Python36-32\\python.exe";
            proc0.Arguments = "makePrintOut.py";
            proc0.UseShellExecute = false;
            proc0.CreateNoWindow = true;
            proc0.RedirectStandardOutput = true;
            proc0.RedirectStandardError = true;
            using (Process process = Process.Start(proc0))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    
                }
            }
        }
    }

}

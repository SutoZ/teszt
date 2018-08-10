using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
using teszt.Database;
using teszt.Factory;

namespace teszt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public enum DatabaseType
    {
        SQLServer = 1,
        XML = 2,
        OleDb = 3
    };

    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private string color;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            color = "";
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            color = Constants.RED;
        }

        private void yellow_color_Checked(object sender, RoutedEventArgs e)
        {
            color = Constants.YELLOW;
        }

        private void GetCar_Click(object sender, RoutedEventArgs e)
        {
            IDataAccess database;
            DatabaseType dbType = DatabaseType.SQLServer;
            database = DatabaseFactory.CreateDatabase(dbType);

            Worker worker = new Worker(database);

            if (String.IsNullOrWhiteSpace(color))            
                throw new ArgumentException("Nem választottál színt!");
            
            string result = worker.Start(color);

            if (result == Constants.RED)
                MessageBox.Show(Constants.Red_car_message);

            else MessageBox.Show(Constants.Yellow_truck_message);
        }

        
    }
}

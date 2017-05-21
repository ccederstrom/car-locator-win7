using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;

namespace Car_Locator.Database
{
    public class Data_Context : DataContext
    {
        // Specify the connection string as a static, used in main page and app.xaml.
        public static string DBConnectionString = "Data Source=isostore:/Database.sdf";

        // Pass the connection string to the base class.
        public Data_Context(string connectionString)
            : base(connectionString)
        { }

        // Specify a single table for the to-do items.
        public Table<Location_Table> Location_Table;
    }

}

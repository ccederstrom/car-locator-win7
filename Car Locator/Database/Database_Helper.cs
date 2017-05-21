using System;
using System.Net;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Car_Locator.Database
{
    public class Database_Helper
    {
        // Data context for the local database
        private static Data_Context DB;

        // Connect to the database and instantiate data context.
        public static void connect()
        {
            DB = new Data_Context(Data_Context.DBConnectionString);
        }

        public static ObservableCollection<Location_Table> getAllRows()
        {
            var InDB = from Location_Table rows in DB.Location_Table select rows;
            return (new ObservableCollection<Location_Table>(InDB));
        }
        public static ObservableCollection<Location_Table> getAllRow_ID_Desc()
        {
            var InDB = from Location_Table rows in DB.Location_Table orderby rows.Id descending select rows;
            return (new ObservableCollection<Location_Table>(InDB));
        }
        public static ObservableCollection<Location_Table> getRowsbyTitle(String title)
        {
            var edit_query = from Location_Table rows in DB.Location_Table where rows.Title == title select rows;
            return (new ObservableCollection<Location_Table>(edit_query));
        }
        public static void deleteRow(Location_Table temp)
        {
            DB.Location_Table.DeleteOnSubmit(temp);
            DB.SubmitChanges();
        }
        public static void insertRow(Location_Table temp)
        {
            DB.Location_Table.InsertOnSubmit(temp);
            DB.SubmitChanges();
        }
        public static Location_Table getUsingRow()
        {
            var InDB = from Location_Table rows in DB.Location_Table where rows.Using==true select rows;
            if (new ObservableCollection<Location_Table>(InDB) == null || new ObservableCollection<Location_Table>(InDB).Count==0) return null;
            if ((new ObservableCollection<Location_Table>(InDB))[0] == null) return null;
            else return ((new ObservableCollection<Location_Table>(InDB))[0]);
        }
        public static void removeUsing()
        {
            var InDB = from Location_Table rows in DB.Location_Table where rows.Using == true select rows;
            foreach (var detail in InDB)
            {
                Debug.WriteLine("usingrow is " + detail.getString());
                DB.Location_Table.DeleteOnSubmit(detail);
                try
                {
                    DB.SubmitChanges();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }

           

            foreach (var a in getAllRows())
            {
                Debug.WriteLine("----------Row is "+a.getString());
            }

            foreach (var row in InDB)
            {
                row.Using = false;
                Debug.WriteLine("row changed is " + row.getString() + " using: "+row.Using);
                DB.Location_Table.InsertOnSubmit(row);
            }
            try
            {
                DB.SubmitChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}

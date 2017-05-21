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
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace Car_Locator.Database
{
    [Table]
    public class Location_Table : INotifyPropertyChanged, INotifyPropertyChanging
    {
        // Define ID: private field, public property and database column.
        private int _Id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    NotifyPropertyChanging("Id");
                    _Id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }
        // Define item name: private field, public property and database column.
        private string _Title;

        [Column]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title != value)
                {
                    NotifyPropertyChanging("Title");
                    _Title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }
        
        // Define item name: private field, public property and database column.
        private Double _altitude;

        [Column]
        public Double altitude
        {
            get
            {
                return _altitude;
            }
            set
            {
                if (_altitude != value)
                {
                    NotifyPropertyChanging("altitude");
                    _altitude = value;
                    NotifyPropertyChanged("altitude");
                }
            }
        }
        

        // Define item name: private field, public property and database column.
        private double _longitude;

        [Column]
        public double longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (_longitude != value)
                {
                    NotifyPropertyChanging("longitude");
                    _longitude = value;
                    NotifyPropertyChanged("longitude");
                }
            }
        }

        // Define item name: private field, public property and database column.
        private double _latitude;

        [Column]
        public double latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (_latitude != value)
                {
                    NotifyPropertyChanging("latitude");
                    _latitude = value;
                    NotifyPropertyChanged("latitude");
                }
            }
        }

        // Define item name: private field, public property and database column.
        private double _course;

        [Column]
        public double course
        {
            get
            {
                return _course;
            }
            set
            {
                if (_course != value)
                {
                    NotifyPropertyChanging("course");
                    _course = value;
                    NotifyPropertyChanged("course");
                }
            }
        }

        // Define item name: private field, public property and database column.
        private Boolean _Using;

        [Column]
        public Boolean Using
        {
            get
            {
                return _Using;
            }
            set
            {
                if (_Using != value)
                {
                    NotifyPropertyChanging("Using");
                    _Using = value;
                    NotifyPropertyChanged("Using");
                }
            }
        }

        // Define item name: private field, public property and database column.
        private string _Note;

        [Column]
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                if (_Note != value)
                {
                    NotifyPropertyChanging("Note");
                    _Note = value;
                    NotifyPropertyChanged("Note");
                }
            }
        }

        public String getString()
        {
            String a = "";
            a += "ID: " + Id;
            a += ";title: " + Title;
            a += ";alt: " + altitude;
            a += ";long: " + longitude;
            a += ";lat: " + latitude;
            a += ";Using: " + Using;
            return a;
        }
       

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify the data context that a data context property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
       
    }
}

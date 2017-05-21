using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using GART.Controls;
using System.Device.Location;
using GART.Data;
using System.Collections.ObjectModel;
using Car_Locator.Database;
using Car_Locator.model;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using Information_Page.AppInfo;

namespace Car_Locator
{
    public partial class Map : PhoneApplicationPage
    {
        IsolatedStorageSettings isolatedStorage;
        public Map()
        {
            InitializeComponent();
            try
            {
                // Get the settings for this application.
                isolatedStorage = IsolatedStorageSettings.ApplicationSettings;
            }
            catch (Exception err)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + err.ToString());
            }
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                ARDisplay.StopServices();
            }
            catch (Exception eb)
            {
                Debug.WriteLine("Exception is " + eb.Message);
            }
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Start AR services
            Debug.WriteLine("Start AR services");
            Debug.WriteLine("isolatedStorage(long) is " + (String)(isolatedStorage["long"]));
            Debug.WriteLine("RunningServices is "+ARDisplay.ServicesRunning);
            if(!ARDisplay.ServicesRunning) ARDisplay.StartServices();
            HeadingIndicator.RotationSource = RotationSource.AttitudeHeading;
            //OverheadMap.RotationSource = RotationSource.AttitudeHeading;
            if (isolatedStorage.Contains("long") && !((String)(isolatedStorage["long"])).Equals(""))
            {
                GeoCoordinate spaceNeedleLocation = new GeoCoordinate(Double.Parse((String)(isolatedStorage["lat"])), Double.Parse((String)(isolatedStorage["long"])));
                ////GeoCoordinate spaceNeedleLocation = new GeoCoordinate(34.062201,-118.363947);
                //AddLabel(spaceNeedleLocation, "Car Location");

                ObservableCollection<ARItem> items = new ObservableCollection<ARItem>();
                RestaurantItem ri = new RestaurantItem()
                {
                    Cuisine = "is here",
                    GeoLocation = spaceNeedleLocation,
                    Name = "Your car is here",
                    Rating = 9,
                };
                items.Add(ri);
                ARDisplay.ARItems = items;
                Debug.WriteLine("Added items to View");
            }
            base.OnNavigatedTo(e);
        }
        private void AddLabel(GeoCoordinate location, string label)
        {
            // We'll use the specified text for the content and we'll let 
            // the system automatically project the item into world space
            // for us based on the Geo location.
            ARItem item = new ARItem()
            {
                Content = label,
                GeoLocation = location,
            };
            ARDisplay.ARItems.Add(item);
        }
    }
}
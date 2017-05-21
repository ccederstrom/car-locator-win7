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
using System.Device.Location;
using System.Diagnostics;
using Car_Locator.Database;
using Microsoft.Phone.Tasks;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using Information_Page.AppInfo;
using System.Windows.Media.Imaging;
namespace Car_Locator
{
    public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher;
        IsolatedStorageSettings isolatedStorage;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            try
            {
                // Get the settings for this application.
                isolatedStorage = IsolatedStorageSettings.ApplicationSettings;
                Uri uri = new Uri("http://appserver.m.bing.net/BackgroundImageService/TodayImageService.svc/GetTodayImage?dateOffset=0&urlEncodeHeaders=true&osName=wince&osVersion=7.10&orientation=480x800&deviceName=WP7Device&mkt=en-US&AppId=1", UriKind.Absolute);
                BackgroundImage.ImageSource = new BitmapImage(uri);
            }
            catch (Exception err)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + err.ToString());
            }
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            Debug.WriteLine("isPaidVersion: " + App.isPaidVersion);
            //if (App.isPaidVersion == true)
            //{
            //    adControl.Visibility = System.Windows.Visibility.Collapsed;

            //}
            //else
            //{
            //    AdvertiseInfo adInfo = new AdvertiseInfo();
            //    adControl = new Microsoft.Advertising.Mobile.UI.AdControl(adInfo.ApplicationID, adInfo.AdUnitID, true);
            //}



            if (App.IsTrial == false)
            {
                adControl.Visibility = System.Windows.Visibility.Collapsed;
                adControl.IsEnabled = false;
            }
            else
            {
                //AdvertiseInfo adInfo = new AdvertiseInfo();
                //adControl = new Microsoft.Advertising.Mobile.UI.AdControl(adInfo.ApplicationID, adInfo.AdUnitID, true);
                adControl.Visibility = System.Windows.Visibility.Visible;
            }



            if (!isolatedStorage.Contains("long") || ((String)(isolatedStorage["long"])).Equals(""))
            {
                addcar.Title = "add car location";
            }
            else
            {
                addcar.Title = "remove car location";
                addcar.Background = new SolidColorBrush(Colors.Red);
            }

        }
        private void Map_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isolatedStorage.Contains("long") || ((String)(isolatedStorage["long"])).Equals(""))
            {
                MessageBox.Show("Please add your car location.");
            }
            else
            {
                NavigationService.Navigate(new Uri("/Map.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void Add_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Debug.WriteLine("Add tap");
            //NavigationService.Navigate(new Uri("/New.xaml", UriKind.RelativeOrAbsolute));
            if (!isolatedStorage.Contains("long") || ((String)(isolatedStorage["long"])).Equals(""))
            {
                AddCarLocation();
                addcar.Title = "remove car location";
                addcar.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Debug.WriteLine("isolatedStorage(long) is " + (String)(isolatedStorage["long"]));
                // check if user cofirmed remove car location
                bool removedCarLocation = RemoveCarLocation();
                if (removedCarLocation == true) // update button if user selected to removed location
                {
                    addcar.Title = "add car location";
                    addcar.Background = new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"]);
                }
            }
        }

        private bool RemoveCarLocation()
        {
            bool removedCarLocation = false;
            // allow user to confirm removal of car location
            MessageBoxResult result = MessageBox.Show("Do you want to remove the location?", "Confirm deletion", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Debug.WriteLine("remove");
                isolatedStorage["long"] = "";
                isolatedStorage["lat"] = "";
                isolatedStorage["alt"] = "";
                isolatedStorage["course"] = "";
                isolatedStorage.Save();
                removedCarLocation = true;
            }
            return removedCarLocation;
        }
        private void AddCarLocation()
        {
            Debug.WriteLine("add");
            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High); // using high accuracy
                watcher.MovementThreshold = 20; // use MovementThreshold to ignore noise in the signal
                watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
                watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            }
            watcher.Start();
        }
        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    // The Location Service is disabled or unsupported.
                    // Check to see whether the user has disabled the Location Service.
                    if (watcher.Permission == GeoPositionPermission.Denied)
                    {
                        // The user has disabled the Location Service on their device.
                        Debug.WriteLine("you have this application access to location.");;
                    }
                    else
                    {
                        Debug.WriteLine( "location is not functioning on this device");
                    }
                    break;

                case GeoPositionStatus.Initializing:
                    // The Location Service is initializing.
                    // Disable the Start Location button.
                    //startLocationButton.IsEnabled = false;
                    break;

                case GeoPositionStatus.NoData:
                    // The Location Service is working, but it cannot get location data.
                    // Alert the user and enable the Stop Location button.
                    Debug.WriteLine( "location data is not available.");
                    //stopLocationButton.IsEnabled = true;
                    break;

                case GeoPositionStatus.Ready:
                    // The Location Service is working and is receiving location data.
                    // Show the current position and enable the Stop Location button.
                    Debug.WriteLine("location data is available.");
                    //stopLocationButton.IsEnabled = true;
                    break;
            }
        }
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Debug.WriteLine("Lat"+e.Position.Location.Latitude.ToString("0.000"));
            Debug.WriteLine("Long"+e.Position.Location.Longitude.ToString("0.000"));
            isolatedStorage["long"] = e.Position.Location.Longitude.ToString("0.000");
            isolatedStorage["lat"] = e.Position.Location.Latitude.ToString("0.000");
            isolatedStorage["alt"] = e.Position.Location.Altitude.ToString("0.000");
            isolatedStorage["course"] = e.Position.Location.Course.ToString("0.000");
            isolatedStorage.Save();
            watcher.Stop();

        }

        private void Direction_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Debug.WriteLine("wasssup !!!!!!");
            if (!isolatedStorage.Contains("long") || ((String)(isolatedStorage["long"])).Equals(""))
            {
                MessageBox.Show("Please add your car location.");
            }
            else
            {
                GeoCoordinate spaceNeedleLocation = new GeoCoordinate(Double.Parse((String)(isolatedStorage["lat"])), Double.Parse((String)(isolatedStorage["long"])));
                BingMapsDirectionsTask bingMapsDirectionsTask = new BingMapsDirectionsTask();
                LabeledMapLocation spaceNeedleLML = new LabeledMapLocation("Your car", spaceNeedleLocation);
                bingMapsDirectionsTask.End = spaceNeedleLML;
                bingMapsDirectionsTask.Show();
            }
            
        }

        private void About_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AppInfoPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
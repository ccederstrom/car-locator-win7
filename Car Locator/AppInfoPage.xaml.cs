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
using Microsoft.Phone.Tasks;
using Coding4Fun.Phone.Controls.Data;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using Information_Page.AppInfo;
using Information_Page.AppInfo.Application;

namespace Car_Locator
{
    public partial class AppInfoPage : PhoneApplicationPage
    {
        // use task to open app http://www.windowsphonegeek.com/articles/6-how-to-use-marketplace-tasks-in-a-wp7-app

        public AppInfoPage()
        {
            InitializeComponent();
            MainPivot.Title = PhoneHelper.GetAppAttribute("Title").ToUpper();
           // txtHelp.Text = "We will continue to roll out new features and your suggestions.";
            txtAppName.Text = PhoneHelper.GetAppAttribute("Title") + " v" + PhoneHelper.GetAppAttribute("Version");
                //" by " + PhoneHelper.GetAppAttribute("Author");
         //   txtVersion.Text = "version " + PhoneHelper.GetAppAttribute("Version");
            txtDescription.Text = PhoneHelper.GetAppAttribute("Description");

            //if (App.isPaidVersion == true)
            //{
            //    adControl.Visibility = System.Windows.Visibility.Collapsed;
            //    //svHelp.Height = 535;
            //    AppsListBox.Height = 535;
            //    AboutScrollViewer.Height = 535;
            //}
            //else
            //{
            //    AdvertiseInfo adInfo = new AdvertiseInfo();
            //    adControl = new Microsoft.Advertising.Mobile.UI.AdControl(adInfo.ApplicationID, adInfo.AdUnitID, true);
            //    //svHelp.Height = 454;
            //    AppsListBox.Height = 454;
            //    AboutScrollViewer.Height = 454;
            //}

            if (App.IsTrial == false)
            {
                adControl.Visibility = System.Windows.Visibility.Collapsed;
                adControl.IsEnabled = false;
                svHelp.Height = 535;
                AppsListBox.Height = 535;
                AboutScrollViewer.Height = 535;
            }
            else
            {
                AdvertiseInfo adInfo = new AdvertiseInfo();
                adControl = new Microsoft.Advertising.Mobile.UI.AdControl(adInfo.ApplicationID, adInfo.AdUnitID, true);
                svHelp.Height = 454;
                AppsListBox.Height = 454;
                AboutScrollViewer.Height = 454;
            }
        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            // app list
            ApplicationList mApplicationList = new ApplicationList();
            VersionList mVersionList = new VersionList();
            //foreach (AppDetail app in mApplicationList.AppList){
            //    Debug.WriteLine( app.Title + app.URL);
            //}
            AppsListBox.ItemsSource = mApplicationList.AppList;
            VersionHistoryListBox.ItemsSource = mVersionList.ItemList;
        }



        private void AppsListStackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var click = sender as StackPanel;
            AppDetail mAppDetail = click.DataContext as AppDetail;
            MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
            marketplaceDetailTask.ContentIdentifier = mAppDetail.MarketplaceID;
            marketplaceDetailTask.Show();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if ((Visibility)Resources["PhoneLightThemeVisibility"] == Visibility.Visible)
            {
                BitmapImage temp;
                temp = new BitmapImage(new Uri("/AppInfo/Images/About/Light/appbar.people.png", UriKind.Relative));
                this.chris_people.Source = temp;
                //temp = new BitmapImage(new Uri("/AppInfo/Images/About/Light/appbar.gotoaddressbar.rest.png", UriKind.Relative));
                //this.chris_goto.Source = temp;
                temp = new BitmapImage(new Uri("/AppInfo/Images/About/Light/appbar.twitter.bird.png", UriKind.Relative));
                this.chris_twitter.Source = temp;

                temp = new BitmapImage(new Uri("/AppInfo/Images/About/Light/appbar.people.png", UriKind.Relative));
                this.hung_people.Source = temp;
                //temp = new BitmapImage(new Uri("/AppInfo/Images/About/Light/appbar.gotoaddressbar.rest.png", UriKind.Relative));
                //this.hung_goto.Source = temp;
                temp = new BitmapImage(new Uri("/AppInfo/Images/About/Light/appbar.twitter.bird.png", UriKind.Relative));
                this.hung_twitter.Source = temp;
            }
            else
            {
                BitmapImage temp;
                temp = new BitmapImage(new Uri("/AppInfo/Images/About/Dark/appbar.people.png", UriKind.Relative));
                this.chris_people.Source = temp;
                //temp = new BitmapImage(new Uri("/AppInfo/Images/About/Dark/appbar.gotoaddressbar.rest.png", UriKind.Relative));
                //this.chris_goto.Source = temp;
                temp = new BitmapImage(new Uri("/AppInfo/Images/About/Dark/appbar.twitter.bird.png", UriKind.Relative));
                this.chris_twitter.Source = temp;

                temp = new BitmapImage(new Uri("/AppInfo/Images/About/Dark/appbar.people.png", UriKind.Relative));
                this.hung_people.Source = temp;
                //temp = new BitmapImage(new Uri("/AppInfo/Images/About/Dark/appbar.gotoaddressbar.rest.png", UriKind.Relative));
                //this.hung_goto.Source = temp;
                temp = new BitmapImage(new Uri("/AppInfo/Images/About/Dark/appbar.twitter.bird.png", UriKind.Relative));
                this.hung_twitter.Source = temp;
            }
        }

        private void appbar_button_RateAndReview_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask _marketplaceReview = new MarketplaceReviewTask();
            _marketplaceReview.Show();
        }

        private void appbar_button_Share_Click(object sender, EventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();
            ShareInfo appInfo = new ShareInfo();
            shareLinkTask.Title = PhoneHelper.GetAppAttribute("Title") ;
            shareLinkTask.LinkUri = new Uri(appInfo.LinkUri, UriKind.Absolute);
            shareLinkTask.Message = appInfo.LinkMessage;
            shareLinkTask.Show();
        }

        private void appbar_button_ContactUs_Click(object sender, EventArgs e)
        {
            EmailComposeTask _emailComposeTask = new EmailComposeTask();
            _emailComposeTask.To = "pngc.wp7@hotmail.com";
            _emailComposeTask.Subject = PhoneHelper.GetAppAttribute("Title") + " v" + PhoneHelper.GetAppAttribute("Version") + " Feedback";
            _emailComposeTask.Show();
        }

        private void appbar_button_MarketplaceSearch_Click(object sender, EventArgs e)
        {
            MarketplaceSearchTask _marketplaceSearch = new MarketplaceSearchTask();
            _marketplaceSearch.SearchTerms = PhoneHelper.GetAppAttribute("Author");
            _marketplaceSearch.Show();
        }
    }
}
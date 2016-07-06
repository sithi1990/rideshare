using DriverLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DriverLocatorFormsPortable
{
    public class NotificationInfo
    {
        public string RequestId { get; set; }
        public string LocationName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new Login();
        }

        public App(NotificationInfo notificationInfo)
        {
            // The root page of your application
            MainPage = new MainPage(notificationInfo);
        }

        public static bool IsUserLoggedIn
        {
            get;
            set;
        }

        public static UserCoordinate CurrentLoggedUser { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using DriverLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DriverLocatorFormsPortable
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new Login();
        }

        public App(string data)
        {
            // The root page of your application
            MainPage = new Login(data);
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

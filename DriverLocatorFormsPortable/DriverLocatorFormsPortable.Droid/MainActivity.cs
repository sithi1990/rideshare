﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;

namespace DriverLocatorFormsPortable.Droid
{
    [Activity(Label = "DriverLocatorFormsPortable", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { "com.virtusa.driverlocatorforms.NOTIFICATION" }, Categories = new[] { "android.intent.category.DEFAULT" })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        /*
            "request_id":"1122",
            "location_name": "Colombo",
            "longitude":"34.54",
            "latitude":"55.67"
         */
       
        public const string KEY_REQUEST_ID_EXTRA = "request_id";
        public const string KEY_LOCATION_NAME_EXTRA = "location_name";
        public const string KEY_LONGITUDE_EXTRA = "longitude";
        public const string KEY_LATITUDE_EXTRA = "latitude";

        protected override void OnCreate(Bundle bundle)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.FormsMaps.Init(this, bundle);

            if (Intent.HasExtra(KEY_REQUEST_ID_EXTRA))
            {
                NotificationInfo notificationInfo = new NotificationInfo();
                notificationInfo.RequestId = Intent.GetStringExtra(KEY_REQUEST_ID_EXTRA);
                notificationInfo.LocationName = Intent.GetStringExtra(KEY_LOCATION_NAME_EXTRA);
                notificationInfo.Longitude = Intent.GetStringExtra(KEY_LONGITUDE_EXTRA);
                notificationInfo.Latitude = Intent.GetStringExtra(KEY_LATITUDE_EXTRA);
                LoadApplication(new App(notificationInfo));
            }
            else
            {
                LoadApplication(new App());
            }


        }
    }
}


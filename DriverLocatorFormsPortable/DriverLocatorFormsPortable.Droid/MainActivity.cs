using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DriverLocatorFormsPortable.Droid
{
    [Activity(Label = "DriverLocatorFormsPortable", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { "com.virtusa.driverlocatorforms.NOTIFICATION" }, Categories = new[] { "android.intent.category.DEFAULT" })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public const string KEY_MESSAGE_EXTRA = "message";
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.FormsMaps.Init(this, bundle);

            if (Intent.HasExtra(KEY_MESSAGE_EXTRA))
            {
                LoadApplication(new App(Intent.Extras.Get(KEY_MESSAGE_EXTRA).ToString()));
            }
            else
            {
                LoadApplication(new App());
            }


        }
    }
}


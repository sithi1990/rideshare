using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DriverLocatorFormsPortable.SharedInterfaces;
using Quobject.SocketIoClientDotNet.Client;

[assembly: Xamarin.Forms.Dependency(typeof(DriverLocatorFormsPortable.Droid.DependecyServices.MapSocketServiceDroid))]
namespace DriverLocatorFormsPortable.Droid.DependecyServices
{
    public class MapSocketServiceDroid : IMapSocketService
    {
        public event EventHandler MapCoordinateChanged;

        public MapSocketServiceDroid()
        {
            var socket = IO.Socket("http://172.28.40.120:8079");
            socket.On("coordinate_changed", MapUpdated);
        }

        private void MapUpdated(object obj)
        {
            MapCoordinateChanged(obj, null);
        }
    }
}
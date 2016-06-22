using DriverLocatorFormsPortable.SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DriverLocatorFormsPortable
{
    public partial class TestView : ContentPage
    {
        public TestView()
        {
            InitializeComponent(); var mapSocketService = DependencyService.Get<IMapSocketService>();
            mapSocketService.MapCoordinateChanged += mapSocketService_MapCoordinateChanged;
        }

        void mapSocketService_MapCoordinateChanged(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                testLabel.Text = Guid.NewGuid().ToString();
            });

        }
    }
}

using DriverLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DriverLocatorFormsPortable
{
    public partial class CreateUser : ContentPage
    {
        UserCoordinate userCoordinate;
        DriverLocator.DriverLocatorService driverLocatorService = new DriverLocator.DriverLocatorService(Session.AuthenticationService);
        public CreateUser()
        {
            InitializeComponent();
            FillUserData();
        }

        public CreateUser(UserCoordinate userCoordinate)
        {
            InitializeComponent();
            this.userCoordinate = userCoordinate;
            FillUserData();
        }

        private void FillUserData()
        {
            if (userCoordinate != null)
            {

                UserName.Text = userCoordinate.UserName;
                EMail.Text = userCoordinate.EMail;
                FirstName.Text = userCoordinate.FirstName;
                LastName.Text = userCoordinate.LastName;
                Longitude.Text = userCoordinate.Longitude;
                Latitude.Text = userCoordinate.Latitude;
            }
            else
            {
                var userInfo = Session.AuthenticationService.GetUserInfo(Session.AuthenticationService.AuthenticationToken);
                UserName.Text = userInfo.UserName;
                EMail.Text = userInfo.EMail;
            }

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                UserCoordinate userCoordinate = new UserCoordinate();
                userCoordinate.UserName = UserName.Text;
                userCoordinate.EMail = EMail.Text;
                userCoordinate.FirstName = FirstName.Text;
                userCoordinate.LastName = LastName.Text;
                userCoordinate.Longitude = Longitude.Text;
                userCoordinate.Latitude = Latitude.Text;
                var result = driverLocatorService.SaveUserData(userCoordinate);
                if (result.IsSuccess)
                {
                    App.CurrentLoggedUser = userCoordinate;
                    App.Current.MainPage = new MainPage();
                   
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

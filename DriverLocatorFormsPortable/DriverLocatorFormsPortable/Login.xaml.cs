using Authentication;
using Authentication.Models;
using DriverLocatorFormsPortable.Common;
using DriverLocatorFormsPortable.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DriverLocatorFormsPortable
{
    public partial class Login : ContentPage,ILoginPageProcessor
    {
        public Login()
        {
            InitializeComponent();
            Content.BindingContext = new LoginViewModel(this);
            //Session.AuthenticationService = new AuthenticationService();
        }

        public Login(string data)
        {
            InitializeComponent();
            var loginVm= new LoginViewModel(this);
            loginVm.ErrorMessage = data;
            Content.BindingContext = loginVm;
            //Session.AuthenticationService = new AuthenticationService();
        }

        //void OnLoginButtonClicked(object sender, EventArgs e)
        //{
        //    var user = new User
        //    {
        //        UserName = usernameEntry.Text,
        //        Password = passwordEntry.Text
        //    };


        //    var isValid = AreCredentialsCorrect(user);
        //    if (isValid)
        //    {

        //        DriverLocator.DriverLocatorService driverLocatorService = new DriverLocator.DriverLocatorService(Session.AuthenticationService);
        //        var userCorrdinateResult = driverLocatorService.GetSelectedUserCoordinate();

        //        if (userCorrdinateResult.IsSuccess)
        //        {
        //            App.CurrentLoggedUser = userCorrdinateResult.UserCoordinate;
        //            App.Current.MainPage = new MainPage();
        //        }
        //        else
        //        {
        //            App.Current.MainPage = new CreateUser();
        //        }

        //        //if (userCorrdinateResult.IsSuccess)
        //        //{
        //        //    App.CurrentLoggedUser = userCorrdinateResult.UserCoordinate;
        //        //    await Navigation.PushAsync(new MapView());
        //        //}
        //        //else
        //        //{
        //        //    await Navigation.PushAsync(new CreateUser());
        //        //}

        //    }
        //    else
        //    {
        //        messageLabel.Text = "Login failed";
        //        passwordEntry.Text = string.Empty;
        //    }
        //}

        //async void OnSignUpButtonClicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        App.Current.MainPage = new SignUp();
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //}

        //bool AreCredentialsCorrect(User user)
        //{
        //    if (Session.AuthenticationService.Authenticate(user.UserName, user.Password))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public void MoveToMainPage()
        {
            App.Current.MainPage = new MainPage();
        }

        public void MoveToCreateUserPage()
        {
            App.Current.MainPage = new CreateUser();
        }

        public void MoveToSignUpPage()
        {
            App.Current.MainPage = new SignUp();
        }
    }
}

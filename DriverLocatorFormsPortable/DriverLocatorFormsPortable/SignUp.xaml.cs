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
    public partial class SignUp : ContentPage,ISignUpPageProcessor
    {
        public SignUp()
        {
            InitializeComponent();
            Content.BindingContext = new SignUpViewModel(this);
        }

        public void MoveToLoginPage()
        {
            App.Current.MainPage = new Login();
        }
    }
}

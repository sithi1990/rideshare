using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DriverLocatorFormsPortable
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
        public object Patameters { get; set; }
    }

    public partial class MasterPage : ContentPage
    {
       
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            lblUserName.Text = App.CurrentLoggedUser.UserName;
            var masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Edit Profile",
                IconSource = "edit.png",
                TargetType = typeof(CreateUser),
                Patameters = App.CurrentLoggedUser
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "History",
                IconSource = "history.png",
                TargetType = typeof(CreateUser),
                Patameters = App.CurrentLoggedUser
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "settings.png",
                TargetType = typeof(CreateUser),
                Patameters = App.CurrentLoggedUser
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Help",
                IconSource = "help.png",
                TargetType = typeof(CreateUser),
                Patameters = App.CurrentLoggedUser
            });


            masterPageItems.Add(new MasterPageItem
            {
                Title = "About",
                IconSource = "about.png",
                TargetType = typeof(CreateUser),
                Patameters = App.CurrentLoggedUser
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Logout",
                IconSource = "logout.png",
                TargetType = typeof(MapView),
                Patameters = null
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Map",
                IconSource = "map.png",
                TargetType = typeof(MapView),
                Patameters=null
            });
           
         
            listView.ItemsSource = masterPageItems;
            

        }
    }
}

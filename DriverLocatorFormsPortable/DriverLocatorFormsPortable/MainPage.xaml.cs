﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DriverLocatorFormsPortable
{
    public partial class MainPage : MasterDetailPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if(item.Patameters!=null)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, new object[] { item.Patameters }));
                }
                else
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                }
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}

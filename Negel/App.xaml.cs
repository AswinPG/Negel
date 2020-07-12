﻿using Negel.Login;
using Negel.Subject;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Negel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (App.Current.Properties.ContainsKey("UserName"))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
                MainPage = new NavigationPage( new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

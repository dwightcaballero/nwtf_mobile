﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using nwtf_mobile_bl;
using nwtf_mobile.app;

namespace nwtf_mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //one time initialization
            //dataservices.Database.initializeDB();

            //comment this after using
            //dataservices.Database.modifyInitialization();

            dto.claimDTO claimDTO = new dto.claimDTO();
            MainPage = new NavigationPage(new claimCreation(claimDTO));
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

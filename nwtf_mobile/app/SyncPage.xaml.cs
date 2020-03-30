﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using nwtf_mobile_bl;

namespace nwtf_mobile.app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyncPage : ContentPage
    {
        public SyncPage()
        {
            InitializeComponent();
            Title = "Sync to Server";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           var isUser = views.vwTempUsers.getUser(usernameEntry.Text, passwordEntry.Text);
            if (isUser == true)
            {
                await Navigation.PushAsync(new claimSelection());
            }
            else
            {
                await DisplayAlert("Error", "User is not in the database!", "Ok");
            }
        }
    }
}
﻿
using nwtf_mobile_bl;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nwtf_mobile.app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class claimCreation : ContentPage
    {
        public claimCreation(dto.claimDTO claimdto)
        {
            headerDetails.setClaimDTO(claimdto);
            claimTypes.setClaimDTO(claimdto);
            InitializeComponent();

        }

        public void saveClaimTransaction(object sender, EventArgs e)
        {
           claimTypes.gatherRepeater();
        }

    }
}
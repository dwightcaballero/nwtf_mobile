﻿using nwtf_mobile_bl;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;
using Android.Widget;
using Android.Content;
using Android.Provider;
using Android.Runtime;
using Android.App;

namespace nwtf_mobile.app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class requiredDocuments : ContentView
    {
        controllers.claimTransaction pcon = new controllers.claimTransaction();

        public requiredDocuments()
        {
            pcon.loadrequiredDocuments += Pcon_loadrequiredDocuments;
            InitializeComponent();
            pcon.getRequiredDocuments();
            stkAddFile.IsVisible = false;
            stkUploadRequiredDocument.IsVisible = false;
            //loadListRecDocImage();
            //stkRequiredDocuments.IsVisible = false;
        }

        void loadListRecDocImage()
        {
            List<views.vwClaimTypeRequiredDocumentImage> lstReqDocImags = new List<views.vwClaimTypeRequiredDocumentImage>();

            lstReqDocImags.Add( new views.vwClaimTypeRequiredDocumentImage { id = Guid.NewGuid(), claimTypeRequiredDocumentID = Guid.NewGuid(), requiredDocumentDescription="Try", requiredDocumentImageName="try.jpg" }) ;
            lstReqDocImags.Add( new views.vwClaimTypeRequiredDocumentImage { id = Guid.NewGuid(), claimTypeRequiredDocumentID = Guid.NewGuid(), requiredDocumentDescription="Try2", requiredDocumentImageName="try2.jpg" }) ;
            lstReqDocImags.Add( new views.vwClaimTypeRequiredDocumentImage { id = Guid.NewGuid(), claimTypeRequiredDocumentID = Guid.NewGuid(), requiredDocumentDescription="Try3", requiredDocumentImageName="try3.jpg" }) ;
            
            lstVwUploadedFiles.HeightRequest = (60 * lstReqDocImags.Count) + (10 * lstReqDocImags.Count);
            lstVwUploadedFiles.ItemsSource = lstReqDocImags;
        }

        private void Pcon_loadrequiredDocuments(object sender, List<views.vwRequiredDocuments> e)
        {
            lstVwRequiredDocument.HeightRequest = (60 * e.Count) + (10 * e.Count);
            lstVwRequiredDocument.ItemsSource = e;
        }

        async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                CompressionQuality = 40,
                Name = "try.jpg",
                Directory = "sample"
            }) ;

            if(file == null)
            {
                return;
            }

        }

        async void UploadPhoto()
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                Toast.MakeText(Android.App.Application.Context, "upload not supported on this device", ToastLength.Short).Show();
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                CompressionQuality=40
            }) ;
        }

        private void btnFileUpload_Clicked(object sender, EventArgs e)
        {
            loadListRecDocImage();
            Xamarin.Forms.Button btnFileUpload = (Xamarin.Forms.Button)sender;
            var row = Grid.GetRow(btnFileUpload);
            var grd = btnFileUpload.Parent as Grid;
            var reqDocName = grd.Children.Where(child => Grid.GetRow(child) == row && Grid.GetColumn(child) == 0).FirstOrDefault();
            Label reqdoc = (Label)reqDocName;

            Guid requiredDocumentID = (Guid)btnFileUpload.CommandParameter;
            lblRequiredDocumentID.Text = requiredDocumentID.ToString();
            //views.vwRequiredDocuments reqDocRecord = views.vwRequiredDocuments.getRequiredDocumentRecord(requiredDocumentID);
            lblRequiredDocumentTitle.Text = reqdoc.Text; //reqDocRecord.requiredDocumentName;

            stkRequiredDocuments.IsVisible = false;
            stkUploadRequiredDocument.IsVisible = true;
            lstVwUploadedFiles.IsVisible = false;
        }

        //protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode)
        //{
        //    base.OnActivityResult(requestCode, resultCode, data);
        //}

        private void btnCapture_Clicked(object sender, EventArgs e)
        {
            //Intent intent = new Intent(MediaStore.ActionImageCapture);
            //StartActivityForResult(intent, 0);
            stkAddFile.IsVisible = true;
            TakePhoto();
        }

        private void btnUpload_Clicked(object sender, EventArgs e)
        {
            stkAddFile.IsVisible = true;
            UploadPhoto();
        }

        private void btnOK_Clicked(object sender, EventArgs e)
        {
            stkAddFile.IsVisible = false;
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            stkAddFile.IsVisible = false;
        }
    }
}
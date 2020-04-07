using Android;
using nwtf_mobile_bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        }

        private void Pcon_loadrequiredDocuments(object sender, List<views.vwRequiredDocuments> e)
        {
            lstVwRequiredDocument.ItemsSource = e;
        }

        async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            //var file 
        }

        private void btnFileUpload_Clicked(object sender, EventArgs e)
        {
            Button btnFileUpload = (Button)sender;
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
        }

        private void btnCapture_Clicked(object sender, EventArgs e)
        {

        }

    }
}
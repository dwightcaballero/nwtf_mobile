using nwtf_mobile_bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private void Pcon_loadrequiredDocuments(object sender, List<views.vwRequiredDocuments> e)
        {
            lstVwRequiredDocument.ItemsSource = e;
        }
    }
}
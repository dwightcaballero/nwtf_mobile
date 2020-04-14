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
    public partial class requiredFields : ContentView
    {
        controllers.claimTransaction pcon = new controllers.claimTransaction();

        public requiredFields()
        {
            pcon.loadRequiredFields += Pcon_loadRequiredFields;
            InitializeComponent();
            pcon.getRequiredFields();
            
        }

        private void Pcon_loadRequiredFields(object sender, List<views.vwRequiredFields> e)
        {
            lstVwRequiredFields.HeightRequest = (30 * e.Count) + (10 * e.Count);
            lstVwRequiredFields.ItemsSource = e;
        }
    }
}
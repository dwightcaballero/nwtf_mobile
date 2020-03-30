using System;
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
    public partial class claimSelection : ContentPage
    {
        dto.claimDTO claimDTO { get; set; }
        controllers.claimTransaction pcon = new controllers.claimTransaction();

        public claimSelection()
        {
            InitializeComponent();
            claimDTO = new dto.claimDTO();
            hideStacks();
            subscribeToAllEvents();
            pcon.getListCustomerForGrid();
        }

        void hideStacks()
        {
            stackCustomer.IsVisible = false;
            stackMAF.IsVisible = false;
        }

        // subscribe to all events in the controller
        void subscribeToAllEvents()
        {
            pcon.loadCustomerGrid += Pcon_loadCustomerGrid;
            pcon.loadMAFGrid += Pcon_loadMAFGrid;
        }

        private void Pcon_loadCustomerGrid(object sender, List<views.vwCustomer> e)
        {
            stackCustomer.IsVisible = true;

            claimDTO.listCustomer = e;
            listCustomer.ItemsSource = e;
        }

        private void btnCustomer_Clicked(object sender, System.EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid customerID = (Guid)btnSelected.CommandParameter;
            pcon.getListMAFForGrid(customerID);
        }

        private void Pcon_loadMAFGrid(object sender, (List<views.vwMafEnrollmentClosure>, views.vwCustomer) e)
        {
            stackCustomer.IsVisible = false;
            stackMAF.IsVisible = true;

            claimDTO.listMAF = e.Item1;
            listMAF.ItemsSource = e.Item1;
            claimDTO.customer = e.Item2;
        }

        private void btnMAF_Clicked(object sender, System.EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid mafID = (Guid)btnSelected.CommandParameter;
            // to be continued
        }
    }
}
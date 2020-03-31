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
            stackClaimant.IsVisible = false;
        }

        // subscribe to all events in the controller
        void subscribeToAllEvents()
        {
            pcon.showMessage += Pcon_showMessage;
            pcon.loadCustomerGrid += Pcon_loadCustomerGrid;
            pcon.loadMAFGrid += Pcon_loadMAFGrid;
            pcon.loadClaimantGrid += Pcon_loadClaimantGrid;
        }

        private void Pcon_showMessage(object sender, (string, string, string) e)
        {
            displayMessage(e.Item1, e.Item2, e.Item3);
        }

        private void Pcon_loadCustomerGrid(object sender, List<views.vwCustomer> e)
        {
            Title = "Selection of Customer";
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

        void displayMessage(string title, string message, string buttonName)
        {
            DisplayAlert(title, message, buttonName);
        }

        private void Pcon_loadMAFGrid(object sender, (List<views.vwMafEnrollmentClosure>, views.vwCustomer) e)
        {
            Title = "Selection of Customer's Enrolled Packages";
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

            pcon.getListClaimantForGrid(mafID);
        }

        private void Pcon_loadClaimantGrid(object sender, (List<views.vwClaimant>, views.vwMafEnrollmentClosure) e)
        {
            Title = "Selection of Claimant";
            stackMAF.IsVisible = false;
            stackClaimant.IsVisible = true;

            claimDTO.listClaimant = e.Item1;
            listClaimant.ItemsSource = e.Item1;
            claimDTO.maf = e.Item2;
        }

        private void btnClaimant_Clicked(object sender, EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid claimantID = (Guid)btnSelected.CommandParameter;

            //to be continued
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar sbar = (SearchBar)sender;
            if (!string.IsNullOrWhiteSpace(sbar.Text))
            {
                // capitalize search text (uncomment if database changed)
                // string searchText = sbar.Text.ToUpper();

                var listFilteredCustomer = (from cust in claimDTO.listCustomer
                                           where cust.dungganonID.Contains(sbar.Text) ||
                                                 cust.customerLastName.Contains(sbar.Text) ||
                                                 cust.customerFirstName.Contains(sbar.Text) ||
                                                 cust.customerMiddleName.Contains(sbar.Text)
                                           orderby cust.customerLastName, cust.customerFirstName
                                           select cust).ToList();

                listCustomer.ItemsSource = listFilteredCustomer;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar sbar = (SearchBar)sender;
            if (string.IsNullOrWhiteSpace(sbar.Text))
            {
                listCustomer.ItemsSource = claimDTO.listCustomer;
            }
        }
    }
}
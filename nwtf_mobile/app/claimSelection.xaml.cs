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
        nwtf_mobile_bl.customBind.cbClaimSelectionHeader cbClaimSelectionHeader = new nwtf_mobile_bl.customBind.cbClaimSelectionHeader();

        public claimSelection()
        {
            InitializeComponent();
            claimDTO = new dto.claimDTO();
            hideStacks();
            subscribeToAllEvents();
            pcon.getListCustomerForGrid();
        }

        // hide all stacks in claim selection
        void hideStacks()
        {
            stackHeader.IsVisible = false;

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

        // display messages
        void displayMessage(string title, string message, string buttonName)
        {
            DisplayAlert(title, message, buttonName);
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
            lvCustomer.ItemsSource = e;
        }

        private void btnCustomer_Clicked(object sender, System.EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid customerID = (Guid)btnSelected.CommandParameter;
            pcon.getListMAFForGrid(customerID);
        }

        private void Pcon_loadMAFGrid(object sender, (List<views.vwMafEnrollmentClosure>, views.vwCustomer) e)
        {
            var listMAF = e.Item1;
            var customer = e.Item2;

            Title = "Selection of Customer's Enrolled Packages";
            stackCustomer.IsVisible = false;
            stackMAF.IsVisible = true;

            stackHeader.IsVisible = true;
            cbClaimSelectionHeader.customerID = customer.customerID;
            cbClaimSelectionHeader.customerName = customer.customerLastName + ", " +
                                                  customer.customerFirstName + " " +
                                                  customer.customerMiddleName + " " +
                                                  customer.customerSuffix;
            //gridClaimSelectionHeader.BindingContext = cbClaimSelectionHeader;

            claimDTO.listMAF = listMAF;
            lvMAF.ItemsSource = listMAF;
            claimDTO.customer = customer;
        }

        private void btnMAF_Clicked(object sender, System.EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid mafID = (Guid)btnSelected.CommandParameter;

            pcon.getListClaimantForGrid(mafID);
        }

        private void Pcon_loadClaimantGrid(object sender, (List<views.vwClaimant>, views.vwMafEnrollmentClosure) e)
        {
            var listClaimant = e.Item1;
            var maf = e.Item2;

            Title = "Selection of Claimant";
            stackMAF.IsVisible = false;
            stackClaimant.IsVisible = true;

            cbClaimSelectionHeader.productname = maf.productName;
            cbClaimSelectionHeader.productID = maf.productID;

            claimDTO.listClaimant = listClaimant;
            lvClaimant.ItemsSource = listClaimant;
            claimDTO.maf = maf;
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

                lvCustomer.ItemsSource = listFilteredCustomer;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar sbar = (SearchBar)sender;
            if (string.IsNullOrWhiteSpace(sbar.Text))
            {
                lvCustomer.ItemsSource = claimDTO.listCustomer;
            }
        }
    }
}
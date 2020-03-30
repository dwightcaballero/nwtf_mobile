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
        nwtf_mobile_bl.dto.claimDTO claimDTO { get; set; }
        nwtf_mobile_bl.controllers.claimTransaction pcon = new nwtf_mobile_bl.controllers.claimTransaction();

        public claimSelection()
        {
            InitializeComponent();
            hideStacks();
            loadCustomers();
        }

        void hideStacks()
        {
            stackCustomer.IsVisible = false;
            stackMAF.IsVisible = false;
        }

        void loadCustomers()
        {
            stackCustomer.IsVisible = true;

            //var customers = nwtf_mobile_bl.views.vwCustomer.getAllCustomerForGrid();
            //claimDTO.listCustomer = customers;
            //listCustomer.ItemsSource = customers;
        }

        private void btnCustomer_Clicked(object sender, System.EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid customerID = (Guid)btnSelected.CommandParameter;

            var customerSelected = claimDTO.listCustomer.FirstOrDefault(cust => cust.id == customerID);
            if (customerSelected != null) claimDTO.customer = customerSelected;
            loadMAFs(customerID);
        }

        void loadMAFs(Guid customerID)
        {
            stackCustomer.IsVisible = false;
            stackMAF.IsVisible = true;

            //get listMAF
        }

        private void btnMAF_Clicked(object sender, System.EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid mafID = (Guid)btnSelected.CommandParameter;
        }
    }
}
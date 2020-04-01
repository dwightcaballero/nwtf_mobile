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
    public partial class headerDetails : ContentView
    {
        public headerDetails()
        {
            InitializeComponent();
            PopulateHeader();
        }

        private void PopulateHeader()
        {
            // Temporary Data
            Label custID = this.FindByName<Label>("txtCustID");
            Label custName = this.FindByName<Label>("txtCustName");
            Label prodID = this.FindByName<Label>("txtProdID");
            Label prodName = this.FindByName<Label>("txtProdName");

            custID.Text = "1184990001";
            custName.Text = "Dwight Kenn Caballero";
            prodID.Text = "12345";
            prodName.Text = "3104";
        }
    }
}
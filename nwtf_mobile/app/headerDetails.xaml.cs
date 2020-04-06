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
            txtCustID.Text = "1184990001";
            txtCustName.Text = "Dwight Kenn Caballero";
            txtProdID.Text = "12345";
            txtProdName.Text = "3104";
            txtClaimantName.Text = "Sweet Angel Altamera";
            txtClaimantRel.Text = "Sister";
            txtClaimTypesList.Text = "Claim Type A, Claim Type B, Claim Type C";
        }
    }
}
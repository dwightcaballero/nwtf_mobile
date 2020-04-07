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
    public partial class headerDetails : ContentView
    {
        public static dto.claimDTO claimdto { get; set; }

        public static void setClaimDTO(dto.claimDTO value)
        {
            claimdto = value;
        }

        public headerDetails()
        {
            InitializeComponent();
            PopulateHeader(claimdto);
        }

        private void PopulateHeader(dto.claimDTO claimdto)
        {
            txtCustID.Text = claimdto.customer.customerID;
            if (claimdto.customer.customerSuffix == null)
            {
                txtCustName.Text = claimdto.customer.customerLastName + ", " + claimdto.customer.customerFirstName + " " + claimdto.customer.customerMiddleName;
            }
            else
            {
                txtCustName.Text = claimdto.customer.customerLastName + ", " + claimdto.customer.customerFirstName + " " + claimdto.customer.customerMiddleName + " " + claimdto.customer.customerSuffix;
            }
            txtProdID.Text = claimdto.maf.productID;
            txtProdName.Text = claimdto.maf.productName;
            txtClaimantName.Text = claimdto.claimant.claimantFullName;
            txtClaimantRel.Text = systemconst.getClaimantDescription(claimdto.claimant.claimantType);
            txtClaimTypesList.Text = "Claim Type A, Claim Type B, Claim Type C";
        }
    }
}
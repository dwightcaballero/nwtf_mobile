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
    public partial class claimCreation : ContentPage
    {
        public claimCreation(dto.claimDTO claimdto)
        {

            // Temporary Data
            claimdto.customer.customerID = "1184990001";
            claimdto.customer.customerFirstName = "Dwight";
            claimdto.customer.customerMiddleName = "Kenn";
            claimdto.customer.customerLastName = "Caballero";
            claimdto.maf.productID = "12345";
            claimdto.maf.productName = "3104";
            claimdto.claimantID = "Sweet Angel Altamera";
            claimdto.claimantType = 1;
            //   claimdto.listClaimType = "Claim Type A, Claim Type B, Claim Type C";
            claimTypes.setClaimDTO(claimdto);
            headerDetails.setClaimDTO(claimdto);
            InitializeComponent();
            
        }
    }
}
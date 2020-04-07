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
            // Sample Data
            claimdto.customer.customerFirstName="123";
            claimTypes.setClaimDTO(claimdto);
            InitializeComponent();
            
        }
    }
}
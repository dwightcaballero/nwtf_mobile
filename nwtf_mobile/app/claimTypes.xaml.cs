using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static nwtf_mobile_bl.views;

namespace nwtf_mobile.app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class claimTypes : ContentView
    {
        public vwClaimTypes claimtypesample = new vwClaimTypes();
        public List<vwClaimTypes> claimTypeList = new List<vwClaimTypes>();
        public claimTypes()
        {
            InitializeComponent();
            // Only Sample Data
            claimtypesample.claimBenefit = "Number of Days";
            claimtypesample.forAdvance = true;
            claimtypesample.claimTypeName = "Claim Type A";                       
            claimTypeList.Add(claimtypesample);
            claimTypeRepeater.ItemsSource = claimTypeList;
           
        }

         }
}
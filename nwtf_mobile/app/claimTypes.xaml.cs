using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CustomControls;
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

        public void PopulateClaimTypes()
        {
            // Only Sample Data
            claimtypesample.claimBenefit = "Number of Days";
            claimtypesample.allowAdvances = true;
            claimtypesample.claimTypeName = "Claim Type A";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Premiums Paid";
            claimtypesample.allowAdvances = false;
            claimtypesample.claimTypeName = "Claim Type B";
            claimTypeList.Add(claimtypesample);
            claimTypeRepeater.ItemsSource = claimTypeList;
        }

        public void AccessControlsInRepeater()
        {
            var control = claimTypeRepeater as RepeaterView;

            if (control == null) return;
            foreach (Grid item1 in control.Children)
            {
                Label forAdvancePanel = (Label)item1.Children[4];
                Label checkForAdvance = (Label)item1.Children[5];

                foreach (vwClaimTypes item in control.ItemsSource)
                {
                    if (item.forAdvance == false)
                    {
                        if (checkForAdvance == null) return;
                        if (item.forAdvance.ToString() == checkForAdvance.Text)
                        {
                            if (forAdvancePanel == null) return;
                            //  set for advance panel visible to false
                            forAdvancePanel.IsVisible = false;
                        }
                        continue;
                    }                  
                }
            }
        }
        public claimTypes()
        {
            InitializeComponent();
            PopulateClaimTypes();
            AccessControlsInRepeater();
          
        }             
    }
}
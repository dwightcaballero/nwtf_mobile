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
            claimtypesample.allowAdvances = false;
            claimtypesample.claimTypeName = "Claim Type A";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Premiums Paid";
            claimtypesample.allowAdvances = true;
            claimtypesample.claimTypeName = "Claim Type B";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Number of Weeks";
            claimtypesample.allowAdvances = true;
            claimtypesample.claimTypeName = "Claim Type C";
            claimTypeList.Add(claimtypesample);
            claimTypeRepeater.ItemsSource = claimTypeList;
        }

        public void AccessControlsInRepeater()
        {
            var control = claimTypeRepeater as RepeaterView;
            int claimBenefit = 1;
            if (control == null) return;
          
            foreach (Grid item1 in control.Children)
            {
                Switch forAdvancePanelValue = (Switch)item1.Children[5];
                Label forAdvancePanel = (Label)item1.Children[6];
                Label checkForAdvance = (Label)item1.Children[7];
                // Temporary Data
                if (claimBenefit == 1)
                {
                    TableView grd = (TableView)item1.Children[4];
                    grd.IsVisible = true;
                }
                claimBenefit++;

                foreach (vwClaimTypes item in control.ItemsSource)
                {
                    
                    if (item.forAdvance == false)
                    {
                        if (checkForAdvance == null) return;
                        if (item.forAdvance.ToString() == checkForAdvance.Text)
                        {
                            if (forAdvancePanel == null) return;
                            //  set for advance panel visible to false
                            forAdvancePanelValue.IsVisible = false;
                            forAdvancePanel.IsVisible = false;
                        }
                    }                  
                }
            }
        }

        void OnToggled(object sender, ToggledEventArgs e)
        {
            
            Switch forAdvancePanelValue = (Switch)sender;
            Grid parentGrid = (Grid)forAdvancePanelValue.Parent;
            TableView advancesList = (TableView)parentGrid.Children[8];
            if (forAdvancePanelValue.IsToggled == true)
            {
                advancesList.IsVisible = true;
            }
            else
            {
                advancesList.IsVisible = false;
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
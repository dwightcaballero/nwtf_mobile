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
            claimtypesample.claimBenefit = "LO Provides Amount";
            claimtypesample.allowAdvances = false;
            claimtypesample.claimTypeName = "Claim Type A";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Number of Days";
            claimtypesample.allowAdvances = true;
            claimtypesample.claimTypeName = "Claim Type B";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Number of Premiums Paid";
            claimtypesample.allowAdvances = true;
            claimtypesample.claimTypeName = "Claim Type C";
            claimTypeList.Add(claimtypesample);
            claimTypeRepeater.ItemsSource = claimTypeList;
        }

        public void setClaimBenefit(int cbl, Grid control)
        {
            // LO Provides Amount
            if (cbl == 1)
            {
                Grid grd = (Grid)control.Children[4];
                grd.IsVisible = true;
            }
            // Number of Days
            else if (cbl == 2)
            {
                Grid grd = (Grid)control.Children[5];
                grd.IsVisible = true;
            }
            // Number of Premiums Paid
            else if (cbl == 3)
            {
                Grid grd = (Grid)control.Children[6];
                grd.IsVisible = true;
            }
            // Number of Weeks
            else if (cbl == 4)
            {
                Grid grd = (Grid)control.Children[7];
                grd.IsVisible = true;
            }
            // Fixed Amount
            else if (cbl == 5)
            {
                Grid grd = (Grid)control.Children[8];
                grd.IsVisible = true;
            }
            // Membership Date
            else if (cbl == 6)
            {
                Grid grd = (Grid)control.Children[9];
                grd.IsVisible = true;
            }
            // Insurer Approved Amount
            else if (cbl == 7)
            {
                Grid grd = (Grid)control.Children[10];
                grd.IsVisible = true;
            }        
        }

        public void AccessControlsInRepeater()
        {
            var control = claimTypeRepeater as RepeaterView;
            int claimBenefit = 1;
            if (control == null) return;
          
            foreach (Grid item1 in control.Children)
            {
                Switch forAdvancePanelValue = (Switch)item1.Children[11];
                Label forAdvancePanel = (Label)item1.Children[12];
                Label checkForAdvance = (Label)item1.Children[13];
                setClaimBenefit(claimBenefit, item1);
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
            TableView advancesList = (TableView)parentGrid.Children[14];
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
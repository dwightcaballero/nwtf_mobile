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
            claimtypesample.allowAdvances = false;
            claimtypesample.claimTypeName = "Claim Type C";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Number of Weeks";
            claimtypesample.allowAdvances = false;
            claimtypesample.claimTypeName = "Claim Type D";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Fixed Amount";
            claimtypesample.allowAdvances = false;
            claimtypesample.claimTypeName = "Claim Type E";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Membership Date";
            claimtypesample.allowAdvances = true;
            claimtypesample.claimTypeName = "Claim Type F";
            claimTypeList.Add(claimtypesample);
            claimtypesample = new vwClaimTypes();
            claimtypesample.claimBenefit = "Insurer Approved Amount";
            claimtypesample.allowAdvances = true;
            claimtypesample.claimTypeName = "Claim Type G";
            claimTypeList.Add(claimtypesample);
            claimTypeRepeater.ItemsSource = claimTypeList;
        }
        
        // Add system constants and replace other values
        public void setClaimBenefit(int cbl, Grid control)
        {
            // LO Provides Amount
            if (cbl == 1)
            {
                Grid grd = (Grid)control.Children[4];
                // Change Maximum Amount
                Label maxAmount = (Label)grd.Children[3];
                maxAmount.Text = "600.00";
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Number of Days
            else if (cbl == 2)
            {
                int maxBasis = 1;
                Grid grd = (Grid)control.Children[5];
                // Change Date Labels
                Label dateFrom = (Label)grd.Children[0];
                dateFrom.Text = "New Date From:";
                Label dateTo = (Label)grd.Children[2];
                dateTo.Text = "New Date To:";
                // Change Date Values
                DatePicker dateFromVal = (DatePicker)grd.Children[1];
                DatePicker dateToVal = (DatePicker)grd.Children[3];
                // Change Other Labels (Depending on Basis)
                Label accumLabel = (Label)grd.Children[4];
                Label accumValue = (Label)grd.Children[5];
                Label maxLabel = (Label)grd.Children[6];
                Label maxValue = (Label)grd.Children[7];
                // Maximum Basis - Amount
                if (maxBasis == 1)
                {                 
                    maxLabel.Text = "Maximum Amount:";
                    maxValue.Text = "100.00";
                    accumLabel.Text = "Accumulated Amount:";
                    accumValue.Text = "15.00";
                }
                // Maximum Basis - Days
                else if (maxBasis == 2)
                {
                    maxLabel.Text = "Maximum Days:";
                    maxValue.Text = "20 Days";
                    accumLabel.Text = "Accumulated Days:";
                    accumValue.Text = "3 Days";
                }
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[9];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Number of Premiums Paid
            else if (cbl == 3)
            {
                Grid grd = (Grid)control.Children[6];
                // Change Maximum Amount
                Label weeksFromMembershipDate = (Label)grd.Children[1];
                weeksFromMembershipDate.Text = "6 Weeks"; 
                // Change Maximum Amount
                Label maxAmount = (Label)grd.Children[3];
                maxAmount.Text = "600.00";
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Number of Weeks
            else if (cbl == 4)
            {
                int maxBasis = 1;
                Grid grd = (Grid)control.Children[5];
                // Change Date Labels
                Label dateFrom = (Label)grd.Children[0];
                dateFrom.Text = "Weeks From:";
                Label dateTo = (Label)grd.Children[2];
                dateTo.Text = "Weeks To:";
                // Change Date Values
                DatePicker dateFromVal = (DatePicker)grd.Children[1];
                DatePicker dateToVal = (DatePicker)grd.Children[3];
                // Change Other Labels (Depending on Basis)
                Label accumLabel = (Label)grd.Children[4];
                Label accumValue = (Label)grd.Children[5];
                Label maxLabel = (Label)grd.Children[6];
                Label maxValue = (Label)grd.Children[7];
                // Maximum Basis - Amount
                if (maxBasis == 1)
                {
                    maxLabel.Text = "Maximum Amount:";
                    maxValue.Text = "100.00";
                    accumLabel.Text = "Accumulated Amount:";
                    accumValue.Text = "15.00";
                }
                // Maximum Basis - Weeks
                else if (maxBasis == 3)
                {
                    maxLabel.Text = "Maximum Weeks:";
                    maxValue.Text = "20 Weeks";
                    accumLabel.Text = "Accumulated Weeks:";
                    accumValue.Text = "3 Weeks";
                }
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[9];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Fixed Amount
            else if (cbl == 5)
            {
                Grid grd = (Grid)control.Children[8];
                // Change Amount per Claim
                Label amountPerClaim = (Label)grd.Children[1];
                amountPerClaim.Text = "50.00";
                // Change Maximum Amount
                Label maxAmount = (Label)grd.Children[3];
                maxAmount.Text = "600.00";
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Membership Date
            else if (cbl == 6)
            {
                Grid grd = (Grid)control.Children[9];
                // Change Maximum Amount
                Label weeksFromEnrollmentDate = (Label)grd.Children[1];
                weeksFromEnrollmentDate.Text = "5 Weeks";
                // Change Maximum Amount
                Label maxAmount = (Label)grd.Children[3];
                maxAmount.Text = "600.00";
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
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
                Label claimTypeName = (Label)item1.Children[1];
                Grid forAdvanceGrid = (Grid)item1.Children[11];
                Switch forAdvancePanelValue = (Switch)forAdvanceGrid.Children[0];
                Label forAdvancePanel = (Label)forAdvanceGrid.Children[1];
                Label checkForAdvance = (Label)forAdvanceGrid.Children[2];
                setClaimBenefit(claimBenefit, item1);
                claimBenefit++;

                foreach (vwClaimTypes item in control.ItemsSource)
                {
                    if (item.claimTypeName.ToString() == claimTypeName.Text)
                    {
                        if (item.forAdvance == false)
                        {

                            if (checkForAdvance == null) return;
                            if (item.forAdvance.ToString() == checkForAdvance.Text)
                            {
                                if (forAdvancePanel == null) return;
                                //  set for advance panel visible to false
                                forAdvanceGrid.IsVisible = false;
                            }
                        }
                    }
                }
            }
        }

        void OnToggled(object sender, ToggledEventArgs e)
        {
            
            Switch forAdvancePanelValue = (Switch)sender;
            Grid forAdvanceGrid = (Grid)forAdvancePanelValue.Parent;
            Grid parentGrid = (Grid)forAdvanceGrid.Parent;
            TableView advancesList = (TableView)parentGrid.Children[12];
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
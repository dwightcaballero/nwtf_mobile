using nwtf_mobile_bl;
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
      
        public List<vwClaimType> claimTypeList = new List<vwClaimType>();

        public claimTypes()
        {
            dataservices.Database.initializeDB();
            InitializeComponent();
            PopulateClaimTypes();
            AccessControlsInRepeater();

        }

        public void PopulateClaimTypes()
        {
            // Sample Data 
            Guid productUID = Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191");
            string claimantTypeDescription = systemconst.getClaimantDescription(1);
            List<Guid> claimTypeUID = new List<Guid>();
            claimTypeUID.Add(Guid.Parse("3e00abb5-f0cf-458a-8423-84165452bd78"));
            claimTypeUID.Add(Guid.Parse("8451c5ef-e0af-4038-8e39-90fe73ec1bee"));   
            
            claimTypeList = vwClaimType.getClaimTypeSelected(claimTypeUID);

            foreach (vwClaimType claimType in claimTypeList) {
                vwClaimBenefits cblRec = vwClaimBenefits.getClaimBenefitByProductClaimantClaimType(productUID, claimantTypeDescription, claimType.id);
                claimType.claimBenefitUID = cblRec.id;
                claimType.claimBenefit = cblRec.claimBenefitsLimits;
                claimType.claimBenefitName = cblRec.claimBenefitsLimits.ToString();
            }

            claimTypeRepeater.ItemsSource = claimTypeList;
        }
        public IList<vwDisbursementType> listDA { get; private set; }

        public void setDisbursementAdvances()
        {
            listDA = new List<vwDisbursementType>();
            listDA.Add(new vwDisbursementType
            {
                // assuming 1 is final payee
                // assuming 2 is amount type percentage
                disbursementType = 1,
                DisbursementTypeName = "Africa & Asia",
                AmountType = 2,
                PayeeType=3 });

    }
        // Add system constants and replace other values
        public void setClaimBenefit(vwClaimBenefits cblRec, Grid control)
        {
            // LO Provides Amount
            if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.LOProvidesAmount))
            {
                Grid grd = (Grid)control.Children[4];
                // Change Maximum Amount
                Label maxAmount = (Label)grd.Children[3];
                maxAmount.Text = cblRec.maximumAmount.ToString("N2");
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Number of Premiums Paid
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfPremiumsPaid))
            {
                Grid grd = (Grid)control.Children[5];
                // Change Maximum Amount
                Label weeksFromMembershipDate = (Label)grd.Children[1];
                weeksFromMembershipDate.Text = "6 Weeks";
                // Change Maximum Amount
                Label maxAmount = (Label)grd.Children[3];
                maxAmount.Text = cblRec.maximumAmount.ToString("N2");
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Number of Days
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfDays))
            {
                // controls
                Grid grd = (Grid)control.Children[6];
                Label dateFrom = (Label)grd.Children[0];
                Label dateTo = (Label)grd.Children[2];
                DatePicker dateFromVal = (DatePicker)grd.Children[1];
                DatePicker dateToVal = (DatePicker)grd.Children[3];
                Label accumLabel = (Label)grd.Children[4];
                Label accumValue = (Label)grd.Children[5];
                Label maxLabel = (Label)grd.Children[6];
                Label maxValue = (Label)grd.Children[7];
                int maxBasis = cblRec.maximumBasis;
                string maxBasisText = cblRec.maximumBasis.ToString();

                dateFrom.Text = cblRec.dateFrom;
                dateTo.Text = cblRec.dateTo;
                maxLabel.Text = "Remaining " + maxBasisText + ":";
                accumLabel.Text = "Accumulated " + maxBasisText + ":";

                // Maximum Basis - Amount
                if (maxBasis == 1)
                {                 
                    maxValue.Text = cblRec.maximumValue.ToString();
                    accumValue.Text = "15.00";
                }
                // Maximum Basis - Days
                else if (maxBasis == 2)
                {
                    maxValue.Text = cblRec.maximumValue +" "+ maxBasisText;
                    accumValue.Text = "3" +" "+ maxBasisText;
                }
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[9];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Insurer Approved Amount
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.InsurerApprovedAmount))
            {
                Grid grd = (Grid)control.Children[7];
                grd.IsVisible = true;
            }
            // Fixed Amount
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.FixedAmount))
            {
                Grid grd = (Grid)control.Children[8];
                // Change Amount per Claim
                Label amountPerClaim = (Label)grd.Children[1];
                amountPerClaim.Text = "50.00";
                // Change Maximum Amount
                Label maxAmount = (Label)grd.Children[3];
                maxAmount.Text = cblRec.maximumAmount.ToString("N2");
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Number of Weeks
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
            {
                // controls
                Grid grd = (Grid)control.Children[6];
                Label dateFrom = (Label)grd.Children[0];
                Label dateTo = (Label)grd.Children[2];
                DatePicker dateFromVal = (DatePicker)grd.Children[1];
                DatePicker dateToVal = (DatePicker)grd.Children[3];
                Label accumLabel = (Label)grd.Children[4];
                Label accumValue = (Label)grd.Children[5];
                Label maxLabel = (Label)grd.Children[6];
                Label maxValue = (Label)grd.Children[7];
                int maxBasis = cblRec.maximumBasis;
                string maxBasisText = cblRec.maximumBasis.ToString();

                dateFrom.Text = cblRec.dateFrom;
                dateTo.Text = cblRec.dateTo;
                maxLabel.Text = "Remaining " + maxBasisText + ":";
                accumLabel.Text = "Accumulated " + maxBasisText + ":";

                // Maximum Basis - Amount
                if (maxBasis == 1)
                {
                    maxValue.Text = cblRec.maximumValue.ToString();
                    accumValue.Text = "15.00";
                }
                // Maximum Basis - Weeks
                else if (maxBasis == 2)
                {
                    maxValue.Text = cblRec.maximumValue + " " + maxBasisText;
                    accumValue.Text = "3" + " " + maxBasisText;
                }
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[9];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Membership Date
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.MembershipDate))
            {
                Grid grd = (Grid)control.Children[10];
                // Change Enrollment Date
                Label weeksFromEnrollmentDate = (Label)grd.Children[1];
                weeksFromEnrollmentDate.Text = "5 Weeks";
                // Change Maximum Amount
                Label maxAmount = (Label)grd.Children[3];
                maxAmount.Text = cblRec.maximumAmount.ToString("N2");
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }      
        }

        public void AccessControlsInRepeater()
        {
            var control = claimTypeRepeater as RepeaterView;
            if (control == null) return;
          
            foreach (Grid item1 in control.Children)
            {
                Label claimTypeName = (Label)item1.Children[1];
                Label claimBenefit = (Label)item1.Children[1];
                Grid forAdvanceGrid = (Grid)item1.Children[11];
                Switch forAdvancePanelValue = (Switch)forAdvanceGrid.Children[0];
                Label forAdvancePanel = (Label)forAdvanceGrid.Children[1];
                Label checkForAdvance = (Label)forAdvanceGrid.Children[2];

                foreach (vwClaimType item in control.ItemsSource)
                {
                    if (item.claimTypeName.ToString() == claimTypeName.Text)
                    {
                        // Code to get Claim Benefit
                        vwClaimBenefits cblRec = vwClaimBenefits.getClaimBenefitByUID(item.claimBenefitUID);
                        setClaimBenefit(cblRec, item1);
                        if (item.forAdvance == false)
                        {

                            if (checkForAdvance == null) return;
                            if (item.forAdvance.ToString() == checkForAdvance.Text)
                            {
                                if (forAdvancePanel == null) return;
                                //  set for advance panel visible to false
                                forAdvanceGrid.IsVisible = false;
                                // Code to get list of disbursement advances
                             //   setDisbursementAdvances();
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
    }
}
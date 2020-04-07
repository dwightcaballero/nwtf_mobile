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
        public static dto.claimDTO claimdto { get; set; }
        controllers.claimTransaction pcon = new controllers.claimTransaction();

        public static void setClaimDTO(dto.claimDTO value)
        {
            claimdto = value;
        }

        public claimTypes()
        {
            claimdto.claimantType = 1;
            InitializeComponent();
            PopulateClaimTypes(claimdto);
            AccessControlsInRepeater(claimdto);
        }

        public void PopulateClaimTypes(dto.claimDTO claimdto)
        {
            List<vwClaimTypes> claimTypeList = new List<vwClaimTypes>();
            List<Guid> claimTypeUID = new List<Guid>();

            // Uncomment once complete
            // Guid productUID = vwProduct.getUIDByProductID(claimdto.maf.productID);
            // int claimantType = claimdto.claimantType;
            // claimTypeList = claimdto.listClaimType;

            claimTypeList = claimdto.listClaimType;

            int claimantType = 1;
            string claimantTypeDescription = systemconst.getClaimantDescription(claimantType);

            Guid productUID = Guid.Parse("3f87fae8-d287-4ea1-9685-4d22eca8e37d");
            claimTypeUID.Add(Guid.Parse("8451c5ef-e0af-4038-8e39-90fe73ec1bee"));

            claimTypeList = vwClaimTypes.getListClaimTypeSelected(claimTypeUID);

            foreach (vwClaimTypes claimType in claimTypeList)
            {
                vwClaimBenefits cblRec = vwClaimBenefits.getClaimBenefitByProductClaimantClaimType(productUID, claimantTypeDescription, claimType.id);
                claimType.claimBenefitUID = cblRec.id;
                claimType.claimBenefit = cblRec.claimBenefitsLimits;
                claimType.claimBenefitName = systemconst.getCBLDescription(cblRec.claimBenefitsLimits);
            }

            claimTypeRepeater.ItemsSource = claimTypeList;
        }

        public void AccessControlsInRepeater(dto.claimDTO claimdto)
        {
            var control = claimTypeRepeater as RepeaterView;
            if (control == null) return;

            foreach (Grid item1 in control.Children)
            {
                Grid claimTypeGrid = (Grid)item1.Children[0];
                Label claimTypeName = (Label)claimTypeGrid.Children[1];
                Label claimBenefit = (Label)claimTypeGrid.Children[3];
                Grid forAdvanceGrid = (Grid)item1.Children[8];
                CheckBox forAdvancePanelValue = (CheckBox)forAdvanceGrid.Children[0];
                Label forAdvancePanel = (Label)forAdvanceGrid.Children[1];
                Label checkForAdvance = (Label)forAdvanceGrid.Children[2];

                foreach (vwClaimTypes item in control.ItemsSource)
                {
                    if (item.claimTypeName.ToString() == claimTypeName.Text)
                    {
                        // Code to get Claim Benefit
                        vwClaimBenefits cblRec = vwClaimBenefits.getClaimBenefitByUID(item.claimBenefitUID);
                        setClaimBenefit(cblRec, item1);

                        // Code to get list of disbursement advances
                        List<vwDisbursementType> daRec = vwDisbursementType.getAdvancesByClaimTypeID(item.id, claimdto.claimantType);
                        setDisbursementAdvances(daRec, item1);

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

        public void setClaimBenefit(vwClaimBenefits cblRec, Grid control)
        {
            Guid productUID = Guid.Empty;
            Guid claimTypeID = Guid.Empty;
            cblRec.claimBenefitsLimits = 3;
            Grid grd = (Grid)control.Children[cblRec.claimBenefitsLimits];

            // int claimantType = 1;
            // LO Provides Amount
            if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.LOProvidesAmount))
            {
                grd.IsVisible = true;
            }
            // Number of Premiums Paid
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfPremiumsPaid))
            {
                // Change Membership Amount
                Label weeksFromMembershipDate = (Label)grd.Children[1];
                weeksFromMembershipDate.Text = "6 Weeks";
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[3];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Number of Days
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfDays))
            {
                // controls
                Label dateFrom = (Label)grd.Children[0];
                Label dateTo = (Label)grd.Children[2];
                DatePicker dateFromVal = (DatePicker)grd.Children[1];
                DatePicker dateToVal = (DatePicker)grd.Children[3];
                int maxBasis = cblRec.maximumBasis;
                string maxBasisText = cblRec.maximumBasis.ToString();

                dateFrom.Text = cblRec.dateFrom;
                dateTo.Text = cblRec.dateTo;

                // Maximum Basis - Amount
                if (maxBasis == 1)
                {
                }
                // Maximum Basis - Days
                else if (maxBasis == 2)
                {
                }
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Insurer Approved Amount
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.InsurerApprovedAmount))
            {
                grd.IsVisible = true;
            }
            // Fixed Amount
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.FixedAmount))
            {
                // Change Amount per Claim
                Label amountPerClaim = (Label)grd.Children[1];
                amountPerClaim.Text = "50.00";
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[3];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Number of Weeks
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
            {
                // controls
                Label dateFrom = (Label)grd.Children[0];
                Label dateTo = (Label)grd.Children[2];
                DatePicker dateFromVal = (DatePicker)grd.Children[1];
                DatePicker dateToVal = (DatePicker)grd.Children[3];
                int maxBasis = cblRec.maximumBasis;
                string maxBasisText = cblRec.maximumBasis.ToString();

                dateFrom.Text = cblRec.dateFrom;
                dateTo.Text = cblRec.dateTo;

                // Maximum Basis - Amount
                if (maxBasis == 1)
                {
                }
                // Maximum Basis - Weeks
                else if (maxBasis == 2)
                {
                }
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[5];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
            // Membership Date
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.MembershipDate))
            {
                // Change Enrollment Date
                Label weeksFromEnrollmentDate = (Label)grd.Children[1];
                weeksFromEnrollmentDate.Text = "5 Weeks";
                // Change Computed Amount
                Label computedAmount = (Label)grd.Children[3];
                computedAmount.Text = "120.00";
                grd.IsVisible = true;
            }
        }


        public void setDisbursementAdvances(List<vwDisbursementType> daList, Grid control)
        {
            foreach (vwDisbursementType daRec in daList)
            {
                daRec.amountTypeText = systemconst.getAmountTypeDescription(daRec.amountType);
            }
            ListView advancesGrid = (ListView)control.Children[9];
            advancesGrid.ItemsSource = daList;

        }

        public Grid setPayeeType(int payeeType, Grid parentGrid)
        {
            Grid daGrid;
            if (payeeType == Convert.ToInt32(systemconst.payeeType.MemberAsPayee))
            {
                daGrid = (Grid)parentGrid.Children[4];
                Label payeeName = (Label)daGrid.Children[3];
                payeeName.Text = "Rona Melissa Plana";
                return daGrid;
            }
            if (payeeType == Convert.ToInt32(systemconst.payeeType.FromDisbursementPayee) || payeeType == Convert.ToInt32(systemconst.payeeType.FromBranchPersonnel))
            {
                daGrid = (Grid)parentGrid.Children[5];
                return daGrid;
            }
            else if (payeeType == Convert.ToInt32(systemconst.payeeType.FreeText))
            {
                daGrid = (Grid)parentGrid.Children[6];
                return daGrid;
            }
            else if (payeeType == Convert.ToInt32(systemconst.payeeType.AnyDependents))
            {
                daGrid = (Grid)parentGrid.Children[7];
                return daGrid;
            }
            else
            {
                daGrid = new Grid();
                return daGrid;
            }
        }

        private void ForAdvanceCheckboxEvent(object sender, ToggledEventArgs e)
        {

            CheckBox forAdvancePanelValue = (CheckBox)sender;
            Grid forAdvanceGrid = (Grid)forAdvancePanelValue.Parent;
            Grid parentGrid = (Grid)forAdvanceGrid.Parent;
            ListView advancesList = (ListView)parentGrid.Children[9];
            if (forAdvancePanelValue.IsChecked == true)
            {
                advancesList.IsVisible = true;
            }
            else
            {
                advancesList.IsVisible = false;
            }
        }
        private void DACheckboxEvent(object sender, CheckedChangedEventArgs e)
        {
            CheckBox advanceDisbursement = (CheckBox)sender;
            Grid parentGrid = (Grid)advanceDisbursement.Parent;
            Label payeeType = (Label)parentGrid.Children[3];
            Grid daGrid = setPayeeType(Convert.ToInt32(payeeType.Text), parentGrid);

            if (advanceDisbursement.IsChecked == true)
            {
                daGrid.IsVisible = true;
            }
            else
            {
                daGrid.IsVisible = false;
            }
        }
        private void DefaultPayeePickerEvent(object sender, EventArgs e)
        {
            Picker defaultPayee = (Picker)sender;
            Grid parentGrid = (Grid)defaultPayee.Parent;
            int defaultPayeeValue = defaultPayee.SelectedIndex;

            Label payeeName = (Label)parentGrid.Children[3];
            Picker dependentPicker = (Picker)parentGrid.Children[4];
            Entry freeTextName = (Entry)parentGrid.Children[5];
            payeeName.IsVisible = false;
            dependentPicker.IsVisible = false;
            freeTextName.IsVisible = false;

            if (defaultPayeeValue == 0)
            {
                payeeName.IsVisible = true;
                payeeName.Text = claimdto.customer.customerLastName +", "+ claimdto.customer.customerFirstName +" "+ claimdto.customer.customerMiddleName;
            }
            else if (defaultPayeeValue == 1)
            {

                dependentPicker.IsVisible = true;
            }
            else if (defaultPayeeValue == 2)
            {
                freeTextName.IsVisible = true;
            }

        }

        void DateFromPicker(object sender, DateChangedEventArgs args)
        {
            DatePicker dateFrom = (DatePicker)sender;
            Grid parentGrid = (Grid)dateFrom.Parent;
            DatePicker dateTo = (DatePicker)parentGrid.Children[3];
            Grid fullGrid = (Grid)parentGrid.Parent;
            int claimBenefitsLimits = 3;
            Grid grd = (Grid)fullGrid.Children[claimBenefitsLimits];
            Label computedAmount = (Label)grd.Children[5];

            if (dateFrom.Date != null && dateTo.Date != null)
            {
                decimal totalAmount = calculateDays(dateFrom.Date,dateTo.Date);
                computedAmount.Text = totalAmount.ToString();

            }
        }

        void DateToPicker(object sender, DateChangedEventArgs args)
        {
            DatePicker dateTo = (DatePicker)sender;
            Grid parentGrid = (Grid)dateTo.Parent;
            DatePicker dateFrom = (DatePicker)parentGrid.Children[1];
            Grid fullGrid = (Grid)parentGrid.Parent;
            int claimBenefitsLimits = 3;
            Grid grd = (Grid)fullGrid.Children[claimBenefitsLimits];
            Label computedAmount = (Label)grd.Children[5];

            if (dateFrom.Date != null && dateTo.Date != null)
            {
                decimal totalAmount = calculateDays(dateFrom.Date, dateTo.Date);
                computedAmount.Text = totalAmount.ToString();

            }
        }

        public decimal calculateDays(DateTime dateFrom, DateTime dateTo)
        {
            double days = (dateTo - dateFrom).TotalDays;
            // sample data
            decimal amount = Convert.ToDecimal(days * 200);
            return amount;
        }

        public decimal calculateWeeks(DateTime dateFrom, DateTime dateTo)
        {
            double days = (dateTo - dateFrom).TotalDays;
            // sample data
            decimal amount = Convert.ToDecimal(days * 200);
            return amount;
        }

    }
}
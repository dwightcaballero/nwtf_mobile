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

            // Sample data only
            int claimantType = 1;
            Guid productUID = Guid.Parse("3f87fae8-d287-4ea1-9685-4d22eca8e37d");
            claimTypeUID.Add(Guid.Parse("8451c5ef-e0af-4038-8e39-90fe73ec1bee"));
            claimTypeList = vwClaimTypes.getListClaimTypeSelected(claimTypeUID);

            string claimantTypeDescription = systemconst.getClaimantDescription(claimantType);

            // Bind claim benefit to claim type
            foreach (vwClaimTypes claimType in claimTypeList)
            {
                vwClaimBenefits cblRec = vwClaimBenefits.getClaimBenefitByProductClaimantClaimType(productUID, claimantTypeDescription, claimType.id);
                claimType.claimBenefitUID = cblRec.id;
                // Sample data only
                claimType.claimBenefit = 3;
                claimType.claimBenefitName = systemconst.getCBLDescription(3);
                // Uncomment once complete
                // claimType.claimBenefit = cblRec.claimBenefitsLimits;
                // claimType.claimBenefitName = systemconst.getCBLDescription(cblRec.claimBenefitsLimits);
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
                Grid forAdvanceGrid = (Grid)item1.Children[8];
                Label checkForAdvance = (Label)forAdvanceGrid.Children[2];

                foreach (vwClaimTypes item in control.ItemsSource)
                {
                    if (item.claimTypeName.ToString() == claimTypeName.Text)
                    {
                        // Code to get claim benefit
                        vwClaimBenefits cblRec = vwClaimBenefits.getClaimBenefitByUID(item.claimBenefitUID);
                        if (cblRec == null) return;
                        setClaimBenefit(cblRec, item1);

                        // Code to get list of disbursement advances
                        List<vwDisbursementType> daRec = vwDisbursementType.getAdvancesByClaimTypeID(item.id, claimdto.claimantType);
                        if (daRec == null) return;
                        setDisbursementAdvances(daRec, item1);

                        // Set for advance grid visible to false
                        if (item.forAdvance == false)
                        {
                            if (checkForAdvance == null) return;
                            if (item.forAdvance.ToString() == checkForAdvance.Text)
                            {
                                if (forAdvanceGrid == null) return;
                                forAdvanceGrid.IsVisible = false;
                            }
                        }
                    }
                }
            }
        }

        public void setClaimBenefit(vwClaimBenefits cblRec, Grid control)
        {
            // Sample data only
            cblRec.claimBenefitsLimits = 3;
            int weeksValue = 20;
            Grid grd = (Grid)control.Children[cblRec.claimBenefitsLimits];
            grd.IsVisible = true;

            // Premiums Paid
            if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfPremiumsPaid))
            {
                // Get Weeks from Membership Date of Customer to Date
               // decimal weeksValue = pcon.getWeeksfromDate(claimdto.customer.customerMembershipDate, DateTime.Now);
                // Change Membership Amount
                Label weeksFromMembershipDate = (Label)grd.Children[1];
                weeksFromMembershipDate.Text = weeksValue.ToString() + " weeks";
            }
            // Number of Days or Number of Weeks
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfDays) || cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
            {
                // Change Date Labels
                Label dateFrom = (Label)grd.Children[0];
                Label dateTo = (Label)grd.Children[2];
                dateFrom.Text = cblRec.dateFrom;
                dateTo.Text = cblRec.dateTo;
            }
            // Fixed Amount
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.FixedAmount))
            {
                // Change Amount per Claim
                Label amountPerClaim = (Label)grd.Children[1];
                amountPerClaim.Text = cblRec.amount.ToString("N2");
            }
            // Membership Date
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.MembershipDate))
            {
                // Get Weeks from Effective Date to Date
               // decimal weeksValue = pcon.getWeeksfromDate(claimdto.maf.effectiveDate, DateTime.Now);
                // Change Effective Amount
                Label weeksFromEffectiveDate = (Label)grd.Children[1];
                weeksFromEffectiveDate.Text = weeksValue.ToString() + " weeks";
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
            setComputedAmount(parentGrid, dateFrom.Date, dateTo.Date);
        }

        void DateToPicker(object sender, DateChangedEventArgs args)
        {
            DatePicker dateTo = (DatePicker)sender;
            Grid parentGrid = (Grid)dateTo.Parent;
            DatePicker dateFrom = (DatePicker)parentGrid.Children[1];
            setComputedAmount(parentGrid, dateFrom.Date, dateTo.Date);
        }

        public void setComputedAmount(Grid parentGrid, DateTime dateFrom, DateTime dateTo)
        {
            Grid fullGrid = (Grid)parentGrid.Parent;
            Grid claimTypeGrid = (Grid)fullGrid.Children[0];
            Label claimBenefit = (Label)claimTypeGrid.Children[6];
            int cbl = Convert.ToInt32(claimBenefit.Text);
            Grid grd = (Grid)fullGrid.Children[cbl];
            Label computedAmount = (Label)grd.Children[5];

            if (dateFrom != null && dateTo != null)
            {
                if (cbl == Convert.ToInt32(systemconst.cblList.NumberOfDays))
                {
                    decimal totalAmount = pcon.calculateDays(dateFrom, dateTo);
                    computedAmount.Text = totalAmount.ToString("N2");
                }
                else if (cbl == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
                {
                    decimal totalAmount = pcon.calculateWeeks(dateFrom, dateTo);
                    computedAmount.Text = totalAmount.ToString("N2");
                }

            }
        }

    }
}
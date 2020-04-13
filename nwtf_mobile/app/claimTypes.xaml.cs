using nwtf_mobile_bl;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nwtf_mobile.app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class claimTypes : ContentView
    {
        public static dto.claimDTO claimdto { get; set; }
        public static bool checkDateRange { get; set; }
        controllers.claimTransaction pcon = new controllers.claimTransaction();

        public static void setClaimDTO(dto.claimDTO value)
        {
            claimdto = value;
            // Sample Data
            claimdto.branchID = Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e");
        }

        public claimTypes()
        {
            InitializeComponent();
            checkDateRange = false;
            subscribeToAllEvents();
            PopulateRepeater(claimdto);
            AccessControlsInRepeater(claimdto);
        }

        // subscribe to all events in the controller
        void subscribeToAllEvents()
        {
            pcon.showMessage += Pcon_showMessage;
            pcon.loadRepeater += Pcon_loadRepeater;
        }

        // display messages
        void displayMessage(string title, string message, string buttonName)
        {
            App.Current.MainPage.DisplayAlert(title, message, buttonName);
        }


        private void Pcon_showMessage(object sender, (string, string, string) e)
        {
            displayMessage(e.Item1, e.Item2, e.Item3);
        }

        private void PopulateRepeater(dto.claimDTO claimDTO)
        { 
            try
            {
                pcon.getListRepeater(claimdto);
            }
            catch 
            {
                displayMessage("Error", "Claim Benefit Record Was Not Found", "Close");
            }
        }

        private void Pcon_loadRepeater(object sender, List<views.vwClaimTypes> e)
        {
            claimTypeRepeater.ItemsSource = e;
        }

        // User Controls
        public ListView getListViewDA(Grid control)
        {
            ListView advancesGrid = (ListView)control.Children[9];
            return advancesGrid;
        }
        private Grid getGridClaimType(Grid control)
        {
            Grid claimTypeGrid = (Grid)control.Children[0];
            return claimTypeGrid;
        }

        private string getCustomerFullname()
        {
            string customerFullname = claimdto.customer.customerLastName + ", " + claimdto.customer.customerFirstName + " " + claimdto.customer.customerMiddleName;
            return customerFullname;
        }

        public void AccessControlsInRepeater(dto.claimDTO claimdto)
        {
            var control = claimTypeRepeater as RepeaterView;
            if (control == null) return;
            foreach (Grid item1 in control.Children)
            {
                Grid claimTypeGrid = getGridClaimType(item1);
                Label claimTypeName = (Label)claimTypeGrid.Children[1];
                Grid forAdvanceGrid = (Grid)item1.Children[8];
                Label checkForAdvance = (Label)forAdvanceGrid.Children[2];

                foreach (views.vwClaimTypes item in control.ItemsSource)
                {
                    if (item.claimTypeName.ToString() == claimTypeName.Text)
                    {
                        // Code to get claim benefit
                        views.vwClaimBenefits cblRec = views.vwClaimBenefits.getClaimBenefitByUID(item.claimBenefitUID);
                        if (cblRec == null) return;
                        setClaimBenefit(cblRec, item1);

                        // Code to get list of disbursement advances
                        List<views.vwDisbursementType> daRec = views.vwDisbursementType.getAdvancesByClaimTypeID(item.id, claimdto.claimant.claimantType);
                        if (daRec == null) return;
                        setDisbursementAdvances(daRec, item1);

                        // Set for advance grid visible to false
                        if (item.allowAdvances == false)
                        {
                            if (checkForAdvance == null) return;
                            if (item.allowAdvances.ToString() == checkForAdvance.Text)
                            {
                                if (forAdvanceGrid == null) return;
                                forAdvanceGrid.IsVisible = false;
                            }
                        }
                    }
                }
            }
        }

        public void setClaimBenefit(views.vwClaimBenefits cblRec, Grid control)
        {
            Grid grd = (Grid)control.Children[cblRec.claimBenefitsLimits];
            grd.IsVisible = true;
            Decimal amount = Convert.ToDecimal(cblRec.amount);
            // Premiums Paid
            if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfPremiumsPaid))
            {
                // Get Weeks from Membership Date of Customer to Date
                decimal weeksValue = pcon.getWeeksfromDate(claimdto.customer.customerMembershipDate, DateTime.Now, amount);
                // Change Membership Amount
                Label weeksFromMembershipDate = (Label)grd.Children[1];
                weeksFromMembershipDate.Text = weeksValue.ToString() + " weeks";
            }
            // Number of Days or Number of Weeks
            else if (cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfDays) || cblRec.claimBenefitsLimits == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
            {
                grd = (Grid)control.Children[3];
                Grid grd1 = (Grid)control.Children[6];

                // Change Date Labels
                Label dateFrom = (Label)grd.Children[0];
                Label dateTo = (Label)grd.Children[2];
                DatePicker dateFromValue = (DatePicker)grd.Children[1];
                DatePicker dateToValue = (DatePicker)grd.Children[3];

                if (checkDateRange == false)
                {
                    grd1.IsVisible = false;
                    grd.IsVisible = true;
                    checkDateRange = true;
                    dateFrom.Text = cblRec.dateFrom;
                    dateTo.Text = cblRec.dateTo;
                    // Change Amount
                    Label amountText = (Label)grd.Children[7];
                    amountText.Text = amount.ToString("N2");
                }
                else
                {
                    grd1.IsVisible = true;
                    grd.IsVisible = false;
                    dateFromValue.IsVisible = false;
                    dateToValue.IsVisible = false;
                    dateFrom.IsVisible = false;
                    dateTo.IsVisible = false;
                    // Change Amount
                    Label amountText = (Label)grd1.Children[3];
                    amountText.Text = amount.ToString("N2");
                }

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
                decimal weeksValue = pcon.getWeeksfromDate(claimdto.maf.effectiveDate, DateTime.Now, amount);
                // Change Effective Amount
                Label weeksFromEffectiveDate = (Label)grd.Children[1];
                weeksFromEffectiveDate.Text = weeksValue.ToString() + " weeks";
            }
        }

        public void setDisbursementAdvances(List<views.vwDisbursementType> tempDAList, Grid control)
        {
            List<views.vwDisbursementType> DAList = pcon.getListAdvances(tempDAList);
            ListView advancesGrid = getListViewDA(control);
            advancesGrid.ItemsSource = DAList;
        }

        private void ForAdvanceCheckboxEvent(object sender, ToggledEventArgs e)
        {

            CheckBox forAdvancePanelValue = (CheckBox)sender;
            Grid forAdvanceGrid = (Grid)forAdvancePanelValue.Parent;
            Grid parentGrid = (Grid)forAdvanceGrid.Parent;
            ListView advancesList = getListViewDA(parentGrid);
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
            Label amountTypeText = (Label)parentGrid.Children[8];
            int amountType = Convert.ToInt32(amountTypeText.Text);
            ViewCell grandparentGrid = (ViewCell)parentGrid.Parent;
            ListView fullGrid = (ListView)grandparentGrid.Parent;
            Grid fullGrid1 = (Grid)fullGrid.Parent;
            Grid claimTypeGrid = getGridClaimType(fullGrid1);
            Label claimBenefit = (Label)claimTypeGrid.Children[6];
            int cbl = Convert.ToInt32(claimBenefit.Text);

                Grid daGrid = setPayeeType(Convert.ToInt32(payeeType.Text), parentGrid);
                if (advanceDisbursement.IsChecked == true)
                {
                    if (cbl == Convert.ToInt32(systemconst.cblList.InsurerApprovedAmount))
                    {
                        if (amountType == Convert.ToInt32(systemconst.amountType.PercentOfBenefit))
                        {
                            displayMessage("Error", "Advances for Claim Benefit - Insurer Approved Amount with Amount Type - Percent of Benefit cannot be Selected.", "Close");
                            advanceDisbursement.IsChecked = false;
                        }
                    }
                    else
                    {
                            daGrid.IsVisible = true;
                    }
                }               
                else
                {
                    daGrid.IsVisible = false;
                }
            
        }

        public Grid setPayeeType(int payeeType, Grid parentGrid)
        {
            Grid daGrid;
            if (payeeType == Convert.ToInt32(systemconst.payeeType.MemberAsPayee))
            {
                daGrid = (Grid)parentGrid.Children[4];
                Label payeeName = (Label)daGrid.Children[3];
                payeeName.Text = getCustomerFullname();
                return daGrid;
            }
            if (payeeType == Convert.ToInt32(systemconst.payeeType.FromBranchPersonnel))
            {
                daGrid = (Grid)parentGrid.Children[5];
                Picker branchPayeePicker = (Picker)daGrid.Children[1];
                List<views.vwBranchEmployee> branchPayeeList = views.vwBranchEmployee.getListBranchEmployees(claimdto.branchID);
                List<string> branchNames = branchPayeeList.Select(x => x.employeeName).ToList();
                branchPayeePicker.ItemsSource = branchNames;
                return daGrid;
            }
            else if (payeeType == Convert.ToInt32(systemconst.payeeType.FromDisbursementPayee))
            {
                daGrid = (Grid)parentGrid.Children[5];
                Picker disbursePayeePicker = (Picker)daGrid.Children[1];
                List<views.vwDisbursementPayee> disbursePayeeList = views.vwDisbursementPayee.getListDisbursementPayee(claimdto.branchID);
                List<string> DisburseNames = disbursePayeeList.Select(x => x.businessName).ToList();
                disbursePayeePicker.ItemsSource = DisburseNames;
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
                Picker dependentPayeePicker = (Picker)daGrid.Children[1];
                List<views.vwDependent> depList = pcon.getListDependents(claimdto.customer);
                List<string> depNames = depList.Select(x => x.dependentFullName).ToList();
                dependentPayeePicker.ItemsSource = depNames;
                return daGrid;
            }
            else
            {
                daGrid = new Grid();
                return daGrid;
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
                payeeName.Text = getCustomerFullname();
            }
            else if (defaultPayeeValue == 1)
            {
                List<views.vwDependent> depList = pcon.getListDependents(claimdto.customer);
                List<string> depNames = depList.Select(x => x.dependentFullName).ToList();
                dependentPicker.ItemsSource = depNames;
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
            setComputedAmount(fullGrid, dateFrom.Date, dateTo.Date);
        }

        void DateToPicker(object sender, DateChangedEventArgs args)
        {
            DatePicker dateTo = (DatePicker)sender;
            Grid parentGrid = (Grid)dateTo.Parent;
            DatePicker dateFrom = (DatePicker)parentGrid.Children[1];
            Grid fullGrid = (Grid)parentGrid.Parent;
            setComputedAmount(fullGrid, dateFrom.Date, dateTo.Date);
            setAllDateRangeValues(dateFrom.Date, dateTo.Date);
        }

        public void setComputedAmount(Grid parentGrid, DateTime dateFrom, DateTime dateTo)
        {
            Grid claimTypeGrid = getGridClaimType(parentGrid);
            Label claimBenefit = (Label)claimTypeGrid.Children[6];
            int cbl = Convert.ToInt32(claimBenefit.Text);
            Grid grd = (Grid)parentGrid.Children[cbl];
            Label computedAmount = (Label)grd.Children[5];
            Label amountText = (Label)grd.Children[7];
            decimal amount = Convert.ToDecimal(amountText.Text);

            if (dateFrom != null && dateTo != null)
            {
                if (cbl == Convert.ToInt32(systemconst.cblList.NumberOfDays))
                {
                    decimal totalAmount = pcon.calculateDays(dateFrom, dateTo, amount);
                    computedAmount.Text = totalAmount.ToString("N2");
                }
                else if (cbl == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
                {
                    decimal totalAmount = pcon.calculateWeeks(dateFrom, dateTo, amount);
                    computedAmount.Text = totalAmount.ToString("N2");
                }

            }
        }

        public void setAllDateRangeValues(DateTime dateFrom, DateTime dateTo)
        {
            var control = claimTypeRepeater as RepeaterView;
            if (control == null) return;
            foreach (Grid item1 in control.Children)
            {
                Grid claimTypeGrid = getGridClaimType(item1);
                Label claimTypeName = (Label)claimTypeGrid.Children[1];

                foreach (views.vwClaimTypes item in control.ItemsSource)
                {
                    if (item.claimTypeName.ToString() == claimTypeName.Text)
                    {

                        // Set all computed amount
                        if (item.claimBenefit == Convert.ToInt32(systemconst.cblList.NumberOfDays) || item.claimBenefit == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
                        {
                            Grid cblGrid = (Grid)item1.Children[3];
                            Label computedAmount = new Label();
                            Label amountText = new Label();
                            decimal amount;
                            if (cblGrid.IsVisible == true) {
                                computedAmount = (Label)cblGrid.Children[5];
                                amountText = (Label)cblGrid.Children[7];
                                amount = Convert.ToDecimal(amountText.Text);
                            }
                            else
                            {
                                cblGrid = (Grid)item1.Children[6];
                                computedAmount = (Label)cblGrid.Children[1];
                                amountText = (Label)cblGrid.Children[3];
                                amount = Convert.ToDecimal(amountText.Text);
                            }


                            if (dateFrom != null && dateTo != null)
                            {
                                if (item.claimBenefit == Convert.ToInt32(systemconst.cblList.NumberOfDays))
                                {
                                    decimal totalAmount = pcon.calculateDays(dateFrom, dateTo, amount);
                                    computedAmount.Text = totalAmount.ToString("N2");
                                }
                                else if (item.claimBenefit == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
                                {
                                    decimal totalAmount = pcon.calculateWeeks(dateFrom, dateTo, amount);
                                    computedAmount.Text = totalAmount.ToString("N2");
                                }

                            }
                        }
                    }
                }
            }
        }

    }
}
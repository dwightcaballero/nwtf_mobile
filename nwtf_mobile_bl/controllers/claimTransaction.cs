using System;
using System.Collections.Generic;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class controllers
    {
        public class claimTransaction
        {
            public event EventHandler<List<views.vwCustomer>> loadCustomerGrid;
            public event EventHandler<(List<views.vwMafEnrollmentClosure>, views.vwCustomer)> loadMAFGrid;
            public event EventHandler<(List<views.vwClaimant>, views.vwMafEnrollmentClosure)> loadClaimantGrid;
            public event EventHandler<List<views.vwClaimTypes>> loadClaimTypeGrid;
            public event EventHandler<List<views.vwClaimTypes>> saveClaimTypeSelected;
            public event EventHandler<List<views.vwClaimTypes>> loadRepeater;
            public event EventHandler<List<views.vwClaimBenefits>> loadCBL;
            public event EventHandler<views.vwBranchEmployee> loadBranchEmployee;
            public event EventHandler<views.vwDisbursementPayee> loadDisbursementPayee;
            public event EventHandler<views.vwDependent> loadDependent;
            public event EventHandler<views.vwCustomer> loadSpouse;
            public event EventHandler<List<views.vwRequiredDocuments>> loadrequiredDocuments;
            public event EventHandler<List<views.vwRequiredFields>> loadRequiredFields;

            public event EventHandler<(string, string, string)> showMessage;

            public event EventHandler<(string, Guid, Byte[], String)> requiredDocumentChecked;

            public void getListCustomerForGrid()
            {
                loadCustomerGrid?.Invoke(this, views.vwCustomer.getListCustomersForGrid());
            }

            public void getListMAFForGrid(Guid customerID)
            {
                var customer = views.vwCustomer.getCustomerByID(customerID);
                if (customer != null)
                {
                    var listMAF = views.vwMafEnrollmentClosure.getListMAFForGrid(customer.customerID);
                    loadMAFGrid?.Invoke(this, (listMAF, customer));
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "Customer Record Not Found!", "Close"));
                }
            }

            public void getListClaimantForGrid(Guid mafID, views.vwCustomer customer)
            {
                var maf = views.vwMafEnrollmentClosure.getMAFByID(mafID);
                if (maf != null)
                {
                    Guid productUID = views.vwProduct.getUIDByProductID(maf.productID);
                    if (productUID != Guid.Empty)
                    {
                        var listProductClaimantSelected = views.vwProductClaimType.getListClaimantTypeSelected(productUID);
                        if (listProductClaimantSelected.Count > 0)
                        {
                            var listClaimant = views.vwClaimant.getListClaimantForGrid(listProductClaimantSelected, customer);
                            loadClaimantGrid?.Invoke(this, (listClaimant, maf));
                        }
                        else
                        {
                            showMessage?.Invoke(this, ("Error", "No Claimant Selected in Product Configuration!", "Close"));
                        }
                    }
                    else
                    {
                        showMessage?.Invoke(this, ("Error", "MAF Record Not Found!", "Close"));
                    }
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "MAF Record Not Found!", "Close"));
                }
            }

            public void getListClaimTypeForGrid(string productID, int claimantType)
            {
                Guid productUID = views.vwProduct.getUIDByProductID(productID);
                if (productUID != Guid.Empty)
                {
                    var listClaimtypeIDs = views.vwProductClaimType.getLisClaimTypeIDsForGrid(productUID, claimantType);
                    if (listClaimtypeIDs.Count > 0)
                    {
                        var listClaimType = views.vwClaimTypes.getListClaimTypeForGrid(listClaimtypeIDs);
                        loadClaimTypeGrid?.Invoke(this, listClaimType);
                    }
                    else
                    {
                        showMessage?.Invoke(this, ("Error", "Claim Type Records Not Found!", "Close"));
                    }
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "Product or Claimant Record Not Found!", "Close"));
                }
            }

            public void getRequiredDocuments()
            {
                List<views.vwRequiredDocuments> lstRequiredDocuments = views.vwRequiredDocuments.GetRequiredDocuments();
                if (lstRequiredDocuments.Count != 0)
                {
                    loadrequiredDocuments?.Invoke(this, lstRequiredDocuments);
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "No required Documents retrieved!", "Close"));
                }

            }

            public void getListClaimTypeSelected(List<Guid> listClaimTypeIDs)
            {
                var listClaimtype = views.vwClaimTypes.getListClaimTypeSelected(listClaimTypeIDs);
                if (listClaimtype.Count > 0)
                {
                    saveClaimTypeSelected?.Invoke(this, listClaimtype);
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "Claim Type Records Not Found!", "Close"));
                }
            }

            public decimal getWeeksfromDate(DateTime dateFrom, DateTime dateTo, Decimal amount)
            {
                double weeks = (dateTo - dateFrom).TotalDays /7;
                decimal totalAmount = Convert.ToDecimal(weeks) * amount;
                return totalAmount;
            }

            public decimal calculateDays(DateTime dateFrom, DateTime dateTo, Decimal amount)
            {
                TimeSpan daysSpan = dateTo.Subtract(dateFrom);
                int daysSpanValue = Convert.ToInt32(daysSpan.Days);
                decimal days = 0;
                if (daysSpanValue >= 0)
                {
                    days = daysSpanValue;
                }
                decimal finalAmount = days * amount;
                return finalAmount;
            }

            public decimal calculateWeeks(DateTime dateFrom, DateTime dateTo, Decimal amount)
            {
                TimeSpan daysSpan = dateTo.Subtract(dateFrom);
                int daysSpanValue = Convert.ToInt32(daysSpan.Days);
                decimal weeks = 0;
                if (daysSpanValue >= 0)
                {
                    decimal weeksValue = daysSpanValue / 7;
                    weeks = Math.Floor(weeksValue);
                }
                decimal finalAmount = weeks * amount;
                return finalAmount;
            }

            public void getListRepeater(dto.claimDTO claimdto)
            {
                Guid productUID = views.vwProduct.getUIDByProductID(claimdto.maf.productID);
                int claimantType = claimdto.claimant.claimantType;
                string claimantTypeDescription = systemconst.getClaimantDescription(claimantType);

                // Bind claim benefit to claim type
                foreach (views.vwClaimTypes claimType in claimdto.listSelectedClaimType)
                {
                        views.vwClaimBenefits cblRec = views.vwClaimBenefits.getClaimBenefitByProductClaimantClaimType(productUID, claimantTypeDescription, claimType.id);
                        claimType.claimBenefitUID = cblRec.id;
                        claimType.claimBenefit = cblRec.claimBenefitsLimits;
                        claimType.claimBenefitName = systemconst.getCBLDescription(cblRec.claimBenefitsLimits);
                }

                if (claimdto.listSelectedClaimType.Count > 0)
                {
                    loadRepeater?.Invoke(this, claimdto.listSelectedClaimType);
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "Claim Type Records Not Found!", "Close"));
                }
            }

            public void getListCBL(dto.claimDTO claimdto)
            {
                Guid productUID = views.vwProduct.getUIDByProductID(claimdto.maf.productID);
                int claimantType = claimdto.claimant.claimantType;
                string claimantTypeDescription = systemconst.getClaimantDescription(claimantType);

                // Bind claim benefit to claim type
                foreach (views.vwClaimTypes claimType in claimdto.listSelectedClaimType)
                {
                    views.vwClaimBenefits cblRec = views.vwClaimBenefits.getClaimBenefitByProductClaimantClaimType(productUID, claimantTypeDescription, claimType.id);
                    claimdto.listSelectedCTCBL.Add(cblRec);
                }

                if (claimdto.listSelectedCTCBL.Count > 0)
                {
                    loadCBL?.Invoke(this, claimdto.listSelectedCTCBL);
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "Claim Benefit Records Not Found!", "Close"));
                }
            }

            public List<views.vwDisbursementType> getListAdvances(List<views.vwDisbursementType> daList)
            {
                foreach (views.vwDisbursementType daRec in daList)
                {
                    daRec.amountTypeText = systemconst.getAmountTypeDescription(daRec.amountType);
                }
                if (daList.Count > 0)
                {
                    return daList;
                }
                else
                {
                    return null;
                }
            }

            public List<views.vwDependent> getListDependents(views.vwCustomer custRec)
            {
                List<views.vwDependent> depList = views.vwDependent.getListDependentByCustomerUID(custRec.id);
                if (custRec.customerCivilStatus == "102002")
                {
                    views.vwDependent item = new views.vwDependent();
                    item.customerID = custRec.id;
                    item.dependentFullName = (custRec.spouseFirstName + " " + custRec.spouseMiddleName + " " + custRec.spouseLastName);
                    item.dependentBirthdate = custRec.spouseBirthdate.ToString();
                    depList.Add(item);
                }
                if (depList.Count > 0)
                {
                    return depList;
                }
                else
                {
                    return null; 
                }
            }

            public (string,string) checkMultipleDateRanges(List<views.vwClaimTypes> claimTypesSelected)
            {
                int countcbl = 0;
                foreach (var ct in claimTypesSelected)
                {
                    if (ct.claimBenefit == Convert.ToInt32(systemconst.cblList.NumberOfDays)|| ct.claimBenefit == Convert.ToInt32(systemconst.cblList.NumberOfWeeks))
                    {
                        countcbl += 1;
                    }
                }

                if (countcbl > 1){

                    string getDateFrom = views.vwRegistry.getEntry("aggregateDateFrom");
                    string getDateTo = views.vwRegistry.getEntry("aggregateDateTo");
                    return (getDateFrom, getDateTo);
                }
                else
                {
                    return ("", "");
                }
            }

            public void setPayeeDTO(int payeeType, string payeeName, dto.claimDTO claimdto)
            {
                if (payeeType == Convert.ToInt32(systemconst.payeeType.FromBranchPersonnel))
                {
                    List<views.vwBranchEmployee> branchPayeeList = views.vwBranchEmployee.getListBranchEmployees(claimdto.branchID);
                    Dictionary<Guid, string> values = new Dictionary<Guid, string>();

                    foreach (var item in branchPayeeList)
                    {
                        values.Add(item.id, item.employeeName);
                    }
                    var id = values.FirstOrDefault(x => x.Value == payeeName.ToString()).Key;
                    var branchEmpRec = views.vwBranchEmployee.getBranchEmployeeByUID(id);
                    loadBranchEmployee?.Invoke(this, branchEmpRec);
                }
                else if (payeeType == Convert.ToInt32(systemconst.payeeType.FromDisbursementPayee))
                {
                    List<views.vwDisbursementPayee> disbursementPayeeList = views.vwDisbursementPayee.getListDisbursementPayee(claimdto.branchID);
                    Dictionary<Guid, string> values = new Dictionary<Guid, string>();

                    foreach (var item in disbursementPayeeList)
                    {
                        values.Add(item.id, item.businessName);
                    }
                    var id = values.FirstOrDefault(x => x.Value == payeeName.ToString()).Key;
                    var disbursePayeeRec = views.vwDisbursementPayee.getDisbursementPayeeByUID(id);
                    loadDisbursementPayee?.Invoke(this, disbursePayeeRec);
                }
                else if (payeeType == Convert.ToInt32(systemconst.payeeType.AnyDependents))
                {
                    List<views.vwDependent> dependentPayee = getListDependents(claimdto.customer);
                    Dictionary<Guid, string> values = new Dictionary<Guid, string>();

                    foreach (var item in dependentPayee)
                    {
                        values.Add(item.id, item.dependentFullName);
                    }

                    var id = values.FirstOrDefault(x => x.Value == payeeName.ToString()).Key;
                    var depRec = views.vwDependent.getDependentRecByUID(id);
                    if (depRec != null)
                    {
                        loadDependent?.Invoke(this, depRec);
                    }
                    else
                    {
                        var spouseRec = views.vwCustomer.getCustomerByID(id);
                        loadSpouse?.Invoke(this, spouseRec);
                    }
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "No payee data retrieved!", "Close"));
                }
            }
            public void getRequiredFields()
            {
                List<views.vwRequiredFields> lstRequiredFields = views.vwRequiredFields.getRequiredFields();
                if (lstRequiredFields.Count != 0)
                {
                    loadRequiredFields?.Invoke(this, lstRequiredFields);
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "No required fields retrieved!", "Close"));
                }
            }

            public void checkRequiredDocument(String requiredDocumentName, Guid requiredDocumentID, Byte[] requiredDocumentFile, String requiredDocumentDescription)
            {
                if (requiredDocumentFile != null)
                {
                    if(requiredDocumentDescription != null)
                    {
                        requiredDocumentChecked?.Invoke(this, (requiredDocumentName, requiredDocumentID, requiredDocumentFile, requiredDocumentDescription));
                    }
                    else
                    {
                        showMessage?.Invoke(this, ("Error", "There is no description provided!", "Close"));
                    }
                }
                else
                {
                    showMessage?.Invoke(this, ("Error", "No file is uploaded!", "Close"));
                }
            }


        }
    }
}

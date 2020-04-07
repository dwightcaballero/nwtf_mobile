using System;
using System.Collections.Generic;
using System.Text;

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

            public event EventHandler<List<views.vwRequiredDocuments>> loadrequiredDocuments;

            public event EventHandler<(string, string, string)> showMessage;

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
                    showMessage?.Invoke(this,("Error", "Customer Record Not Found!", "Close"));
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
                    showMessage?.Invoke(this, ("Error", "No requied Documents retrieved!", "Close"));
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

            public decimal getWeeksfromDate(DateTime dateFrom, DateTime dateTo)
            {
                double weeks = (dateTo - dateFrom).TotalDays /7;
                decimal totalAmount = Convert.ToDecimal(weeks) * 200;
                return totalAmount;
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
                double weeks = (dateTo - dateFrom).TotalDays / 7;
                // sample data
                decimal amount = Convert.ToDecimal(weeks * 200);
                return amount;
            }         

        }
    }
}

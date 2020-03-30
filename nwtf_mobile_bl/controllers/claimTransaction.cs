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
        }
    }
       
}

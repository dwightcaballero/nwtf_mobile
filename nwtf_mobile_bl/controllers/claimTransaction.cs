using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.controllers
{
    public class claimTransaction
    {
        public List<views.vwCustomer> getListCustomers()
        {
            dataservices.claimTransaction ct = new dataservices.claimTransaction();
            return ct.getListCustomers();
        }
    }
}

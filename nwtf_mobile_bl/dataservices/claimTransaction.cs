using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.dataservices
{
    public class claimTransaction
    {
        public static List<views.vwCustomer> getListCustomers()
        {
            var listCustomers = new List<views.vwCustomer>();
            using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
            {
                string sql = "SELECT dungannonID, customerLastName, customerFirstName, customerMiddleName" +
                             "ORDER BY customerLastName, customerFirstName;";
                listCustomers = conn.Query<views.vwCustomer>(sql);
            }
            return listCustomers;
        }
    }
}

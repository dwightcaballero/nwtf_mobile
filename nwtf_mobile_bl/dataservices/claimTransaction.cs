using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class claimTransaction
        {
            public static views.vwCustomer getCustomerByID(Guid id)
            {
                views.vwCustomer customer = null;
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    customer = conn.Table<views.vwCustomer>().FirstOrDefault(cust => cust.id == id);
                }
                return customer;
            }

            public static List<views.vwCustomer> getListCustomersForGrid()
            {
                List<views.vwCustomer> listCustomers = new List<views.vwCustomer>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT id, dungganonID, customerLastName, customerFirstName, customerMiddleName " +
                                 "FROM vwCustomer " +
                                 "ORDER BY customerLastName, customerFirstName;";
                    listCustomers = conn.Query<views.vwCustomer>(sql);
                }
                return listCustomers;
            }
        }
    }
}

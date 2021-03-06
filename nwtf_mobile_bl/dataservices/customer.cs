﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class customer
        {
            public static views.vwCustomer getCustomerByID(Guid id)
            {
                views.vwCustomer customer = null;
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT * FROM vwCustomer WHERE id='" + id.ToString() + "';";
                    customer = conn.Query<views.vwCustomer>(sql).FirstOrDefault();
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

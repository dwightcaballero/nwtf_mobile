﻿using SQLite;
using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwCustomer
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            [NotNull] public string customerID { get; set; }
            [NotNull] public string dungganonID { get; set; }
            [NotNull] public string customerFirstName { get; set; }
            [NotNull] public string customerMiddleName { get; set; }
            [NotNull] public string customerLastName { get; set; }
            public string customerSuffix { get; set; }
            [NotNull] public DateTime customerBirthdate { get; set; }
            [NotNull] public string customerCivilStatus { get; set; }
            [NotNull] public DateTime customerMembershipDate { get; set; }
            public string spouseID { get; set; }
            public string spouseFirstName { get; set; }
            public string spouseMiddleName { get; set; }
            public string spouseLastName { get; set; }
            public string spouseSuffix { get; set; }
            public DateTime spouseBirthdate { get; set; }
            [NotNull] public string branchCode { get; set; }
            [NotNull] public string blockNo { get; set; }
            [NotNull] public string CenterNo { get; set; }

            public static List<views.vwCustomer> getListCustomersForGrid()
            {
                return dataservices.customer.getListCustomersForGrid();
            }

            public static views.vwCustomer getCustomerByID(Guid id)
            {
                return dataservices.customer.getCustomerByID(id);
            }
        }
    }
}

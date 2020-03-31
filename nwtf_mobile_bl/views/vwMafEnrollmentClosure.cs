﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwMafEnrollmentClosure
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            [NotNull] public string customerID { get; set; }
            [NotNull] public string accountNo { get; set; }
            [NotNull] public string productID { get; set; }
            [NotNull] public DateTime effectiveDate { get; set; }
            public DateTime closingDate { get; set; }
            [NotNull] public Boolean deceased { get; set; }

            // for package selection (listview property)
            public string productName { get; set; }

            public static vwMafEnrollmentClosure getMAFByID(Guid id)
            {
                return dataservices.mafEnrollmentClosure.getMAFByID(id);
            }

            public static List<vwMafEnrollmentClosure> getListMAFForGrid(string customerID)
            {
                return dataservices.mafEnrollmentClosure.getListMAFForGrid(customerID);
            }
        }
    }
}

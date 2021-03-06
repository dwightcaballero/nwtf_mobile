﻿using SQLite;
using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwDisbursementPayee
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            public string businessName { get; set; }
            public string payeeID { get; set; }
            [NotNull] public Guid branchID { get; set; }

            public static List<vwDisbursementPayee> getListDisbursementPayee(Guid branchId)
            {
                return dataservices.disbursementPayee.getListDisbursementPayee(branchId);
            }
            public static vwDisbursementPayee getDisbursementPayeeByUID(Guid disPayUID)
            {
                return dataservices.disbursementPayee.getDisbursementPayeeByUID(disPayUID);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.views
{
    public class vwClaimTransaction
    {
        [PrimaryKey, NotNull] Guid id { get; set; }
        [NotNull] string claimTransactionReferenceNumber { get; set; }
        [NotNull] Guid customerID { get; set; }
        [NotNull] Guid mafID { get; set; }
        [NotNull] string claimantID { get; set; }
        [NotNull] int claimantType { get; set; }
        string defaultPayeeID { get; set; }
        string defaultPayeeName { get; set; }
        int defaultPayeeType { get; set; }
        [NotNull] Guid blockID { get; set; }
        [NotNull] Guid branchID { get; set; }
    }
}

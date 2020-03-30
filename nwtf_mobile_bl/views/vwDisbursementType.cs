using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwDisbursementType
        {
            [PrimaryKey,NotNull]
            public Guid id { get; set; }
            public int disbursementType { get; set; }
            public String DisbursementTypeName { get; set; }
            public int PayeeType { get; set; }
            public int AmountType { get; set; }
            public Double AmountValue { get; set; }
            public Guid claimTypeID { get; set; }
            public Boolean isFinalPayee { get; set; }
            public Guid payeeGUID { get; set; }
            public String payeeID { get; set; }
            public String payeeName { get; set; }
            public String payeeRelation { get; set; }
            public String specialInstruction { get; set; }
            public String typeCode { get; set; }
            public Boolean include { get; set; }
            public String claimTypeClaimTransactionId { get; set; }
            public int claimantType { get; set; }
        }
    }
}

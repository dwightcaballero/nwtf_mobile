using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwClaimBenefits
    {
        [PrimaryKey, NotNull] public Guid id { get; set; }
        [NotNull] public Guid productUID { get; set; }
        public Guid productClaimTypeUID { get; set; }
        public int claimBenefitsLimits { get; set; }
        public int claimantType { get; set; }
        public decimal maximumAmount { get; set; }
        public int maximumBasis { get; set; }
        public decimal maximumValue { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public DateTime dateFromVal { get; set; }
        public DateTime dateToVal { get; set; }
        //Based from the productclaimanttypeclaimbenefits views
        //decimal maximumAmountTemp { get; set; }
        //decimal maximumValueTemp { get; set; }
        //decimal accumulatedAmount { get; set; }
        //decimal accumulatedValue { get; set; }
        //string claimTypeName { get; set; }
        //Guid claimTypeClaimTransactionUID { get; set; }

    }
}

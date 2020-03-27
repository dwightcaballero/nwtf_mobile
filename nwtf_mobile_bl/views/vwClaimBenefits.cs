using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwClaimBenefits
    {
        [PrimaryKey, NotNull] static Guid id { get; set; }
        [NotNull] Guid productUID { get; set; }
        [NotNull] Guid productClaimTypeUID { get; set; }
        [NotNull] int claimBenefitsLimits { get; set; }
        [NotNull] int claimantType { get; set; }
        decimal maximumAmount { get; set; }
        int maximumBasis { get; set; }
        decimal maximumValue { get; set; }
        string dateFrom { get; set; }
        string dateTo { get; set; }
        DateTime dateFromVal { get; set; }
        DateTime dateToVal { get; set; }
        //decimal maximumAmountTemp { get; set; }
        //decimal maximumValueTemp { get; set; }
        //decimal accumulatedAmount { get; set; }
        //decimal accumulatedValue { get; set; }

    }
}

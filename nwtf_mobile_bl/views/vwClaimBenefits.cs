using SQLite;
using System;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwClaimBenefits
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            [NotNull] public Guid productUID { get; set; }
            public Guid productClaimTypeUID { get; set; }
            public int claimBenefitsLimits { get; set; }
            public int claimantType { get; set; }
            public double maximumAmount { get; set; }
            public int maximumBasis { get; set; }
            public double maximumValue { get; set; }
            public string dateFrom { get; set; }
            public string dateTo { get; set; }
            public DateTime dateFromVal { get; set; }
            public DateTime dateToVal { get; set; }
            public double amount { get; set; }
            public double computedAmount { get; set; }
            public decimal maximumAmountTemp { get; set; }
            public decimal maximumValueTemp { get; set; }
            public decimal accumulatedAmount { get; set; }
            public decimal accumulatedValue { get; set; }
            public Guid claimTypeClaimTransactionUID { get; set; }
            public static views.vwClaimBenefits getClaimBenefitByProductClaimantClaimType(Guid productUID, string claimantType, Guid claimTypeUID)
            {
                return dataservices.claimBenefit.getClaimBenefitByProductClaimantClaimType(productUID, claimantType, claimTypeUID);
            }
            public static views.vwClaimBenefits getClaimBenefitByUID(Guid cblUID)
            {
                return dataservices.claimBenefit.getClaimBenefitByUID(cblUID);
            }
        }
    }
}

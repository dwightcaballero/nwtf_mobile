using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwClaimTypes
        {
            [PrimaryKey,NotNull]
            public Guid id {get; set;}
            public String claimTypeName { get; set; }
            public Boolean include { get; set; }
            public String claimTypeCode { get; set; }
            public String claimTypeShortName { get; set; }
            public int claimantType { get; set; }
            public String claimant { get; set; }
            public Boolean allowAdvances { get; set; }
            public String disburseMICTransID { get; set; }
            public String disburseInhouseTransID { get; set; }
            public Decimal amount { get; set; }
            public Boolean forAdvance { get; set; }
            public String comment { get; set; }
            public Guid claimTypeID { get; set; }
            public String finalPayee { get; set; }
            public int claimBenefit { get; set; }
            public string claimBenefitName { get; set; }
            public static List<views.vwClaimTypes> getClaimTypeSelected(List<Guid> claimTypeUID)
            {
                return dataservices.claimType.getClaimTypeSelected(claimTypeUID);
            }
        }

    }
}

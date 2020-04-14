using SQLite;
using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwClaimTypes
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            public string claimTypeName { get; set; }
            public bool include { get; set; }
            public string claimTypeCode { get; set; }
            public string claimTypeShortName { get; set; }
            public int claimantType { get; set; }
            public string claimant { get; set; }
            public bool allowAdvances { get; set; }
            public string disburseMICTransID { get; set; }
            public string disburseInhouseTransID { get; set; }
            public decimal amount { get; set; }
            public bool forAdvance { get; set; }
            public string comment { get; set; }
            public Guid claimTypeID { get; set; }
            public string finalPayee { get; set; }

            // cbl
            public Guid claimBenefitUID { get; set; }
            public int claimBenefit { get; set; }
            public string claimBenefitName { get; set; }

            public static List<vwClaimTypes> getListClaimTypeSelected(List<Guid> claimTypeUID)
            {
                return dataservices.claimType.getListClaimTypeSelected(claimTypeUID);
            }

            public static List<vwClaimTypes> getListClaimTypeForGrid(List<Guid> listClaimTypeIDs)
            {
                return dataservices.claimType.getListClaimTypeForGrid(listClaimTypeIDs);
            }
        }
    }
}

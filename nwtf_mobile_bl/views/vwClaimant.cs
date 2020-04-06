using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwClaimant
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            public Guid customerID { get; set; }
            public string claimantID { get; set; }
            public string claimantFullName { get; set; }
            public DateTime claiamantBirthdate { get; set; }
            public int claimantType { get; set; }
            public string claimantRelation { get; set; }

            public static List<vwClaimant> getListClaimantForGrid(List<string> listProductClaimantSelected, vwCustomer customer, List<vwDependent> listDependent)
            {
                return dataservices.claimant.getListClaimantForGrid(listProductClaimantSelected, customer, listDependent);
            }
        }
    }
}

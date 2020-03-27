using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace nwtf_mobile_bl.views
{
    public class vwClaimant
    {
        [PrimaryKey, NotNull] public Guid id { get; set; }
        public Guid customerID { get; set; }
        public string claimantID { get; set; }
        public string claimantFullName { get; set; }
        public DateTime claiamantBirthdate { get; set; }
        public string claimantType { get; set; }
        public string claimantRelation { get; set; }
    }
}

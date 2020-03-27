using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwClaimant
    {
        Guid id { get; set; }
        Guid customerID { get; set; }
        string claimantID { get; set; }
        string claimantFullName { get; set; }
        DateTime claiamantBirthdate { get; set; }
        string claimantType { get; set; }
        string claimantRelation { get; set; }
    }
}

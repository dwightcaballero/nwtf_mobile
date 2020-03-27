using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.views
{
    public class vwCustomer
    {
        
        [PrimaryKey, NotNull] Guid id { get; set; }
        [NotNull] string customerID { get; set; }
        [NotNull] string dungannonID { get; set; }
        [NotNull] string customerFirstName { get; set; }
        [NotNull] string customerMiddleName { get; set; }
        [NotNull] string customerLasttName { get; set; }
        string customerSuffix { get; set; }
        [NotNull] DateTime customerBirthdate { get; set; }
        [NotNull] string customerCivilStatus { get; set; }
        [NotNull] DateTime customerMembershipDate { get; set; }
        string spouseID { get; set; }
        string spouseFirstName { get; set; }
        string spouseMiddleName { get; set; }
        string spouseLastName { get; set; }
        string spouseSuffix { get; set; }
        DateTime spouseBirthdate { get; set; }
        [NotNull] string branchCode { get; set; }
        [NotNull] string blockNo { get; set; }
        [NotNull] string CenterNo { get; set; }
    }
}

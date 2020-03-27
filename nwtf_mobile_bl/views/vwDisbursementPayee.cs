using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwDisbursementPayee
    {
        [PrimaryKey, NotNull] static Guid id { get; set; }
        [NotNull] string businessName { get; set; }
        [NotNull] string payeeID { get; set; }
        [NotNull] Guid branchID { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwBranchEmployee
    {
        [PrimaryKey, NotNull] static Guid id { get; set; }
        string employeeName { get; set; }
        string payeeID { get; set; }
        [NotNull] Guid branchID { get; set; }
    }
}

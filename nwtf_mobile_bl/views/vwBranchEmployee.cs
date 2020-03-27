using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwBranchEmployee
    {
        [PrimaryKey, NotNull] public Guid id { get; set; } 
        public string employeeName { get; set; }
        public string payeeID { get; set; }
        [NotNull] public Guid branchID { get; set; }
    }
}

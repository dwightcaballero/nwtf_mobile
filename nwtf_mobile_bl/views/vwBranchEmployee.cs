using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwBranchEmployee
        {
            [PrimaryKey, NotNull] public Guid id { get; set; } 
            public string employeeName { get; set; }
            public string payeeID { get; set; }
            [NotNull] public Guid branchID { get; set; }
        }
    }
}

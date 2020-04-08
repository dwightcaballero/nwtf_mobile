using SQLite;
using System;

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

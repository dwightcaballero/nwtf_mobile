using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwDisbursementPayee
    {
        [PrimaryKey, NotNull] public Guid id { get; set; }
        public string businessName { get; set; }
        public string payeeID { get; set; }
        [NotNull] public Guid branchID { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwDisbursementPayee
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            public string businessName { get; set; }
            public string payeeID { get; set; }
            [NotNull] public Guid branchID { get; set; }
        }
    }
}

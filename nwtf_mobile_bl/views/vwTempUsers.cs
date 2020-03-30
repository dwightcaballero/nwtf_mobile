using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwTempUsers
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public String username { get; set; }
            [NotNull]
            public String branchCode { get; set; }
            [NotNull]
            public String blockName { get; set; }

        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwSubgroups
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public String subgroupName { get; set; }
        }
    }
}

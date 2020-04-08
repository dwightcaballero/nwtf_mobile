using SQLite;
using System;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwClaimTypeSubgroup
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public Guid subgroupUID { get; set; }
            [NotNull]
            public Guid claimTypeUID { get; set; }
        }
    }
}

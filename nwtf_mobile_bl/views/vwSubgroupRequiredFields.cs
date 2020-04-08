using SQLite;
using System;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwSubgroupRequiredFields
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public Guid subgroupUID { get; set; }
            [NotNull]
            public Guid requiredFieldUID { get; set; }
        }
    }
}

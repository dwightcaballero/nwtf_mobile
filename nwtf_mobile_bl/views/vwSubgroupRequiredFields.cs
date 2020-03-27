using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
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

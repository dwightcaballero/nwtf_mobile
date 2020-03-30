using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
       public class vwProductClaimType
        {
            [PrimaryKey,NotNull]
            public Guid id { get; set; }
            [NotNull]
            public Guid productUID { get; set; }
            [NotNull]
            public Guid claimTypeUID { get; set; }
            [NotNull]
            public String claimantType { get; set; }
        }
    }
}

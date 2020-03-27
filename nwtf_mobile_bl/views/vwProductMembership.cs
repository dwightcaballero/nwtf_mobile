using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    class vwProductMembership
    {
        [PrimaryKey, NotNull] static Guid id { get; set; }
        [NotNull] Guid productUID { get; set; }
        [NotNull] int fromDays { get; set; }
        [NotNull] int toDays { get; set; }
        [NotNull] decimal amount { get; set; }
    }
}

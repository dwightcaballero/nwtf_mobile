using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    class vwPremiumsPaid
    {
        [PrimaryKey, NotNull] static Guid id { get; set; }
        [NotNull] Guid productUID { get; set; }
        int fromDays { get; set; }
        int toDays { get; set; }
        decimal amount { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    class vwPremiumsPaid
    {
        [PrimaryKey, NotNull] public Guid id { get; set; }
        [NotNull] public Guid productUID { get; set; }
        public int fromDays { get; set; }
        public int toDays { get; set; }
        public decimal amount { get; set; }
    }
}

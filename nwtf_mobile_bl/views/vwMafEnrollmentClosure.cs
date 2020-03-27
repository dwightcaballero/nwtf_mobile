using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.views
{
    public class vwMafEnrollmentClosure
    {
        [PrimaryKey, NotNull] public Guid id { get; set; }
        [NotNull] public string customerID { get; set; }
        [NotNull] public string accountNo { get; set; }
        [NotNull] public string productID { get; set; }
        [NotNull] public DateTime effectiveDate { get; set; }
        public DateTime closingDate { get; set; }
        [NotNull] public Boolean deceased { get; set; }
    }
}

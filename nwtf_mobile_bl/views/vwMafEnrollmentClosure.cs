using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.views
{
    class vwMafEnrollmentClosure
    {
        [PrimaryKey, NotNull] Guid id { get; set; }
        [NotNull] string customerID { get; set; }
        [NotNull] string accountNo { get; set; }
        [NotNull] string productID { get; set; }
        [NotNull] DateTime effectiveDate { get; set; }
        DateTime closingDate { get; set; }
        [NotNull] Boolean deceased { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.views
{
    public class vwProduct
    {
        [PrimaryKey, NotNull] Guid id { get; set; }
        [NotNull] string productID { get; set; }
        [NotNull] string productName { get; set; }
        [NotNull] Boolean generalInsurance { get; set; }
        [NotNull] Boolean inHouseInsurance { get; set; }
        [NotNull] Boolean requireSavingsLoans { get; set; }
        [NotNull] Boolean usableForTransactions { get; set; }
        string status { get; set; }
        DateTime endDate { get; set; }
    }
}

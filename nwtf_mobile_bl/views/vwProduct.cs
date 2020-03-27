using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.views
{
    public class vwProduct
    {
        [PrimaryKey, NotNull] public Guid id { get; set; }
        [NotNull] public string productID { get; set; }
        [NotNull] public string productName { get; set; }
        [NotNull] public Boolean generalInsurance { get; set; }
        [NotNull] public Boolean inHouseInsurance { get; set; }
        [NotNull] public Boolean requireSavingsLoans { get; set; }
        [NotNull] public Boolean usableForTransactions { get; set; }
        public string status { get; set; }
        public DateTime endDate { get; set; }
    }
}

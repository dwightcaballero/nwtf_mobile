using SQLite;
using System;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwCivilStatus
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            public string civilStatusCode { get; set; }
            public string description { get; set; }
            public bool isMarried { get; set; }
            public string status { get; set; }
            public DateTime endDate { get; set; }

            public static bool checkIfCustomerIsMarried(string civilStatusCode)
            {
                return dataservices.civilStatus.checkIfCustomerIsMarried(civilStatusCode);
            }
        }
    }
}

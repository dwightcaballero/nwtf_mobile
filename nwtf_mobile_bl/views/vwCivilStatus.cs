using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwCivilStatus
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            public string civilStatusCode { get; set; }
            public string description { get; set; }
            public Boolean isMarried { get; set; }
            public string status { get; set; }
            public DateTime endDate { get; set; }
        }
    }
}

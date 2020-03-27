using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.views
{
    public class vwCivilStatus
    {
        [PrimaryKey, NotNull] Guid id { get; set; }
        string civilStatusCode { get; set; }
        string description { get; set; }
        Boolean isMarried { get; set; }
        string status { get; set; }
        DateTime endDate { get; set; }
    }
}

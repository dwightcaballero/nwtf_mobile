using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl.views
{
    public class vwDependent
    {
        [PrimaryKey, NotNull] Guid id { get; set; }
        [NotNull] string dependentID { get; set; }
        [NotNull] Guid customerID { get; set; }
        [NotNull] string dependentFullName { get; set; }
        [NotNull] string dependentBirthdate { get; set; }
        [NotNull] string dependentRelationship { get; set; }
    }
}

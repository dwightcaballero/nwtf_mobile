using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwClaimTypeRequiredDocuments
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public Guid requiredDocumentUID { get; set; }
            [NotNull]
            public Guid claimTypeUID { get; set; }
        }
    }
}

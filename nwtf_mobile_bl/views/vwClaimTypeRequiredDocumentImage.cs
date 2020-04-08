using SQLite;
using System;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwClaimTypeRequiredDocumentImage
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            public Guid claimTypeRequiredDocumentID { get; set; }
            public string requiredDocumentImageName { get; set; }
            public string requiredDocumentDescription { get; set; }
            public byte requiredDocumentFile { get; set; }
        }
    }
}

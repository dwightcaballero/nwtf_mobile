using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
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

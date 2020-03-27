using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwClaimTypeRequiredDocumentImage
    {
        Guid id { get; set; }
        Guid claimTypeRequiredDocumentID { get; set; }
        string requiredDocumentImageName { get; set; }
        string requiredDocumentDescription { get; set; }
        byte requiredDocumentFile { get; set; }
    }
}

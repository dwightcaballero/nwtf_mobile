using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwRequiredDocuments
        {
            [PrimaryKey,NotNull]
            public Guid ID { get; set; }
            [NotNull]
            public String requiredDocumentCode { get; set; }
            [NotNull]
            public String requiredDocumentName { get; set; }
            [NotNull]
            public Byte RequiresHardCopy { get; set; }

            public static List<views.vwRequiredDocuments> GetRequiredDocuments()
            {
                return dataservices.requiredDocuments.GetRequiredDocuments();
            }

            public static views.vwRequiredDocuments getRequiredDocumentRecord(Guid id)
            {
                return dataservices.requiredDocuments.GetRequiredDocumentRecord(id);
            }
        }
    }
}

using SQLite;
using System;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwRequiredFields
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public String requiredFieldName { get; set; }
            [NotNull]
            public int requiredFieldType { get; set; }
        }
    }
}

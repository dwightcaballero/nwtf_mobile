using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.views
{
    public class vwRequiredFields
    {
        [PrimaryKey,NotNull]
        public Guid id { get; set; }
        [NotNull]
        public String requiredFieldName { get; set; }
        [NotNull]
        public int requiredFieldType { get; set; }
    }
}

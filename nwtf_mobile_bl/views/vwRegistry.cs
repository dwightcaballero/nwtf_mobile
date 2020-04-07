using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwRegistry
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            public string registry { get; set; }
            public string entry { get; set; }
        }
    }
    
}

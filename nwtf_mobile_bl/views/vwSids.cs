using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
   public partial class views
   {
        public class vwSids
        {

            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public Guid sid { get; set; }
            [NotNull]
            public string authobj { get; set; } //passwordwithsalt
            [NotNull]
            public string authref { get; set; } //salt
        }
    }
}

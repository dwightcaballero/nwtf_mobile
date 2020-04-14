using SQLite;
using System;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwRegistry
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            public string registry { get; set; }
            public string entry { get; set; }

            public static string getEntry(string key)
            {
                return dataservices.registry.GetEntry(key);
            }
        }
    }

}

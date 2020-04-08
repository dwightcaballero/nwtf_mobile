using SQLite;
using System;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwTempUsers
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public String username { get; set; }
            [NotNull]
            public String branchCode { get; set; }
            [NotNull]
            public String blockCode { get; set; }


            public static views.vwTempUsers getUser(String username, String Password)
            {
                return dataservices.sync.GetUser(username, Password);
            }
        }
    }
}

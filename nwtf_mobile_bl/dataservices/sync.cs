using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using nwtf_mobile_bl;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public static class sync
        {
            public static bool GetUser(String username, String Password)
            {
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    var testData = conn.Query<views.vwTempUsers>("SELECT id, username, branchCode, blockCode WHERE username='" + username + "'");
                    if (testData !=null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }

}

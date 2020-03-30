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
                var dbPath = Database.DatabasePath;
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    var testData = conn.Query<views.vwTempUsers>("SELECT id, username, branchCode, blockCode FROM vwTempUsers WHERE username='" + username + "'").FirstOrDefault();
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

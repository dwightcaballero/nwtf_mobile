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
            public static views.vwTempUsers GetUser(String username, String Password)
            {
                views.vwTempUsers tempUser = new views.vwTempUsers();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT id, username, branchCode, blockCode FROM vwTempUsers WHERE username=?";
                    tempUser = conn.Query<views.vwTempUsers>(sql, username).FirstOrDefault();
                  
                    if (tempUser == null || tempUser.username != username)
                    {
                        return tempUser;
                    }
                    else
                    {
                        return tempUser;
                    }
                }
            }
        }
    }

}

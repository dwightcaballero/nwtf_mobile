using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class dataservices{
        public static class sids
        {
            public static views.vwSids getSID(Guid uid)
            {
                views.vwSids pRec = new views.vwSids();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT id, sid, authobj, authref FROM vwSids WHERE sid=?";
                    pRec = conn.Query<views.vwSids>(sql, uid).FirstOrDefault();

                    if (pRec == null)
                    {
                        return pRec;
                    }
                    else
                    {
                        return pRec;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class mafEnrollmentClosure
        {
            public static List<views.vwMafEnrollmentClosure> getListMAFForGrid(string customerID)
            {
                List<views.vwMafEnrollmentClosure> listMAF = new List<views.vwMafEnrollmentClosure>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "";
                    listMAF = conn.Query<views.vwMafEnrollmentClosure>(sql);
                }
                return listMAF;
            }
        }
    }
}

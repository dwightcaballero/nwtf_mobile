using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class disbursementPayee
        {
            public static List<views.vwDisbursementPayee> getListDisbursementPayee(Guid branchId)
            {
                List<views.vwDisbursementPayee> listDisbursementPayee = new List<views.vwDisbursementPayee>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT * FROM vwDisbursementPayee WHERE branchID='" + branchId + "';";
                    listDisbursementPayee = conn.Query<views.vwDisbursementPayee>(sql);

                }
                return listDisbursementPayee;
            }
        }
    }
}

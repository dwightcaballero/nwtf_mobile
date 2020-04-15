using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
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
            public static views.vwDisbursementPayee getDisbursementPayeeByUID(Guid disPayUID)
            {
                views.vwDisbursementPayee disbursementPayee = new views.vwDisbursementPayee();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT * FROM vwDisbursementPayee WHERE id='" + disPayUID.ToString() + "';";
                    disbursementPayee = conn.Query<views.vwDisbursementPayee>(sql).FirstOrDefault();
                }
                return disbursementPayee;
            }
        }
    }
}

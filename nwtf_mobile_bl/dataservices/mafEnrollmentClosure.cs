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
                    var tempMAF = conn.Table<views.vwMafEnrollmentClosure>().ToList();
                    var tempProd = conn.Table<views.vwProduct>();

                    // update query
                    string sql = "SELECT m.id, m.productID, p.productName, m.effectiveDate, m.closingDate " +
                                 "FROM vwMafEnrollmentClosure as m " +
                                 "JOIN vwProduct as p ON m.productID = p.productID " +
                                 "WHERE m.customerID = '" + customerID + "' " + 
                                 "ORDER BY p.productName;";
                    listMAF = conn.Query<views.vwMafEnrollmentClosure>(sql);
                }
                return listMAF;
            }
        }
    }
}

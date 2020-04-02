using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class mafEnrollmentClosure
        {

            public static views.vwMafEnrollmentClosure getMAFByID(Guid id)
            {
                views.vwMafEnrollmentClosure maf = null;
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT m.id, m.customerID, m.accountNo, m.productID, m.effectiveDate, " +
                                        "m.closingDate, m.deceased, p.productName " +
                                  "FROM vwMafEnrollmentClosure as m " +
                                  "INNER JOIN vwProduct as p ON m.productID = p.productID " +
                                  "WHERE m.id= '" + id.ToString() + "' ;";
                    maf = conn.Query<views.vwMafEnrollmentClosure>(sql).FirstOrDefault();
                }
                return maf;
            }

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
                                 "INNER JOIN vwProduct as p ON m.productID = p.productID " +
                                 "WHERE m.customerID = '" + customerID + "' " + 
                                 "ORDER BY p.productName;";
                    listMAF = conn.Query<views.vwMafEnrollmentClosure>(sql);
                }
                return listMAF;
            }
        }
    }
}

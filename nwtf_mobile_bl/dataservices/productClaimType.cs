using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class productClaimType
        {
            public static List<Guid> getListClaimTypeIDsForGrid(Guid productUID, int claimantType)
            {
                var listClaimTypeIDs = new List<Guid>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT claimTypeUID FROM vwProductClaimType " +
                                 "WHERE productUID='" + productUID.ToString() + "' " +
                                 "AND claimantType='" + systemconst.getClaimantDescription(claimantType) + "';";
                    var listTemp = conn.Query<views.vwProductClaimType>(sql);

                    listClaimTypeIDs = (from temp in listTemp select temp.id).ToList();
                }
                return listClaimTypeIDs;
            }
        }
    }

}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

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

                    listClaimTypeIDs = (from temp in listTemp select temp.claimTypeUID).ToList();
                }
                return listClaimTypeIDs;
            }

            public static List<string> getListClaimantTypeSelected(Guid productUID)
            {
                var listClaimantType = new List<string>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT claimantType FROM vwProductClaimType WHERE productUID='" + productUID.ToString() + "';";
                    var listTemp = conn.Query<views.vwProductClaimType>(sql);

                    listClaimantType = (from temp in listTemp select temp.claimantType).ToList();
                }
                return listClaimantType;
            }
        }
    }

}

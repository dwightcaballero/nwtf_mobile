using SQLite;
using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class claimType
        {
            public static List<views.vwClaimTypes> getListClaimTypeSelected(List<Guid> listClaimTypeIDs)
            {
                List<views.vwClaimTypes> listClaimTypes = new List<views.vwClaimTypes>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT * FROM vwClaimTypes WHERE (" + systool.buildOR(listClaimTypeIDs, "id") + ");";
                    listClaimTypes = conn.Query<views.vwClaimTypes>(sql);
                }
                return listClaimTypes;
            }

            public static List<views.vwClaimTypes> getListClaimTypeForGrid(List<Guid> listClaimTypeIDs)
            {
                var listClaimType = new List<views.vwClaimTypes>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT id, claimTypeCode, claimTypeName, claimTypeShortName FROM vwClaimTypes " +
                                 "WHERE (" + systool.buildOR(listClaimTypeIDs, "id") + ") ORDER BY claimTypeName;";
                    listClaimType = conn.Query<views.vwClaimTypes>(sql);
                }
                return listClaimType;
            }
        }
    }
}

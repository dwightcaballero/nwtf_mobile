using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class claimType
        {
            public static List<views.vwClaimType> getListClaimTypeForGrid(List<Guid> listClaimTypeIDs)
            {
                var listClaimType = new List<views.vwClaimType>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT id, claimTypeCode, claimTypeName, claimTypeShortName FROM vwClaimTypes " +
                                 "WHERE (" + systool.buildOR(listClaimTypeIDs, "id") + ");";
                    listClaimType = conn.Query<views.vwClaimType>(sql);
                }
                return listClaimType;
            }
        }
    }

}

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
            public static List<views.vwClaimType> getClaimTypeSelected(List<Guid> claimTypeUIDList)
            {
                List<views.vwClaimType> listClaimTypes = new List<views.vwClaimType>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    // use build or instead of foreach
                    foreach (Guid claimTypeUID in claimTypeUIDList)
                    {
                        // query to get claimtype data
                        string sql = "SELECT * FROM vwClaimType WHERE id='" + claimTypeUID.ToString() + "';";
                        List<views.vwClaimType> item = conn.Query<views.vwClaimType>(sql);
                        listClaimTypes.AddRange(item);
                    }
                }
                return listClaimTypes;
            }

            public static List<views.vwClaimType> getListClaimTypeForGrid(List<Guid> listClaimTypeIDs)
            {
                var listClaimType = new List<views.vwClaimType>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT id, claimTypeCode, claimTypeName, claimTypeShortName FROM vwClaimType " +
                                 "WHERE (" + systool.buildOR(listClaimTypeIDs, "id") + ");";
                    listClaimType = conn.Query<views.vwClaimType>(sql);
                }
                return listClaimType;
            }
        }
    }
}

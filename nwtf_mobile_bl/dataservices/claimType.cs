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
            public static List<views.vwClaimTypes> getClaimTypeSelected(List<Guid> claimTypeUIDList)
            {
                List<views.vwClaimTypes> listClaimTypes = new List<views.vwClaimTypes>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    // use build or instead of foreach
                    foreach (Guid claimTypeUID in claimTypeUIDList)
                    {
                        // query to get claimtype data
                        string sql = "SELECT * FROM vwClaimTypes WHERE id='" + claimTypeUID.ToString() + "';";
                        List<views.vwClaimTypes> item = conn.Query<views.vwClaimTypes>(sql);
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
                    string sql = "SELECT id, claimTypeCode, claimTypeName, claimTypeShortName FROM vwClaimTypes " +
                                 "WHERE (" + systool.buildOR(listClaimTypeIDs, "id") + ");";
                    listClaimType = conn.Query<views.vwClaimType>(sql);
                }
                return listClaimType;
            }
        }
    }
}

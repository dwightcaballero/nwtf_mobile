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
            public static List<views.vwClaimTypes> getClaimTypeSelected(List<Guid> claimTypeUID)
            {
                List<views.vwClaimTypes> listClaimTypes = new List<views.vwClaimTypes>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    // use build or instead of foreach
                    foreach (Guid ct in claimTypeUID)
                    {
                        string sql = "SELECT * FROM vwClaimTypes WHERE id='" + ct.ToString() + "';";
                        List<views.vwClaimTypes> item = conn.Query<views.vwClaimTypes>(sql);
                        listClaimTypes.AddRange(item);
                    }
                }
                return listClaimTypes;
            }
        }
    }
}

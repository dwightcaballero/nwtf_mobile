using SQLite;
using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class disbursementType
        {
            public static List<views.vwDisbursementType> getAdvancesByClaimTypeID(Guid claimTypeUID, int claimantType)
            {
                List<views.vwDisbursementType> listAdvances = new List<views.vwDisbursementType>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    // use build or instead of foreach
                    // query to get claimtype data
                    string sql = "SELECT * FROM vwDisbursementType WHERE claimTypeID='" + claimTypeUID.ToString() + "' and claimantType='" + claimantType + "';";
                    List<views.vwDisbursementType> item = conn.Query<views.vwDisbursementType>(sql);
                    listAdvances.AddRange(item);

                }
                return listAdvances;
            }

        }
    }
}

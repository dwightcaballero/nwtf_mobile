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
                        string sql = "SELECT * FROM vwDisbursementType WHERE claimTypeID='" + claimTypeUID.ToString() + "' and claimantType='"+ claimantType +"';";
                        listAdvances = conn.Query<views.vwDisbursementType>(sql);
                    
                }
                return listAdvances;
            }

        }
    }
}

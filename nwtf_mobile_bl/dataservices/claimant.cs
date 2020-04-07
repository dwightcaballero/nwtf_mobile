using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class claimant
        {
            public static List<views.vwClaimant> getListClaimantForGrid(List<string> listProductClaimantSelected, views.vwCustomer customer, List<views.vwDependent> listDependent)
            {
                List<views.vwClaimant> listClaimant = new List<views.vwClaimant>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    
                    string sql = "";
                    listClaimant = conn.Query<views.vwClaimant>(sql);
                }
                return listClaimant;
            }
        }
    }

}

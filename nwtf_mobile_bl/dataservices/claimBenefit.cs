using SQLite;
using System;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class claimBenefit
        {
            public static views.vwClaimBenefits getClaimBenefitByProductClaimantClaimType(Guid productUID, string claimantType, Guid claimTypeUID)
            {
                views.vwProductClaimType pctRec = new views.vwProductClaimType();
                views.vwClaimBenefits cblRec = new views.vwClaimBenefits();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    // query to get productclaimtype  
                    string getPCT = "SELECT * FROM vwProductClaimType WHERE productUID='" + productUID.ToString() + "' and claimantType='" + claimantType + "' and claimTypeUID='" + claimTypeUID.ToString() + "';";
                    pctRec = conn.Query<views.vwProductClaimType>(getPCT).FirstOrDefault();
                    if (pctRec == null) return cblRec;
                    string getCBLrec = "SELECT * FROM vwClaimBenefits WHERE productClaimTypeUID='" + pctRec.id.ToString() + "';";
                    cblRec = conn.Query<views.vwClaimBenefits>(getCBLrec).FirstOrDefault();

                }
                return cblRec;
            }
            public static views.vwClaimBenefits getClaimBenefitByUID(Guid cblUID)
            {
                views.vwClaimBenefits cblRec = new views.vwClaimBenefits();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string getCBLrec = "SELECT * FROM vwClaimBenefits WHERE id='" + cblUID.ToString() + "';";
                    cblRec = conn.Query<views.vwClaimBenefits>(getCBLrec).FirstOrDefault();

                }
                return cblRec;
            }
        }
    }
}

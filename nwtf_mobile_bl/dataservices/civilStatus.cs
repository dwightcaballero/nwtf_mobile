using SQLite;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class civilStatus
        {
            public static bool checkIfCustomerIsMarried(string civilStatusCode)
            {
                bool isMarried = false;
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT isMarried FROM vwCivilStatus WHERE civilStatusCode='" + civilStatusCode + "';";
                    var temp = conn.Query<views.vwCivilStatus>(sql).FirstOrDefault();
                    isMarried = temp.isMarried;
                }
                return isMarried;
            }
        }
    }

}

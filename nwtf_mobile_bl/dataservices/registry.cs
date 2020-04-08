using SQLite;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class registry
        {
            public static string GetEntry(string key)
            {
                string entry = "";
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT entry FROM vwRegistry WHERE registry='" + key + "';";
                    var temp = conn.Query<views.vwRegistry>(sql).FirstOrDefault();
                    entry = temp.entry;
                }
                return entry;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class product
        {
            public static Guid getUIDByProductID(string productID)
            {
                Guid id = Guid.Empty;
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT id FROM vwProduct WHERE productID='" + productID + "';";
                    var product = conn.Query<views.vwProduct>(sql).FirstOrDefault();
                    id = product.id;
                }
                return id;
            }
        }
    }
}

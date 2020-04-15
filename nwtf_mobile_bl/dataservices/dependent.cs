using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class dependent
        {
            public static List<views.vwDependent> getListDependentByCustomerUID(Guid customerUID)
            {
                var listDependents = new List<views.vwDependent>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT * FROM vwDependent WHERE customerID='" + customerUID.ToString() + "';";
                    listDependents = conn.Query<views.vwDependent>(sql);
                }
                return listDependents;
            }
            public static views.vwDependent getDependentRecByUID(Guid dependentUID)
            {
                var listDependents = new views.vwDependent();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT * FROM vwDependent WHERE id='" + dependentUID.ToString() + "';";
                    listDependents = conn.Query<views.vwDependent>(sql).FirstOrDefault();
                }
                return listDependents;
            }
        }
    }
}

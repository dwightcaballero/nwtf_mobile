using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class requiredFields
        {
            public static List<views.vwRequiredFields> GetRequiredFields()
            {
                List<views.vwRequiredFields> listRequiredFields = new List<views.vwRequiredFields>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT id, requiredFieldName, requiredFieldType FROM vwRequiredFields";
                    listRequiredFields = conn.Query<views.vwRequiredFields>(sql).ToList<views.vwRequiredFields>();

                    if (listRequiredFields.Count == 0)
                    {
                        return listRequiredFields = null;
                    }
                    else
                    {
                        return listRequiredFields;
                    }
                }
            }
        }
    }
}

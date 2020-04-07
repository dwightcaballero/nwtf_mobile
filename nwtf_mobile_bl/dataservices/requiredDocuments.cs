using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public static class requiredDocuments
        {
            public static List<views.vwRequiredDocuments> GetRequiredDocuments()
            {
                List<views.vwRequiredDocuments> listRequiredDocuments = new List< views.vwRequiredDocuments>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT ID, requiredDocumentCode, requiredDocumentName FROM vwRequiredDocuments";
                    listRequiredDocuments = conn.Query<views.vwRequiredDocuments>(sql);

                    if (listRequiredDocuments.Count == 0)
                    {
                        return listRequiredDocuments = null;
                    }
                    else
                    {
                        return listRequiredDocuments;
                    }
                }
            }
        }
    }
}

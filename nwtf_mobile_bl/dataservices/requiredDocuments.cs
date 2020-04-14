using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public static class requiredDocuments
        {
            public static List<views.vwRequiredDocuments> GetRequiredDocuments()
            {
                List<views.vwRequiredDocuments> listRequiredDocuments = new List<views.vwRequiredDocuments>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT ID, requiredDocumentCode, requiredDocumentName FROM vwRequiredDocuments";
                    listRequiredDocuments = conn.Query<views.vwRequiredDocuments>(sql).ToList<views.vwRequiredDocuments>();

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

            public static views.vwRequiredDocuments GetRequiredDocumentRecord(Guid id)
            {
                views.vwRequiredDocuments record = new views.vwRequiredDocuments();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT ID, requiredDocumentCode, requiredDocumentName FROM vwRequiredDocuments where id=?;";
                    record = conn.Query<views.vwRequiredDocuments>(sql, id).FirstOrDefault();

                    if (record == null)
                    {
                        return record = null;
                    }
                    else
                    {
                        return record;
                    }
                }
            }
        }
    }
}

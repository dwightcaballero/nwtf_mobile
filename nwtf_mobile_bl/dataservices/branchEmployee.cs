using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class branchEmployee
        {
            public static List<views.vwBranchEmployee> getListBranchEmployees(Guid branchId)
            {
                List<views.vwBranchEmployee> listBranchEmployees = new List<views.vwBranchEmployee>();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT * FROM vwBranchEmployee WHERE branchID='" + branchId.ToString() + "';";
                    listBranchEmployees = conn.Query<views.vwBranchEmployee>(sql);
                }
                return listBranchEmployees;
            }
            public static views.vwBranchEmployee getBranchEmployeeByUID(Guid branchEmpUID)
            {
                views.vwBranchEmployee branchEmployee = new views.vwBranchEmployee();
                using (SQLiteConnection conn = new SQLiteConnection(Database.DatabasePath))
                {
                    string sql = "SELECT * FROM vwBranchEmployee WHERE id='" + branchEmpUID.ToString() + "';";
                    branchEmployee = conn.Query<views.vwBranchEmployee>(sql).FirstOrDefault();
                }
                return branchEmployee;
            }
        }
    }
}

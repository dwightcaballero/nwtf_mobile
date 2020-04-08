using SQLite;
using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwBranchEmployee
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            public string employeeName { get; set; }
            public string payeeID { get; set; }
            [NotNull] public Guid branchID { get; set; }

            public static List<vwBranchEmployee> getListBranchEmployees(Guid branchId)
            {
                return dataservices.branchEmployee.getListBranchEmployees(branchId);
            }
        }
    }
}

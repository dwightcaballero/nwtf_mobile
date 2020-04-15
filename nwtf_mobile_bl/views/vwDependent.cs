using SQLite;
using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwDependent
        {
            [PrimaryKey, NotNull] public Guid id { get; set; }
            [NotNull] public string dependentID { get; set; }
            [NotNull] public Guid customerID { get; set; }
            [NotNull] public string dependentFullName { get; set; }
            [NotNull] public string dependentBirthdate { get; set; }
            [NotNull] public string dependentRelationship { get; set; }

            public static List<vwDependent> getListDependentByCustomerUID(Guid customerUID)
            {
                return dataservices.dependent.getListDependentByCustomerUID(customerUID);
            }
            public static vwDependent getDependentRecByUID(Guid dependentUID)
            {
                return dataservices.dependent.getDependentRecByUID(dependentUID);
            }
        }
    }
}

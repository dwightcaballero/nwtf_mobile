using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public class systool
    {
        public static string buildOR(List<Guid> listIDs, string fieldName)
        {
            if (listIDs.Count == 0)
            {
                return " 1=0";
            }

            StringBuilder sql = new StringBuilder();
            foreach (Guid ID in listIDs)
            {
                if (!string.IsNullOrEmpty(sql.ToString()))
                {
                    sql.Append(" or ");
                }

                sql.Append(fieldName);
                sql.Append("='");
                sql.Append(ID.ToString());
                sql.Append("' ");
            }

            return sql.ToString();
        }

        public static int calculateAge(DateTime birthdate)
        {
            int age = 0;
            age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.DayOfYear < birthdate.DayOfYear) age -= 1;

            return age;
        }
    }
}

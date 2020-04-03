using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl
{
    public class systemconst
    {
        public enum claimant
        {
            Member = 1,
            SecondaryAssured = 2,
            LegalDependent = 3
        }

        public static string getClaimantDescription(int i)
        {
            switch (i)
            {
                case 1:
                    return "Member";
                case 2:
                    return "Secondary Assured";
                case 3:
                    return "Legal Dependent";
                default:
                    return "";
            }
        }

        public static int getClaimantNumber(string s)
        {
            switch (s)
            {
                case "Member":
                    return 1;
                case "Secondary Assured":
                    return 2;
                case "Legal Dependent":
                    return 3;
                default:
                    return 0;
            }
        }

    }
}

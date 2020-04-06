﻿using System;
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

        public enum cblList
        {
            LOProvidesAmount = 1,
            NumberOfPremiumsPaid = 2,
            NumberOfDays = 3,
            InsurerApprovedAmount = 4,
            FixedAmount = 5,
            NumberOfWeeks = 6,
            MembershipDate = 7
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

        public static string getCBLDescription(int i)
        {
            switch (i)
            {
                case 1:
                    return "LO Provides Amount";
                case 2:
                    return "Number Of Premiums Paid";
                case 3:
                    return "Number Of Days";
                case 4:
                    return "Insurer Approved Amount";
                case 5:
                    return "Fixed Amount";
                case 6:
                    return "Number Of Weeks";
                case 7:
                    return "Membership Date";
                default:
                    return "";
            }
        }
        public static int getCBLNumber(string s)
        {
            switch (s)
            {
                case "LO Provides Amount":
                    return 1;
                case "Number Of Premiums Paid":
                    return 2;
                case "Number Of Days":
                    return 3;
                case "Insurer Approved Amount":
                    return 4;
                case "Fixed Amount":
                    return 5;
                case "Number Of Weeks":
                    return 6;
                case "Membership Date":
                    return 7;
                default:
                    return 0;
            }
        }
    }

}

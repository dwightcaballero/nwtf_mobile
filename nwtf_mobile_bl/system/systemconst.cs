namespace nwtf_mobile_bl
{
    public class systemconst
    {

        public static string Relation_Father = "FATHER";
        public static string Relation_Mother = "MOTHER";
        public static string Relation_Child = "CHILD";

        public enum claimant
        {
            Member = 1,
            SecondaryAssured = 2,
            LegalDependent = 3
        }

        public enum payeeType
        {
            MemberAsPayee = 1,
            FromDisbursementPayee = 2,
            FromBranchPersonnel = 3,
            FreeText = 4,
            AnyDependents = 5
        }

        public enum amountType
        {
            FixedAmount = 1,
            PercentOfBenefit = 2
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

        public static string getPayeeTypeDescription(int i)
        {
            switch (i)
            {
                case 1:
                    return "Member As Payee";
                case 2:
                    return "From Disbursement Payee";
                case 3:
                    return "From Branch Personnel";
                case 4:
                    return "Free Text";
                case 5:
                    return "Any Dependents";
                default:
                    return "";
            }
        }

        public static int getPayeeTypeInteger(string s)
        {
            switch (s)
            {
                case "Member As Payee":
                    return 1;
                case "From Disbursement Payee":
                    return 2;
                case "From Branch Personnel":
                    return 3;
                case "Free Text":
                    return 4;
                case "Any Dependents":
                    return 5;
                default:
                    return 0;
            }
        }

        public static string getAmountTypeDescription(int i)
        {
            switch (i)
            {
                case 1:
                    return "Fixed Amount";
                case 2:
                    return "Percent of Benefit";
                default:
                    return "";
            }
        }

        public static int getAmountTypeNumber(string s)
        {
            switch (s)
            {
                case "Fixed Amount":
                    return 1;
                case "Percent of Benefit":
                    return 2;
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

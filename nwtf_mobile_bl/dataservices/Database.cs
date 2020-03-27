using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace nwtf_mobile_bl.dataservices
{
    public static class Database
    {
        public const string DatabaseFilename = "nwtf_mobile.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        // one-time initialization
        public static void initializeDB()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DatabasePath))
            {
                // create tables
                conn.CreateTable<views.vwBranchEmployee>();
                conn.CreateTable<views.vwCivilStatus>();
                conn.CreateTable<views.vwClaimBenefits>();
                conn.CreateTable<views.vwClaimTypeRequiredDocuments>();
                conn.CreateTable<views.vwClaimTypes>();
                conn.CreateTable<views.vwClaimTypeSubgroup>();
                conn.CreateTable<views.vwCustomer>();
                conn.CreateTable<views.vwDependent>();
                conn.CreateTable<views.vwDisbursementPayee>();
                conn.CreateTable<views.vwDisbursementType>();
                conn.CreateTable<views.vwMafEnrollmentClosure>();
                conn.CreateTable<views.vwPremiumsPaid>();
                conn.CreateTable<views.vwProduct>();
                conn.CreateTable<views.vwProductClaimType>();
                conn.CreateTable<views.vwProductMembership>();
                conn.CreateTable<views.vwRequiredDocuments>();
                conn.CreateTable<views.vwRequiredFields>();
                conn.CreateTable<views.vwSubgroupRequiredFields>();
                conn.CreateTable<views.vwSubgroups>();
                conn.CreateTable<views.vwTempUsers>();

                // populate tables
                var listBranchEmployees = new List<views.vwBranchEmployee>
                {
                    new views.vwBranchEmployee{id=Guid.NewGuid(), branchID=Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e"), payeeID="123", employeeName="Sheena Halog"},
                    new views.vwBranchEmployee{id=Guid.NewGuid(), branchID=Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e"), payeeID="456", employeeName="Shiendeeh Socorro"},
                    new views.vwBranchEmployee{id=Guid.NewGuid(), branchID=Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e"), payeeID="789", employeeName="Mary Adorable"}
                };
                conn.InsertAll(listBranchEmployees);

                var listCivilStatus = new List<views.vwCivilStatus>
                {
                    new views.vwCivilStatus{id=Guid.NewGuid(), civilStatusCode="102001", description="Single", endDate=new DateTime(2014, 6, 1), isMarried=false, status="Active"},
                    new views.vwCivilStatus{id=Guid.NewGuid(), civilStatusCode="102002", description="Married", endDate=new DateTime(2014, 6, 1), isMarried=true, status="Active"}
                };
                conn.InsertAll(listCivilStatus);

                var listCustomer = new List<views.vwCustomer>
                {
                    new views.vwCustomer{id=Guid.Parse("10d9a217-1e28-4b24-a364-03e212cf2dcd"), blockNo="111", branchCode="112", CenterNo="113", customerBirthdate=new DateTime(1993, 3, 17), customerCivilStatus="102002",
                                         customerFirstName="Jom", customerID="123456789",  customerLastName="Gapuz", customerMembershipDate=new DateTime(2009, 8, 23), customerMiddleName="Lazo",
                                         customerSuffix="", dungannonID="123456789", spouseBirthdate=new DateTime(1982, 5, 4), spouseFirstName="Joana", spouseID="123123123", spouseLastName="Peligor",
                                         spouseMiddleName="Destor", spouseSuffix=""},
                    new views.vwCustomer{id=Guid.Parse("b1a15115-75f0-4dc3-9aee-ce84cdf09515"), blockNo="221", branchCode="222", CenterNo="223", customerBirthdate=new DateTime(1982, 2, 11), customerCivilStatus="102002",
                                         customerFirstName="John", customerID="987654321",  customerLastName="Amarillo", customerMembershipDate=new DateTime(2012, 11, 3), customerMiddleName="Enero",
                                         customerSuffix="", dungannonID="987654321", spouseBirthdate=new DateTime(1989, 7, 30), spouseFirstName="Lyka", spouseID="987987987", spouseLastName="Casuyac",
                                         spouseMiddleName="Dapedran", spouseSuffix=""},
                    new views.vwCustomer{id=Guid.Parse("e79c1cf7-99b9-4494-b894-37f27517b4d2"), blockNo="331", branchCode="332", CenterNo="333", customerBirthdate=new DateTime(1989, 11, 21), customerCivilStatus="102001",
                                         customerFirstName="Creselle", customerID="147852369",  customerLastName="Yaranon", customerMembershipDate=new DateTime(2017, 1, 15), customerMiddleName="Mejorada",
                                         customerSuffix="", dungannonID="147147147"}
                };
                conn.InsertAll(listCustomer);

                var listDependent = new List<views.vwDependent>
                {
                    new views.vwDependent{id=Guid.NewGuid(), customerID=Guid.Parse("10d9a217-1e28-4b24-a364-03e212cf2dcd"), dependentBirthdate="2002/02/20", dependentFullName="Emmanuel Gapuz", dependentID="963258741", dependentRelationship="CHILD"},
                    new views.vwDependent{id=Guid.NewGuid(), customerID=Guid.Parse("b1a15115-75f0-4dc3-9aee-ce84cdf09515"), dependentBirthdate="1968/02/20", dependentFullName="Maria Amarillo", dependentID="369852147", dependentRelationship="MOTHER"}
                };
                conn.InsertAll(listDependent);

                var listDisbursementPayee = new List<views.vwDisbursementPayee>
                {
                    new views.vwDisbursementPayee{id=Guid.NewGuid(), branchID=Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e"), businessName="WD Enterprise", payeeID="789654123"},
                    new views.vwDisbursementPayee{id=Guid.NewGuid(), branchID=Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e"), businessName="Samgyeop", payeeID="519684151"},
                    new views.vwDisbursementPayee{id=Guid.NewGuid(), branchID=Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e"), businessName="Logitech", payeeID="317891089"}
                };
                conn.InsertAll(listDisbursementPayee);

                var listMAFEnrollmentClosure = new List<views.vwMafEnrollmentClosure>
                {
                    new views.vwMafEnrollmentClosure{id=Guid.NewGuid(), accountNo="198519", customerID="123456789", deceased=false, effectiveDate=new DateTime(2018, 5, 9), productID="3104"},
                    new views.vwMafEnrollmentClosure{id=Guid.NewGuid(), accountNo="576121", customerID="123456789", deceased=false, effectiveDate=new DateTime(2018, 5, 9), productID="3108"},
                    new views.vwMafEnrollmentClosure{id=Guid.NewGuid(), accountNo="931254", customerID="987654321", deceased=false, effectiveDate=new DateTime(2018, 5, 9), productID="3109"}
                };
                conn.InsertAll(listMAFEnrollmentClosure);

                var listPremiumsPaid = new List<views.vwPremiumsPaid>
                {
                    new views.vwPremiumsPaid{id=Guid.NewGuid(), amount=1000, fromDays=0, toDays=50, productUID=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191")},
                    new views.vwPremiumsPaid{id=Guid.NewGuid(), amount=3000, fromDays=51, toDays=100, productUID=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191")},
                    new views.vwPremiumsPaid{id=Guid.NewGuid(), amount=5000, fromDays=101, toDays=500, productUID=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191")}
                };
                conn.InsertAll(listPremiumsPaid);

                var listProductMembership = new List<views.vwProductMembership>
                {
                    new views.vwProductMembership{id=Guid.NewGuid(), amount=2000, fromDays=0, toDays=100, productUID=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191")},
                    new views.vwProductMembership{id=Guid.NewGuid(), amount=4000, fromDays=101, toDays=1000, productUID=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191")},
                    new views.vwProductMembership{id=Guid.NewGuid(), amount=6000, fromDays=1001, toDays=5000, productUID=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191")}
                };
                conn.InsertAll(listProductMembership);

                var listTempUser = new List<views.vwTempUsers>
                {
                    new views.vwTempUsers{id=Guid.NewGuid(), blockName="012", branchCode="192", username="kenn"},
                    new views.vwTempUsers{id=Guid.NewGuid(), blockName="012", branchCode="192", username="rona"},
                    new views.vwTempUsers{id=Guid.NewGuid(), blockName="012", branchCode="192", username="sweet"},
                };
                conn.InsertAll(listTempUser);
            }
        }
    }
}

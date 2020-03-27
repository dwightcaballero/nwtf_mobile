﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

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

        public static void initializeDB()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DatabasePath))
            {
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
            }
        }

        public static void initializeData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DatabasePath))
            {
                var lstClaimTypes = new List<views.vwClaimTypes>
                {
                    new views.vwClaimTypes
                    {
                        id=Guid.Parse("3e00abb5-f0cf-458a-8423-84165452bd78"),
                        claimTypeName = "Hospital Cash Assistance-M",
                        claimTypeShortName = "CAM",
                        claimTypeCode="TYP07",
                        allowAdvances = false,
                        disburseInhouseTransID = "0",
                        disburseMICTransID = "2070"
                    },
                    new views.vwClaimTypes
                    {
                        id=Guid.Parse("5836f582-f77d-4348-89df-39f73fcb7636"),
                        claimTypeName = "Burial Assistance-SA",
                        claimTypeShortName = "BAS",
                        claimTypeCode="TYP16",
                        allowAdvances = true,
                        disburseInhouseTransID = "2043",
                        disburseMICTransID = "2071"
                    },
                    new views.vwClaimTypes
                    {
                        id=Guid.Parse("fe3f0c9b-56c6-45b8-96bc-5f8b850109b2"),
                        claimTypeName = "Financial Assistance on Natural Cause of Death-SA",
                        claimTypeShortName = "FCS",
                        claimTypeCode="TYP02",
                        allowAdvances = true,
                        disburseInhouseTransID = "2043",
                        disburseMICTransID = "2071"
                    },
                    new views.vwClaimTypes
                    {
                        id=Guid.Parse("8451c5ef-e0af-4038-8e39-90fe73ec1bee"),
                        claimTypeName = "Financial Assistance on Natural Cause of Death - M",
                        claimTypeShortName = "FCM",
                        claimTypeCode="TYP01",
                        allowAdvances = true,
                        disburseInhouseTransID = "2043",
                        disburseMICTransID = "2071"
                    }
                };
                conn.InsertAll(lstClaimTypes);

                var lstProducts = new List<views.vwProduct>
                {
                    new views.vwProduct
                    {
                        id=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191"),
                        productID = "3104",
                        productName="MAF05",
                        generalInsurance = false,
                        inHouseInsurance=false,
                        requireSavingsLoans=false,
                        usableForTransactions=true
                    },
                    new views.vwProduct
                    {
                        id=Guid.Parse("3f87fae8-d287-4ea1-9685-4d22eca8e37d"),
                        productID = "3108",
                        productName="MAF11",
                        generalInsurance = false,
                        inHouseInsurance=false,
                        requireSavingsLoans=false,
                        usableForTransactions=true
                    },
                    new views.vwProduct
                    {
                        id=Guid.Parse("89a2061b-4f94-48d8-b289-0ef15090ce4a"),
                        productID = "3109",
                        productName="MAF20",
                        generalInsurance = false,
                        inHouseInsurance=false,
                        requireSavingsLoans=false,
                        usableForTransactions=true
                    },
                };
                conn.InsertAll(lstProducts);

                var lstProductClaimTypes = new List<views.vwProductClaimType>
                {
                    new views.vwProductClaimType
                    {
                        id= Guid.Parse("8b3fc6cf-159c-409e-8a28-58cb21f90265"),
                        productUID= Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191"),
                        claimTypeUID= Guid.Parse("3e00abb5-f0cf-458a-8423-84165452bd78"),
                        claimantType="Member"
                    },
                    new views.vwProductClaimType
                    {
                        id= Guid.Parse("b5dd7cca-e92e-4100-8817-861fef9984d3"),
                        productUID= Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191"),
                        claimTypeUID= Guid.Parse("8451c5ef-e0af-4038-8e39-90fe73ec1bee"),
                        claimantType="Member"
                    },
                    new views.vwProductClaimType
                    {
                        id= Guid.Parse("ed0e2959-2d96-4d35-a389-c55e5003415c"),
                        productUID= Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191"),
                        claimTypeUID= Guid.Parse("7fd88a31-2429-4b06-8c9f-93500f687387"),
                        claimantType="Secondary Assured"
                    },
                    new views.vwProductClaimType
                    {
                        id= Guid.Parse("fcb90646-1463-426b-b0a2-448fe5c96857"),
                        productUID= Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191"),
                        claimTypeUID= Guid.Parse("5836f582-f77d-4348-89df-39f73fcb7636"),
                        claimantType="Secondary Assured"
                    },
                };
                conn.InsertAll(lstProductClaimTypes);

                var lstSubgroup = new List<views.vwSubgroups>
                {
                    new views.vwSubgroups
                    {
                        id = Guid.Parse("7e36ace3-b23b-4fde-8b08-181710a41ed5"),
                         subgroupName="Medical"
                    },
                    new views.vwSubgroups
                    {
                        id = Guid.Parse("4998d990-b2b3-470f-b5fb-365b1d0ac97f"),
                         subgroupName="Death"
                    }
                };
                conn.InsertAll(lstSubgroup);

                var lstClaimTypeSubgroup = new List<views.vwClaimTypeSubgroup>
                {
                    new views.vwClaimTypeSubgroup
                    {
                        id = Guid.Parse("74ea17a1-6e31-47fc-90fd-35dde02dab15"),
                        claimTypeUID = Guid.Parse("5836f582-f77d-4348-89df-39f73fcb7636"),
                        subgroupUID = Guid.Parse("4998d990-b2b3-470f-b5fb-365b1d0ac97f")
                    },
                    new views.vwClaimTypeSubgroup
                    {
                        id = Guid.Parse("2676feab-c3a3-4519-90d8-5599f82f6143"),
                        claimTypeUID = Guid.Parse("8451c5ef-e0af-4038-8e39-90fe73ec1bee"),
                        subgroupUID = Guid.Parse("4998d990-b2b3-470f-b5fb-365b1d0ac97f")
                    },
                    new views.vwClaimTypeSubgroup
                    {
                        id = Guid.Parse("f3fffd00-a469-4e43-9ff1-1caf4af9d179"),
                        claimTypeUID = Guid.Parse("fe3f0c9b-56c6-45b8-96bc-5f8b850109b2"),
                        subgroupUID = Guid.Parse("4998d990-b2b3-470f-b5fb-365b1d0ac97f")
                    },
                    new views.vwClaimTypeSubgroup
                    {
                        id = Guid.Parse("bd337801-9646-48ac-b591-6cded268ca13"),
                        claimTypeUID = Guid.Parse("3e00abb5-f0cf-458a-8423-84165452bd78"),
                        subgroupUID = Guid.Parse("7e36ace3-b23b-4fde-8b08-181710a41ed5")
                    }
                };
                conn.InsertAll(lstClaimTypeSubgroup);

                var lstSubgroupRequiredFields = new List<views.vwSubgroupRequiredFields>
                {
                    new views.vwSubgroupRequiredFields
                    {
                        id = Guid.Parse("c44e3eea-4fed-43bc-9c80-1ae7793adb97"),
                        subgroupUID = Guid.Parse("7e36ace3-b23b-4fde-8b08-181710a41ed5"),
                        requiredFieldUID = Guid.Parse("acb3dddf-e586-4a05-8faf-9ae3d31c78cf")
                    },
                    new views.vwSubgroupRequiredFields
                    {
                        id = Guid.Parse("1f14f5ca-b979-4474-8809-3f74eb77c209"),
                        subgroupUID = Guid.Parse("7e36ace3-b23b-4fde-8b08-181710a41ed5"),
                        requiredFieldUID = Guid.Parse("0901e84a-7a94-451a-a513-3275f4197310")
                    },
                    new views.vwSubgroupRequiredFields
                    {
                        id = Guid.Parse("6d317ddc-92a3-46a4-94c5-0cb1b9d29809"),
                        subgroupUID = Guid.Parse("4998d990-b2b3-470f-b5fb-365b1d0ac97f"),
                        requiredFieldUID = Guid.Parse("bcd262da-c008-429a-8143-ebd3639ac662")
                    },
                    new views.vwSubgroupRequiredFields
                    {
                        id = Guid.Parse("5a5eb70b-7cc1-4c46-b6d2-0a9eddc6f677"),
                        subgroupUID = Guid.Parse("4998d990-b2b3-470f-b5fb-365b1d0ac97f"),
                        requiredFieldUID = Guid.Parse("040b5044-b380-47c4-ae77-007dd21bffb9")
                    }
                };
                conn.InsertAll(lstSubgroupRequiredFields);

                var lstRequiredFields = new List<views.vwRequiredFields>
                {
                    new views.vwRequiredFields
                    {
                        id = Guid.Parse("acb3dddf-e586-4a05-8faf-9ae3d31c78cf"),
                        requiredFieldName="Diagnosis",
                        requiredFieldType=1
                    },
                    new views.vwRequiredFields
                    {
                        id = Guid.Parse("0901e84a-7a94-451a-a513-3275f4197310"),
                        requiredFieldName="Number of Days",
                        requiredFieldType=1
                    },
                    new views.vwRequiredFields
                    {
                        id = Guid.Parse("bcd262da-c008-429a-8143-ebd3639ac662"),
                        requiredFieldName="Cause of Death",
                        requiredFieldType=1
                    },
                    new views.vwRequiredFields
                    {
                        id = Guid.Parse("040b5044-b380-47c4-ae77-007dd21bffb9"),
                        requiredFieldName="Date of Death",
                        requiredFieldType=2
                    },
                };
                conn.InsertAll(lstRequiredFields);

                var lstClaimTypeRequiredDocuments = new List<views.vwClaimTypeRequiredDocuments>
                {
                    new views.vwClaimTypeRequiredDocuments
                    {
                        id = Guid.Parse("1b10a074-0de9-4be0-8aca-1a78029ae900"),
                        claimTypeUID = Guid.Parse("5836f582-f77d-4348-89df-39f73fcb7636"),
                        requiredDocumentUID = Guid.Parse("a3eb2d67-8303-42d3-bf58-500b94fe8727")
                    },
                    new views.vwClaimTypeRequiredDocuments
                    {
                        id = Guid.Parse("6a5f22ae-0c68-4d2d-adbf-a6663dc16deb"),
                        claimTypeUID = Guid.Parse("8451c5ef-e0af-4038-8e39-90fe73ec1bee"),
                        requiredDocumentUID = Guid.Parse("64019e75-b6a7-46fb-9daa-cdabd1db180a")
                    },
                    new views.vwClaimTypeRequiredDocuments
                    {
                        id = Guid.Parse("e13335d6-cfb5-412b-89cf-06d9bc19e4cb"),
                        claimTypeUID = Guid.Parse("fe3f0c9b-56c6-45b8-96bc-5f8b850109b2"),
                        requiredDocumentUID = Guid.Parse("64019e75-b6a7-46fb-9daa-cdabd1db180a")
                    },
                    new views.vwClaimTypeRequiredDocuments
                    {
                        id = Guid.Parse("b8e51edc-87c2-4ef6-ac86-37e565c2ca33"),
                        claimTypeUID = Guid.Parse("fe3f0c9b-56c6-45b8-96bc-5f8b850109b2"),
                        requiredDocumentUID = Guid.Parse("535e2f04-abb7-44d6-a48e-3d2b9fb274bf")
                    },
                    new views.vwClaimTypeRequiredDocuments
                    {
                        id = Guid.Parse("87e736eb-680f-4368-975c-c0d6b5cc13e3"),
                        claimTypeUID = Guid.Parse("3e00abb5-f0cf-458a-8423-84165452bd78"),
                        requiredDocumentUID = Guid.Parse("c4001a2a-7537-4291-b40b-de7c86039fea")
                    }
                };
                conn.InsertAll(lstClaimTypeRequiredDocuments);

                var lstRequiredDocuments = new List<views.vwRequiredDocuments>
                {
                    new views.vwRequiredDocuments
                    {
                        ID=Guid.Parse("a3eb2d67-8303-42d3-bf58-500b94fe8727"),
                        requiredDocumentCode="DOC10",
                        requiredDocumentName="Drivers License",
                        RequiresHardCopy=1
                    },
                    new views.vwRequiredDocuments
                    {
                        ID=Guid.Parse("64019e75-b6a7-46fb-9daa-cdabd1db180a"),
                        requiredDocumentCode="DOC01",
                        requiredDocumentName="Death Certificate",
                        RequiresHardCopy=1
                    },
                    new views.vwRequiredDocuments
                    {
                        ID=Guid.Parse("535e2f04-abb7-44d6-a48e-3d2b9fb274bf"),
                        requiredDocumentCode="DOC02",
                        requiredDocumentName="Claimant Statement",
                        RequiresHardCopy=1
                    },
                    new views.vwRequiredDocuments
                    {
                        ID=Guid.Parse("c4001a2a-7537-4291-b40b-de7c86039fea"),
                        requiredDocumentCode="DOC12",
                        requiredDocumentName="Statement of Account",
                        RequiresHardCopy=1
                    }
                };
                conn.InsertAll(lstRequiredDocuments);

                var listDisbursementType = new List<views.vwDisbursementType>
                {
                    new views.vwDisbursementType
                    {
                        id = Guid.Parse("00b3afb8-544c-4a38-90ae-f771a935d014"),
                        claimantType=2,
                        DisbursementTypeName="ADVBAS",
                        PayeeType=1,
                        AmountType=1,
                        AmountValue=2500.00,
                        claimTypeID= Guid.Parse("5836f582-f77d-4348-89df-39f73fcb7636"),
                        isFinalPayee=false,
                    },
                    new views.vwDisbursementType
                    {
                        id = Guid.Parse("2d15bdc8-100b-4551-aa52-2c220ef2cb13"),
                        claimantType=1,
                        DisbursementTypeName="ADV-M",
                        PayeeType=4,
                        AmountType=2,
                        AmountValue=30.00,
                        claimTypeID= Guid.Parse("8451c5ef-e0af-4038-8e39-90fe73ec1bee"),
                        isFinalPayee=true,
                    },
                    new views.vwDisbursementType
                    {
                        id = Guid.Parse("2309a00a-bbf6-40f3-9621-dfb24eb26df9"),
                        claimantType=2,
                        DisbursementTypeName="ADV-S",
                        PayeeType=1,
                        AmountType=2,
                        AmountValue=30.00,
                        claimTypeID= Guid.Parse("fe3f0c9b-56c6-45b8-96bc-5f8b850109b2"),
                        isFinalPayee=true,
                    }
                };
                conn.InsertAll(listDisbursementType);

                var lstClaimBenefit = new List<views.vwClaimBenefits>
                {
                    new views.vwClaimBenefits
                    {
                        id=Guid.Parse("5b6fd6ad-0791-4af2-98b4-f4480660c082"),
                        productUID=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191"),
                        productClaimTypeUID=Guid.Parse("8b3fc6cf-159c-409e-8a28-58cb21f90265"),
                        claimBenefitsLimits=5,
                        claimantType=1,
                        maximumAmount=500000.00,
                        amount=10000.00
                    },
                    new views.vwClaimBenefits
                    {
                        id=Guid.Parse("a3af2865-a38f-489c-a631-87dff0b0533e"),
                        productUID=Guid.Parse("b7121a30-04ab-41d4-bb86-c978ee051191"),
                        productClaimTypeUID=Guid.Parse("b5dd7cca-e92e-4100-8817-861fef9984d3"),
                        claimBenefitsLimits=4,
                        claimantType=1
                    }
                };
                conn.InsertAll(lstClaimBenefit);
            }
        }
    }
}

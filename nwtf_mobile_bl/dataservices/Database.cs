using SQLite;
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
    }
}

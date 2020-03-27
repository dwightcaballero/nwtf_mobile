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

        public static void initData()
        {
            var db = new SQLiteConnection(DatabasePath);
            
            var lstbranchEmployee = new List<views.vwBranchEmployee>
            {
                new views.vwBranchEmployee
                {
                    id= Guid.NewGuid(),
                    employeeName= "Leslie Hererro",
                    payeeID="123ABC",
                    branchID=Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e")
                },
                new views.vwBranchEmployee
                {
                    id= Guid.NewGuid(),
                    employeeName= "Joseph Alonsabe",
                    payeeID="123ABC",
                    branchID=Guid.Parse("34a1738a-27ac-4e86-ac7e-8eb52467366e")
                }
            };
            db.InsertAll(lstbranchEmployee);

            var lstCivilStatus = new List<views.vwCivilStatus>
            {
                new views.vwCivilStatus
                {
                    id= Guid.NewGuid(),
                    civilStatusCode = "102001",
                    description = "Single",
                    isMarried=false
                },
                new views.vwCivilStatus
                {
                    id= Guid.NewGuid(),
                    civilStatusCode = "102001",
                    description = "Single",
                    isMarried=false
                }
            };
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace nwtf_mobile_bl.controllers
{
    public class initializeDB
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public bool instanciateDB()
        {
            var initialDB = false;

            var db = new SQLiteConnection(dbPath);

            return initialDB;
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSeguroPopularHidalgo.iOS.Storage
{
    public class iOSConnection
    {
        public iOSConnection()
        {

        }

        public SQLiteConnection DBiOSConnection()
        {
            var sqliteFilename = "AppSeguroPopular.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = System.IO.Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}

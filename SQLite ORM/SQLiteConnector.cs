using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_ORM
{
    class SQLiteConnector
    {
        static private string _pathToFile;
        static private string _connectionString;
        static private SQLiteConnection _sQLiteConnection;

        public static SQLiteConnection Connection
        {
            get { return _sQLiteConnection; }
        }
        public static string ConnString
        {
            get { return _connectionString; }
        }
        public static string PathToDB
        {
            get { return _pathToFile; }
            set
            {
                if (File.Exists(value))
                {
                    _pathToFile = value;
                    _connectionString = $"DataSource={_pathToFile}; Version=3";
                    _sQLiteConnection = new SQLiteConnection(_connectionString);
                }
                else
                {
                    throw new SQLiteException("Database file does not exist. Please create it.");
                }
            }
        }
        public static void createDatabaseSource(string pathToDatabase)
        {
            try
            {
                SQLiteConnection.CreateFile(pathToDatabase);
                PathToDB = pathToDatabase;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

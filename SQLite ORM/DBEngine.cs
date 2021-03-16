using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_ORM
{
    class DBEngine
    {
        private List<Table> _DBTables;
        private List<string> _tables;

        public Table this[string name]
        {
            get
            {
                foreach (var item in _DBTables)
                {
                    if (name.ToLower().Equals(item.Name.ToLower()))
                    {
                        return item;
                    }
                }
                throw new ArgumentException("Table does not exist");
            }
        }

        public DBEngine(string dbpath, SQLiteMode mode)
        {
            _tables = new List<string>();
            _DBTables = new List<Table>();
            switch (mode)
            {
                case SQLiteMode.EXISTS:
                    {
                        SQLiteConnector.PathToDB = dbpath;
                        init();
                        break;
                    }
                case SQLiteMode.NEW:
                    {
                        SQLiteConnector.createDatabaseSource(dbpath);
                        break;
                    }
            }
        }

        private void init()
        {
            getTableNamesExists();
        }

        private void getTableNamesExists()
        {
            string queryGetTablesName = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'";
            SQLiteConnector.Connection.Open();
            SQLiteCommand sQLiteCommand = new SQLiteCommand(queryGetTablesName, SQLiteConnector.Connection);
            SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
            foreach (DbDataRecord rows in sQLiteDataReader)
            {
                _tables.Add(rows.GetString(0));
                _DBTables.Add(new Table(rows.GetString(0), getTableFields(rows.GetString(0)), getTableData(rows.GetString(0))));
            }
            SQLiteConnector.Connection.Close();
        }
        private SortedList<long, List<string>> getTableData(string table)
        {
            SortedList<long, List<string>> dataList = new SortedList<long, List<string>>();

            string queryGetTablesName = $"SELECT * FROM {table}";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(queryGetTablesName, SQLiteConnector.Connection);
            SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
            foreach (DbDataRecord rows in sQLiteDataReader)
            {
                List<string> fields = new List<string>();
                for (int i = 1; i < rows.FieldCount; i++)
                {
                    fields.Add(Convert.ToString(rows.GetValue(i)));
                }
                dataList.Add(Convert.ToInt64(rows.GetValue(0)), fields);
            }
            return dataList;
        }
        private Row getTableFields(string table)
        {
            Row zeRow = null;
            if (DoesTableExist(table))
            {
                string queryGetTableFields = $"PRAGMA table_info('{table}')";
                //SQLiteConnector.Connection.Open();
                SQLiteCommand sQLiteCommand = new SQLiteCommand(queryGetTableFields, SQLiteConnector.Connection);
                SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                zeRow = new Row(sQLiteDataReader.FieldCount);
                foreach (DbDataRecord rows in sQLiteDataReader)
                {
                    string[] str = new string[6];
                    for (int i = 0; i < rows.FieldCount; i++)
                    {
                        str[i] = rows.GetValue(i).ToString();
                    }
                    zeRow.AddColumn(new Column(str));
                }
                //SQLiteConnector.Connection.Close();
            }
            return zeRow;
        }
        public bool DoesTableExist(string tableName)
        {
            if (_tables.Count > 0)
            {
                foreach (string table in _tables)
                {
                    if (table.ToLower().Equals(tableName.ToLower()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public List<string> Tables
        {
            get { return _tables; }
        }
    }
}

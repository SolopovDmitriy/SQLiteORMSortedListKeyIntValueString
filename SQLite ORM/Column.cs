using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_ORM
{
    class Column
    {
        private int _cid;
        private string _name;
        private SQLiteDataTypes? _dataType;
        private bool _notNull;
        private string _defValue;
        private bool _pk;

        public int CID
        {
            get { return _cid; }
        }
        public string Name
        {
            get { return _name; }
        }
        public SQLiteDataTypes? dataType
        {
            get { return _dataType; }
        }
        public bool NotNull 
        {
            get { return _notNull; }
        }
        public string DefaultValue
        {
            get { return _defValue; }
        }
        public bool PK
        {
            get { return _pk; }
        }
        public Column()
        {
            _cid = 0;
            _name = "Name";
            _dataType = SQLiteDataTypes.INT;
            _notNull = false;
            _defValue = "Default";
            _pk = false;
        }
        public Column(string[] str)
        {
            _cid = Convert.ToInt32(str[0]);
            _name = str[1];
            _dataType = GetDataType(str[2]);
            _notNull = str[3] == "1" ? true : false;
            _defValue = str[4];
            _pk = str[5] == "1" ? true : false;
        }
        public SQLiteDataTypes? GetDataType(string dateType)
        {
            foreach (var item in Enum.GetValues(typeof(SQLiteDataTypes)))
            {
                if (dateType.IndexOf(item.ToString()) != -1)
                {
                    _dataType = (SQLiteDataTypes)Enum.Parse(typeof(SQLiteDataTypes), item.ToString(), true);
                    return _dataType;
                }
            }
            throw new ArgumentException("There is no such data type. Please check spelling or existence of it.");
        }
        public override string ToString()
        {
            return $"CID = {_cid};\n" +
                $"Name = {_name}\n" +
                $"Data type = {_dataType}\n" +
                $"Is NULL = {_notNull}\n" +
                $"Default value = {_defValue}\n" +
                $"PK = {_pk}\n";
        }
    }
}

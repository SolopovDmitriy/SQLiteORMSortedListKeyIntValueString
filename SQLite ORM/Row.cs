using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_ORM
{
    class Row : IEnumerable
    {
        private readonly List<Column> _columns;
        private int _countColumn;

        public Row(int fieldCount)
        {
            _countColumn = fieldCount;
            if(fieldCount <= 0) throw new ArgumentOutOfRangeException();
            _columns = new List<Column>(fieldCount);
        }
        public void AddColumn(Column column)
        {
            if (_columns.Count + 1 < _countColumn)
            {
                _columns.Add(column);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public Column GetColumn(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return _columns.GetEnumerator();
        }

        public object this[int index]
        {
            get { return _columns[index]; }
        }
        public object this[string NameOfColumn]
        {
            get
            {
                foreach (Column item in _columns)
                {
                    if (item.Name.ToLower().Equals(NameOfColumn.ToLower()))
                    {
                        return item;
                    }
                }
                throw new ArgumentException("Incorrect column name.");
            }
        }
        public override string ToString()
        {
            return $"Columns: {_columns.Count}";
        }
    }
}

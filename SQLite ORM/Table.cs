using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_ORM
{
    class Table
    {
        private string _name;
        private Row _headerRow;
        private SortedList<long, List<string>> _bodyRows;

        public Row HeadRowInfo
        {
            get { return _headerRow; }
        }
        public string Name
        {
            get { return _name; }
        }
        public SortedList<long, List<string>> BodyRows
        {
            get { return _bodyRows; }
        }
        public void AddNewRow()
        {

        }
        public Table(string tableName, Row row, SortedList<long, List<string>> bodyRows)
        {
            _name = tableName; //validation required
            _headerRow = row;
            _bodyRows = bodyRows;
        }
    }
}

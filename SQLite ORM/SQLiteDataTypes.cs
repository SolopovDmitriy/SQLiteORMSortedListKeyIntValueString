using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_ORM
{
    enum SQLiteDataTypes
    {
        NULL,
        INT,
        INTEGER,
        TINYINT,
        SMALLINT,
        MEDIUMINT,
        BIGINT,
        UNSIGNED_BIG_INT,
        INT2,
        INT8,
        CHARACTER,
        VARCHAR,
        VARYING_CHARACTER,
        NCHAR,
        NATIVE_CHARACTER,
        NVARCHAR,
        TEXT,
        CLOB,
        BLOB,
        REAL,
        DOUBLE,
        DOUBLE_PRECISION,
        FLOAT,
        NUMERIC,
        DECIMAL,
        BOOLEAN,
        DATE,
        DATETIME
    }
}
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pathToFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "mydb.sqlite");
                DBEngine engine = new DBEngine(pathToFile, SQLiteMode.EXISTS);

                Console.WriteLine(engine["students"].Name);

                Table students = engine["students"];
                foreach (Column item in students.HeadRowInfo)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Data in students table");
                foreach (var item in students.BodyRows)
                {
                    Console.WriteLine($"ID: {item.Key}");
                    foreach (var faitem in item.Value)
                    {
                        Console.WriteLine(faitem + " ");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();   
            }
            Console.ReadKey();
        }
    }
}

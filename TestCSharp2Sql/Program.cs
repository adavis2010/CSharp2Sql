using System;
using CSharp2Sql;
namespace TestCSharp2Sql {
    class Program {
        static void Main(string[] args) {
            //create instance of class
            var conn = new Connection();
            conn.Connect("EdDb");
            //closes connection
            conn.Disconnect();

                //create instance of class

            // var sql = new EdDbLib();
            //sql.Connect("EdDb");
            //Console.WriteLine("Connected Successfully");

            //sql.ExecSelect();
            //sql.Class();
            //sql.Disconnect();
        }

            //create instance of class

            //var sql = new EdDbLib();
            //sql.Connect("EdDb");
            //Console.WriteLine("Connected Successfully");

            //sql.ExecSelect();
            //sql.Disconnect();
        }
    }


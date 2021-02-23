using System;
using CSharp2Sql;
namespace TestCSharp2Sql {
    class Program {
        static void Main(string[] args) {
            //create instance of class
            var conn = new Connection();
            conn.Connect("EdDb");
            //passing connection into student controller class..below
            var studentController = new StudentsController(conn);
            //call our get all method
            var students = studentController.GetAll();
            foreach (var s in students) {
                Console.WriteLine($"{s.Id}|{s.Firstname}|{s.Lastname}|{s.Major}");


            }
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


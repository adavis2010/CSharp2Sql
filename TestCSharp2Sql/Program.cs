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
            var student = studentController.GetByPk(1);
            //create new student create
            var newStudent = new Student {
                Id = 0, Firstname = "Sleepy Joe", Lastname = "Biden", Statecode = "DE",
                SAT = 1300, GPA = 3.2m, Major = null
            };
            
            var success = studentController.Create(newStudent);

            Console.WriteLine($"{student.Id}|{student.Firstname}|{student.Lastname}");

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


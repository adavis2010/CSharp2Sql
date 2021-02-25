using System;
using CSharp2Sql;
namespace TestCSharp2Sql {
    class Program {
        static void Main(string[] args) {
            var conn = new Connection();
            conn.Connect("EdDb");

            //var ClassesController = new ClassesController(conn);

                

            //INSERT  CREATE .....
            var sql = new Class();
            sql.connect("Class");
            
            var success = ClassesController.Create(new Class());
            var newclass = new Class {
                Id = 0, Code = "11200", Subject = "Underwater Basket Weaving", Section = 901, InstructorId = null
            };


            var success = classesController.Create(newclass);

            newclass.Id = 2;
            
        }

    }                
        

            //Call Primary KEY Method
            //var cls = ClassesController.GetbyPk(1);
            //Console.WriteLine($"{cls.Id}|{cls.code}|{cls.section}| {cls.InstructorId}");




            //create new student 
            //var newStudent = new Student {
              //Id = 0, Firstname = " Joseph", Lastname = "Biden", Statecode = "DC",
             //SAT = 1350, GPA = 2.7m, Major = null
             // };

        }
    

//GetAll Call Method for Classes Controller Below
// var sql = new EdDbLib();
// sql.Connect("EdDb");

// var classes = ClassesController.GetAll();
//foreach (var c in classes) {
// Console.WriteLine($"{c.Id}|{c.Code}|{c.Section}|{c.Subject}| {c.InstructorId}");
// } DONE



//var sql = new Major();
//sql.Connect("Major");
//Console.WriteLine("Connected Successfully");

//sql.ExecSelect();
//sql.Disconnect();

// conn.Disconnect();
//}


//create instance of class
//var conn = new Connection();
//conn.Connect("EdDb");
//passing connection into student controller class..below
// var studentController = new StudentsController(conn);

//create new student create
//var newStudent = new Student {
//  Id = 0, Firstname = " Joseph", Lastname = "Biden", Statecode = "DC",
// SAT = 1350, GPA = 2.7m, Major = null
//  };

//var success = studentController.Create(newStudent);

//newStudent.Id = 2;
//var success = studentController.Change(newStudent);
//change/update
//var student = studentController.GetByPk(2);
// Console.WriteLine($"{student.Id}|{student.Firstname}|{student.Lastname}");
//removing (delete) deleting student with id of number 2
//success = studentController.Remove(2);
// Console.WriteLine($"Remove worked {success}");

//removing range (delete with array of numbers)
//success = studentController.RemoveRange(1, 2);

//call our get all method
// var students = studentController.GetAll();
// foreach (var s in students) {
//// Console.WriteLine($"{s.Id}|{s.Firstname}|{s.Lastname}|{s.Major}");


// }
//closes connection
//conn.Disconnect();

//create instance of class

// var sql = new EdDbLib();
//sql.Connect("EdDb");
//Console.WriteLine("Connected Successfully");

//sql.ExecSelect();
//sql.Class();
//sql.Disconnect();


//create instance of class

//var sql = new EdDbLib();
//sql.Connect("EdDb");
//Console.WriteLine("Connected Successfully");

//sql.ExecSelect();
//sql.Disconnect();





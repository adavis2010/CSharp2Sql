using Microsoft.Data.SqlClient;
//MAKE SURE I HAVE THIS USING STATEMENT!!
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class StudentsController {

        //contructor is private so it can only be accessed through the class itself (StudentsController class) aka Encapsulation
        private Connection connection { get; set; }

        //method to retrieve all students
        public List <Student> GetAll() {
            //select statement
            var sql = "SELECT * From Student;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            // create select statement for student list (do before while loop)
            var students = new List<Student>();
            while (reader.Read()) {
                // inside the while loop..processing rows that came back to us
                var student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Firstname = reader["Firstname"].ToString();
                student.Lastname = reader["Lastname"].ToString();
                student.Statecode = reader["Statecode"].ToString();
                student.SAT =  Convert.ToInt32 (reader["SAT"]);
                student.GPA = Convert.ToDecimal(reader["GPA"]);
                //for null database in sql and C#
                student.MajorId = null;
                if(reader["MajorId"] != System.DBNull.Value) {
                    student.MajorId = Convert.ToInt32(reader["MajorId"]);
                }
                //add student instance to our collection
                students.Add(student);
            }
            reader.Close();
            return students;
        }


        //our constructor with one parameter =(Connection connection)
        public StudentsController(Connection connection) {
            this.connection = connection;
        }
    }
}

using Microsoft.Data.SqlClient;
//MAKE SURE I HAVE THIS USING STATEMENT!!
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class StudentsController {

        //contructor is private so it can only be accessed through the class itself (StudentsController class) aka Encapsulation
        private Connection connection { get; set; }
        //method to pass in PK and retrieve one row
        public Student GetByPk(int id) {
            //select statement
            var sql = $"SELECT * from Student Where id ={id};";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var hasRow = reader.Read();
            //result will return one row or none at all!
            if (!hasRow) {
                return null;
            }
            var student = new Student();
            student.Id = Convert.ToInt32(reader["Id"]);
            student.Firstname = reader["Firstname"].ToString();
            student.Lastname = reader["Lastname"].ToString();
            student.Statecode = reader["Statecode"].ToString();
            student.SAT = Convert.ToInt32(reader["SAT"]);
            student.GPA = Convert.ToDecimal(reader["GPA"]);
           // student.Major = null;
            //if (reader["Description"] != System.DBNull.Value) {
              //  student.Major = reader["Description"].ToString();
            //}
            reader.Close();
            return student;

        }

        //method to retrieve all students (GetAll)
        public List <Student> GetAll() {
            //select statement
            var sql = "SELECT * From Student s " +
                " left join Major m on s.MajorId = m.Id " +
                " order by s.Lastname;";
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
                student.Major = null;
                if(reader["Description"] != System.DBNull.Value) {
                    student.Major = reader["Description"].ToString();
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

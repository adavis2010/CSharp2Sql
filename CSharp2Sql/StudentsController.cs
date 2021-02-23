using Microsoft.Data.SqlClient;
//MAKE SURE I HAVE THIS USING STATEMENT!!
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class StudentsController {
        //removing multiple items using an array[can insert as many numbers as I want in the brackets]
        public bool RemoveRange(params int[] ids) {
            var success = true;
            //foreach loop
            foreach (var id in ids) {
               success &= Remove(id);
            }
            return success;
        }
        //Delete Function
        public bool Remove(int id) {
            var sql = $"DELETE from Student Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);

        }

        public bool Change(Student student) {
            var sql = $"UPDATE Student Set " +
                    " Firstname = @firstname, " +
                    " Lastname = @lastname," +
                    " StateCode = @statecode," +
                    " SAT = @sat," +
                    " GPA = @gpa" +
                     //use where clause on update statement (@ signs are parameters)
                     " Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            // sql statement:do parameters (two) first one is string @firstname and second is value student.Firstname
            cmd.Parameters.AddWithValue("@firstname", student.Firstname);
            cmd.Parameters.AddWithValue("@lastname", student.Lastname);
            cmd.Parameters.AddWithValue("@statecode", student.Statecode);
            cmd.Parameters.AddWithValue("@sat", student.SAT);
            cmd.Parameters.AddWithValue("@gpa", student.GPA);
            cmd.Parameters.AddWithValue("@id", student.Id);
            var recsAffected = cmd.ExecuteNonQuery();
            //how many rows will be changed
            return (recsAffected == 1);

        }

        //contructor is private so it can only be accessed through the class itself (StudentsController class) aka Encapsulation
        private Connection connection { get; set; }
        //method to pass in PK and retrieve one row

        public bool Create(Student student) {
            var sql = $"INSERT into Student " +
                " (Firstname, Lastname, Statecode, SAT, GPA) " +
                $" VALUES ('{student.Firstname}','{student.Lastname}'," +
                $" '{student.Statecode}', {student.SAT}, {student.GPA});";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            //use execute non query when NOT using select statement (this is returning an integer) does not return a SQL data reader so we dont need a reader close 
            var rowsAffected = cmd.ExecuteNonQuery();
            //will return true or false
            return (rowsAffected == 1);
        }





        public Student GetByPk(int id) {
            //select statement
            var sql = $"SELECT * from Student Where id ={id};";

            var cmd = new SqlCommand(sql, connection.sqlconnection);
            //make connection with reader with select statement
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
        public List<Student> GetAll() {
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
                student.SAT = Convert.ToInt32(reader["SAT"]);
                student.GPA = Convert.ToDecimal(reader["GPA"]);
                //for null database in sql and C#
                //student.Major = null;
                //if(reader["Description"] != System.DBNull.Value) {
                //  student.Major = reader["Description"].ToString();
                //}
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

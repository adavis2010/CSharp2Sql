using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class ClassesController {

        //property
        public Connection connection { get; set; }

        public ClassesController(Connection connection) {
            this.connection = connection;
        }

        //  UPDATE 
        public bool Change(Class cls) {
            var sql = $"UPDATE Class Set " +
                    " Id = @id, " +
                    " Code = @code," +
                    " Subject = @subject," +
                    " Section = @section," +
                    " InstructorId = @instructorid" +
                     //use where clause on update statement (@ signs are parameters)
                     " Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            // sql statement:do parameters (two) first one is string @firstname and second is value class.id
            cmd.Parameters.AddWithValue("@id", cls.Id);
            cmd.Parameters.AddWithValue("@code", cls.Code);
            cmd.Parameters.AddWithValue("@subject", cls.Subject);
            cmd.Parameters.AddWithValue("@section", cls.Section);
            cmd.Parameters.AddWithValue("@instructorid", cls.InstructorId);
            var recsAffected = cmd.ExecuteNonQuery();
            //how many rows will be changed
            return (recsAffected == 1);

        }


        //  DELETE  
        public bool Remove(int id) {
            var sql = $"DELETE from Class Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);

        }


        // INSERT FUNCTION
        public bool Create(Class cls) {
            var sql = $"INSERT into Class " +
                " (Id, Code, Subject, Section, InstructorId) " +
                $" VALUES ('{cls.Id}','{cls.Code}'," +
                $" '{cls.Subject}', {cls.Section}, {cls.InstructorId});";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            //use execute non query when NOT using select statement (this is returning an integer) does not return a SQL data reader so we dont need a reader close 
            var rowsAffected = cmd.ExecuteNonQuery();
            //will return true or false
            return (rowsAffected == 1);
        }
    }
}


        //  GET ALL DATA FUNCTION
        /*public List<Class> GetAll() {
            var sql = "SELECT * from Class c";
            var classes = new List<Class>();

            var cmd =  new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                var cls = new Class();
                cls.Id = Convert.ToInt32(reader["Id"]);
                cls.Code = reader["Code"].ToString();
                cls.Subject = reader["Subject"].ToString();
                cls.InstructorId = null;
                 if (reader["InstructorId"] != System.DBNull.Value) { 
                    cls.InstructorId = Convert.ToInt32(reader["InstructorId"]);
                }
                classes.Add(cls);
            }
        */
        // reader.Close();
        // return classes;

        //GET BY PRIMARY KEY

        /*public Class GetbyPk(int id) {
            var sql = $"SELECT * from Class Where id ={id};";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var hasRow = reader.Read();
            if (!hasRow) {
                return null;
            }
            var cls = new Class();
            cls.Id = Convert.ToInt32(reader["Id"]);
            cls.Code = reader["Code"].ToString();
            cls.Subject = reader["Subject"].ToString();
            if (reader["Id"] != System.DBNull.Value) {
                cls.Id = Convert.ToInt32(reader["Id"]);
                
        
            }
            reader.Close();
            return cls;
        }





        }

        }
        */
            //reader.Close();
            //return classes;
    




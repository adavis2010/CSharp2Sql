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

        public Class GetbyPk(int id) {
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

            //reader.Close();
            //return classes;
    




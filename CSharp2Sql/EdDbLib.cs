using Microsoft.Data.SqlClient;

using System;

namespace CSharp2Sql {
    public class EdDbLib {

        public SqlConnection connection { get; set; }

        public void Class() {

            var sql = "SELECT * from Class;";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                var id = Convert.ToInt32(reader["Id"]);
                var subject = reader["subject"].ToString();
                var section = reader["Section"].ToString();

                Console.WriteLine($"id={id}|{subject}|{section}");

            }
        
            
        
        
        
        
        
        
        
        }

        /*public void SelectAllMajors() {

            var sql = "SELECT * From Major;";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                var id = Convert.ToInt32(reader["Id"]);
                var minsat = Convert.ToInt32(reader["MinSat"]);

                Console.WriteLine($"{id}|{minsat}");
                
            }


        }


        /*public void ExecSelect() {
            var sql = "SELECT * from Major;";

            var cmd = new SqlCommand(sql, connection);

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                var id = Convert.ToInt32(reader["Id"]);
                var minSAT = reader["minSAT"].ToString();

                Console.WriteLine($"id={id},lastname={minSAT}");
            }
        


            reader.Close();
        }
        
        public void Connect(string database) {
            var connStr = $"server=localhost\\sqlexpress;" +
                            $"database={database};" +
                                "trusted_connection=true;";

            connection = new SqlConnection(connStr);
            connection.Open();
            if (connection.State != System.Data.ConnectionState.Open) {
                throw new Exception("Connection is not open!");
            }
        }

            public void Disconnect() {
                connection.Close();
            connection.Open();
            if (connection.State != System.Data.ConnectionState.Open) {
                throw new Exception("Connection is not open!");
            }

            }

        */




            //sql command statement
            // public void ExecSelect() {
               //  var sql = "SELECT * From Student;";
                  //create Sql Command Object
                // var cmd = new SqlCommand(sql, connection);
                 //use execute reader with SELECT statements
                 //var reader = cmd.ExecuteReader();
                 //while (reader.Read()) {
                    // var id = Convert.ToInt32(reader["Id"]);
                     //var lastname = reader["Lastname"].ToString();

                     //Console.WriteLine($"id={id},lastname={lastname}");
                // }
                // reader.Close();

             //}


             //method that will allow us to connect to sql database
             public void Connect(string database) {
                 var connStr = $"server=localhost\\sqlexpress;" +
                                 $"database={database};" +
                                     "trusted_connection=true;";

                 //create instance to sql server
                 connection = new SqlConnection(connStr);

                 //open connection
                 connection.Open();
                 if (connection.State != System.Data.ConnectionState.Open) {
                     throw new Exception("Connection is not open!");
                 }


             }

                 public void Disconnect() {
                 connection.Close();
                 }

         }


     
        }
     

            
        





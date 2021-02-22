using Microsoft.Data.SqlClient;

using System;

namespace CSharp2Sql {
    public class EdDbLib {

        public SqlConnection connection { get; set;}

        // sql command statement
        public void ExecSelect() {
            var sql = "SELECT * From Student;";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                var id = Convert.ToInt32(reader["Id"]);
                var lastname = reader["Lastname"].ToString();

                Console.WriteLine($"id={id},lastname={lastname}");
            }
            reader.Close();
            
        }


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

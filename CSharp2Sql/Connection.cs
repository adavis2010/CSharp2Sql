using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class Connection {

        public SqlConnection connection { get; set; }

        public void Connect(string database) {

            var connsStr = $"server=localhost\\sqlexpress;" +
                            $"database={database};" +
                            $"trusted_connection=true;";
            //create sql connection instance and pass in connection string
            connection = new SqlConnection(connsStr);
            //open connection
            connection.Open();
            //check connection state property
            if (connection.State != System.Data.ConnectionState.Open) {

                throw new Exception("Connection did not open!");
            }
        }
        public void Disconnect() {
            connection.Close();
        }
    }
}

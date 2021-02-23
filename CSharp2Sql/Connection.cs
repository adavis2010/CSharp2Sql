using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class Connection {

        public SqlConnection sqlconnection { get; set; }

        public void Connect(string database) {

            var connsStr = $"server=localhost\\sqlexpress;" +
                            $"database={database};" +
                            $"trusted_connection=true;";
            //create sql sqlconnection instance and pass in sqlconnection string
            sqlconnection = new SqlConnection(connsStr);
            //open sqlconnection
            sqlconnection.Open();
            //check sqlconnection state property
            if (sqlconnection.State != System.Data.ConnectionState.Open) {

                throw new Exception("Connection did not open!");
            }
        }
        public void Disconnect() {
            sqlconnection.Close();
        }
    }
}

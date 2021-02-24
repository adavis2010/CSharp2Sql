using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class MajorsController { }
        public SqlConnection Connection { get; set; }

        public void ExecSelect(); }
            var sql = "SELECT * From Major"
            var cmd = new SqlCommand(sql, SqlConnection);
            var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    major.Id = Convert.ToInt32(reader["Id"]);
                    Major.Code = reader["Code"].ToString();
                    Major.Description = reader["Description"].ToString();
                    Major.MinSAT = Convert.ToInt32(reader["MinSAT"]);


    }

        reader.Close();
      
     




















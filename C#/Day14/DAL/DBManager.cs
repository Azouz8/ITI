using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace DAL
{
    public class DBManager
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        SqlCommandBuilder sqlCommandBuilder;

        public DBManager()
        {

            sqlCommand = new SqlCommand();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter = new SqlDataAdapter();

            sqlDataAdapter.SelectCommand = new SqlCommand("GetAllEmployees", sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            sqlDataAdapter.UpdateCommand = new SqlCommand("UpdateEmployee", sqlConnection);
            sqlDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

            sqlDataAdapter.UpdateCommand.Parameters.Add("@emp_id", SqlDbType.Char, 9, "emp_id");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@fname", SqlDbType.VarChar, 20, "fname");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@minit", SqlDbType.Char, 1, "minit");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@lname", SqlDbType.VarChar, 30, "lname");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@job_id", SqlDbType.SmallInt, 0, "job_id");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@job_lvl", SqlDbType.TinyInt, 0, "job_lvl");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@pub_id", SqlDbType.Char, 4, "pub_id");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@hire_date", SqlDbType.DateTime, 0, "hire_date");

            sqlDataAdapter.InsertCommand = new SqlCommand("InsertEmployee", sqlConnection);
            sqlDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            sqlDataAdapter.InsertCommand.Parameters.Add("@emp_id", SqlDbType.Char, 9, "emp_id");
            sqlDataAdapter.InsertCommand.Parameters.Add("@fname", SqlDbType.VarChar, 20, "fname");
            sqlDataAdapter.InsertCommand.Parameters.Add("@minit", SqlDbType.Char, 1, "minit");
            sqlDataAdapter.InsertCommand.Parameters.Add("@lname", SqlDbType.VarChar, 30, "lname");
            sqlDataAdapter.InsertCommand.Parameters.Add("@job_id", SqlDbType.SmallInt, 0, "job_id");
            sqlDataAdapter.InsertCommand.Parameters.Add("@job_lvl", SqlDbType.TinyInt, 0, "job_lvl");
            sqlDataAdapter.InsertCommand.Parameters.Add("@pub_id", SqlDbType.Char, 4, "pub_id");
            sqlDataAdapter.InsertCommand.Parameters.Add("@hire_date", SqlDbType.DateTime, 0, "hire_date");

            sqlDataAdapter.DeleteCommand = new SqlCommand("DeleteEmployee", sqlConnection);
            sqlDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

            sqlDataAdapter.DeleteCommand.Parameters.Add("@emp_id", SqlDbType.Char, 9, "emp_id");

            dataTable = new();




        }

        public int ExecuteNonQuery(string SPName, Dictionary<string, object> Parameters = null)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = SPName;
                if (Parameters != null)
                {
                    foreach (var param in Parameters)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter(param.Key, param.Value));
                    }
                }
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
            finally { sqlConnection.Close(); }

        }
        public object ExecuteScalar(string SPName, Dictionary<string, object> Parameters = null)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = SPName;
                if (Parameters != null)
                {
                    foreach (var param in Parameters)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter(param.Key, param.Value));
                    }
                }
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                return sqlCommand.ExecuteScalar();
            }
            finally { sqlConnection.Close(); }

        }
        public DataTable ExecuteDataTable(string SPName, Dictionary<string, object> Parameters = null)
        {

            dataTable.Clear();
            sqlDataAdapter.SelectCommand.CommandText = SPName;
            sqlDataAdapter.SelectCommand.Parameters.Clear();
            if (Parameters != null)
            {
                foreach (var param in Parameters)
                {
                    sqlDataAdapter.SelectCommand.Parameters.Add(
                        new SqlParameter(param.Key, param.Value));
                }
            }
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public void SaveChanges(DataTable dataTable)
        {
            sqlDataAdapter.Update(dataTable);
        }
    }
}

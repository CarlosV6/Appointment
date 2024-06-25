using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelperSQL
{
    public class ExecSQL
    {
        private readonly string _connectionString = String.Empty;
        private readonly IConfiguration _iConfiguration;
        public ExecSQL()
        {
            var builder = new ConfigurationBuilder()
                 .AddJsonFile("appsettingsSql.json", optional: true, reloadOnChange: true);
            _iConfiguration = builder.Build();
            var _iconfigurationSql = _iConfiguration.GetSection("SQLConfiguration");
            _connectionString = @$"Data Source = {_iconfigurationSql["Server"]}; Initial Catalog ={_iconfigurationSql["DataBase"]}; User ID = {_iconfigurationSql["User"]}; Password = {_iconfigurationSql["PassWord"]}; Connection Timeout = {_iconfigurationSql["TimeOut"]}; Integrated Security ={_iconfigurationSql["integratedSecurity"]}; TrustServerCertificate ={_iconfigurationSql["trustServerCertificate"]}";
        }
        public DataTable RunScript(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(_connectionString);
            SqlCommand cmdCommand = new SqlCommand();
            SqlDataAdapter daExecDs = new SqlDataAdapter();
            try
            {
                SqlConn.ConnectionString = _connectionString;
                if ((SqlConn.State != ConnectionState.Open))
                {
                    SqlConn.Open();
                }
                cmdCommand.CommandText = query;
                cmdCommand.CommandType = CommandType.Text;
                cmdCommand.Connection = SqlConn;

                daExecDs.SelectCommand = cmdCommand;
                daExecDs.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the script: " + ex.Message);
            }
            finally
            {
                cmdCommand.Dispose();
                daExecDs.Dispose();
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }
        public DataTable RunSP(string storedProcedure)
        {
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection SqlConn = new SqlConnection();
            SqlDataAdapter daExecDs = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                SqlConn.ConnectionString = _connectionString;
                if ((SqlConn.State != ConnectionState.Open))
                {
                    SqlConn.Open();
                }
                cmdCommand.CommandText = storedProcedure;
                cmdCommand.CommandType = CommandType.StoredProcedure;
                cmdCommand.Connection = SqlConn;
                daExecDs.SelectCommand = cmdCommand;
                daExecDs.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing a stored procedur: " + ex.Message);
            }
            finally
            {
                cmdCommand.Dispose();
                daExecDs.Dispose();
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }
        public DataTable RunDataSetSP(string storedProcedure, Hashtable Parameters)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlCommand cmdCommand = new SqlCommand();
            SqlDataAdapter daExecDs = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                SqlConn.ConnectionString = _connectionString;
                if ((SqlConn.State != ConnectionState.Open))
                {
                    SqlConn.Open();
                }
                cmdCommand.CommandText = storedProcedure;
                cmdCommand.CommandType = CommandType.StoredProcedure;
                cmdCommand.Connection = SqlConn;
                if (!(Parameters == null))
                {
                    string Col;
                    foreach (object KeyHash in Parameters.Keys)
                    {
                        Col = KeyHash.ToString()!;
                        cmdCommand.Parameters.AddWithValue(Col.ToString(), Parameters[Col]);
                    }
                }

                daExecDs.SelectCommand = cmdCommand;
                daExecDs.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ES04 - An error occurred while executing a stored procedur: " + ex.Message);
            }
            finally
            {
                cmdCommand.Dispose();
                daExecDs.Dispose();
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }
    }
}

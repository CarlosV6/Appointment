using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using HelperModels;

namespace HelperSQL
{
    public class ExecSQL(ConfigurationSQL _ConfigurationSQL)
    {
        private readonly string _connectionString = @$"Data Source = {_ConfigurationSQL.Server}; Initial Catalog ={_ConfigurationSQL.DataBase}; User ID = {_ConfigurationSQL.User}; Password = {_ConfigurationSQL.PassWord}; Connection Timeout = {_ConfigurationSQL.TimeOut}; Integrated Security ={_ConfigurationSQL.integratedSecurity}; TrustServerCertificate ={_ConfigurationSQL.trustServerCertificate}";

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

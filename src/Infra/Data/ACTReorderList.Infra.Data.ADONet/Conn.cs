﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ACTReorderList.Infra.Data.ADONet
{
    public class Conn
    {
        private readonly SqlConnection _c;

        public Conn()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ReorderList"].ConnectionString;

            _c = new SqlConnection(connectionString);
        }

        private void OpenConnection()
        {
            switch (_c.State)
            {
                case ConnectionState.Broken:
                    _c.Close();
                    _c.Open();
                    break;
                case ConnectionState.Closed:
                    _c.Open();
                    break;
            }
        }

        private void CloseConnection()
        {
            if (_c.State != ConnectionState.Closed) _c.Close();
        }

        public DataSet ExecuteProcedureDataSet(string name, params SqlParameter[] parameters)
        {
            DataSet ret = new DataSet();
            SqlCommand cmd = null;

            try
            {
                OpenConnection();

                cmd = _c.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = name;

                if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(ret);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                CloseConnection();
            }

            return ret;
        }

        public int ExecuteProcedureNonQuery(string name, params SqlParameter[] parameters)
        {
            int ret;
            SqlCommand cmd = null;

            try
            {
                OpenConnection();
                
                cmd = _c.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = name;

                if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);

                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                CloseConnection();
            }

            return ret;
        }

        public DataSet ExecuteQueryDataSet(string query, params SqlParameter[] parameters)
        {
            DataSet ret = new DataSet();
            SqlCommand cmd = null;

            try
            {
                OpenConnection();

                cmd = _c.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(ret);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                CloseConnection();
            }

            return ret;
        }

        public int ExecuteQueryNonQuery(string query, params SqlParameter[] parameters)
        {
            int ret;
            SqlCommand cmd = null;

            try
            {
                OpenConnection();

                cmd = _c.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);

                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                CloseConnection();
            }

            return ret;
        }
    }
}
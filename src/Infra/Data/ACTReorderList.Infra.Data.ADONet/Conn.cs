using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ACTReorderList.Infra.Data.ADONet
{
    public class Conn
    {
        private readonly SqlConnection _c;

        public Conn()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

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

        public DataSet ExecuteProcedureDataSet(string name, IList<SqlParameter> parameters = null)
        {
            DataSet ret = new DataSet();
            SqlCommand cmd = null;

            try
            {
                OpenConnection();

                cmd = _c.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = name;

                if (parameters != null) cmd.Parameters.AddRange(parameters.ToArray());

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

        public int ExecuteProcedureNonQuery(string name, IList<SqlParameter> parameters = null)
        {
            int ret;
            SqlCommand cmd = null;

            try
            {
                OpenConnection();
                
                cmd = _c.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = name;

                if (parameters != null) cmd.Parameters.AddRange(parameters.ToArray());

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

        public DataSet ExecuteQueryDataSet(string query, IList<SqlParameter> parameters = null)
        {
            DataSet ret = new DataSet();
            SqlCommand cmd = null;

            try
            {
                OpenConnection();

                cmd = _c.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                if (parameters != null) cmd.Parameters.AddRange(parameters.ToArray());

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

        public int ExecuteQueryNonQuery(string query, IList<SqlParameter> parameters = null)
        {
            int ret;
            SqlCommand cmd = null;

            try
            {
                OpenConnection();

                cmd = _c.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return ret;
        }
    }
}
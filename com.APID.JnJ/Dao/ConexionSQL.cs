using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Control
{
    public class ConexionSQL
    {
        private SqlConnection connection;
        public SqlDataAdapter adapter;
        public SqlCommand command;
        public string strConection = "";


        public ConexionSQL(String connectionString)
        {
            try
            {
                if (String.IsNullOrEmpty(connectionString))
                    throw new Exception("Conexion no valida");

                connection = new SqlConnection(connectionString);
            }
            catch (SqlException ex)
            {

                throw new Exception(String.Format("Error desconocido {0}", ex.Message));
            }

        }

        public ConexionSQL()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BDconnectionString"].ConnectionString;


                if (String.IsNullOrEmpty(connectionString))
                    throw new Exception("Conexion no valida");

                connection = new SqlConnection(connectionString);
            }
            catch (SqlException ex)
            {

                throw new Exception(String.Format("Error desconocido {0}", ex.Message));
            }
        }

        public int ExecuteStatementNoneReturnRows(String transactSqlStatement)
        {
            try
            {
                // Abre la conexion
                connection.Open();
                SqlCommand cmd = new SqlCommand(transactSqlStatement, connection);

                // ejecuta el comando
                cmd.CommandType = CommandType.Text;

                // retorna el numero de rgistros afectados
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;

            }
            catch (SqlException exSql)
            {

                throw new ApplicationException(String.Format("Error sql {0}", exSql.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error generico {0}", ex.Message));
            }
            finally
            {
                // Valida el estado de la conexion, si la conexion no está cerrada la cierra
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public DataTable ExecuteQuery(String transactSqlStatement)
        {
            try
            {
                // Abre la conexion
                connection.Open();

                // Crea variable de Tipo SqlCommand
                SqlCommand cmd = new SqlCommand(transactSqlStatement, connection);

                // define el tipo de CommandType
                cmd.CommandType = CommandType.Text;

                // crea objeto de tipo SqlDataAdapter
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                // crea objeto de tipo DataTable
                DataTable tblResultFromQuery = new DataTable();

                // llena la tabla con los resltados
                sqlDataAdapter.Fill(tblResultFromQuery);

                // returna la tabla de resultado
                return tblResultFromQuery;

            }
            catch (SqlException exSql)
            {

                throw new ApplicationException(String.Format("Error sql {0}", exSql.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error generico {0}", ex.Message));
            }
            finally
            {
                // Valida el estado de la conexion, si la conexion no está cerrada la cierra
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public DataTable ExecuteQueryconParameters(String transactSqlStatement,String Parametr)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(transactSqlStatement, connection);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                DataTable tblResultFromQuery = new DataTable();

                sqlDataAdapter.Fill(tblResultFromQuery);

                return tblResultFromQuery;

            }
            catch (SqlException exSql)
            {

                throw new ApplicationException(String.Format("Error sql {0}", exSql.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error generico {0}", ex.Message));
            }
            finally
            {
                // Valida el estado de la conexion, si la conexion no está cerrada la cierra
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        private bool conectar()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public bool comando(string comando)
        {
            bool ret = false;
            try
            {
                if (conectar())
                {
                    SqlCommand cmd = new SqlCommand(comando, connection);
                    cmd.ExecuteNonQuery();
                    ret = true;
                }
            }
            catch { }
            connection.Close();
            return ret;
        }

        public DataTable consulta(string comando)
        {
            DataTable ret = new DataTable();
            try
            {
                if (conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter(comando, connection);
                    da.Fill(ret);
                }
            }
            catch { } connection.Close();
            return ret;
        }

        public void Abrir_Conexion(string path, string usuario)
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BDconnectionString"].ConnectionString);
                connection.Open();
            }
            catch (SqlException sqlError)
            {
            }
        }

        public void Cerrar_Conexion()
        {
            this.connection.Close();
        }

        public bool Crud(string sql, string path, string usuario)
        {
            try
            {
                command = new SqlCommand(sql, this.connection);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        public DataTable Select(string sql, string path, string usuario)
        {
            try
            {
                DataSet dataSet = new DataSet();
                adapter = new SqlDataAdapter(sql, this.connection);
                adapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (SqlException sqlError)
            {
                return null;
            }
        }


    }
}

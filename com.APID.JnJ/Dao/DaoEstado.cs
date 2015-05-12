using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Modelo;
using Dao;
using Control;

namespace Dao
{
    public class DaoEstado : CRUDestados
    {
        private ConexionSQL conexion = new ConexionSQL();

        public int insert(object obj)
        {
            try
            {
                if (obj is VoEstados)
                {
                    VoEstados newEstado = (VoEstados)obj;
                    String sql = String.Format("insert into dbo.APID_ESTADOS values ('{0}','{1}','{2}','{3}')", newEstado.NombreEstado1, newEstado.NombreReferencia_Estado1, newEstado.Fecha_Creacion1, newEstado.NombreReferencia_Tipo1);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Estado de objeto no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("EstadoDao: " + ex.Message);
            }
        }

        public int update(int codigo, String nombre, String referencia_estado, String referencia_tipo)
        {
            try
            {
                //VoCargos newCargo = (VoCargos)obj;
                String sql = String.Format(" UPDATE [dbo].[APID_ESTADOS] SET [NOMBRE_ESTADO] = '{1}', [REFERENCIA_ESTADO] = '{2}',[REFERENCIA_TIPO] = '{3}'   WHERE [ID_ESTADO] = {0}",
                                              codigo, nombre, referencia_estado,referencia_tipo);
                Console.Write(sql);
                return conexion.ExecuteStatementNoneReturnRows(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("EstadoDao: " + ex.Message);
            }
        }

        public int delete(int id)
        {
            try
            {
                if (id != null)
                {
                    String sql = String.Format("DELETE FROM dbo.APID_ESTADOS WHERE ID_ESTADO = {0}", id);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Estado de ID no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("EstadoDao: " + ex.Message);
            }
        }

        public DataTable ConsultarSQLTodos()
        {
            try
            {
                String sql = String.Format("SELECT * FROM dbo.APID_ESTADOS");

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    return tblResults;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public object findById(string id)
        {
            try
            {
                String sql = String.Format("SELECT * FROM dbo.APID_ESTADOS where ID_ESTADO = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoEstados newEstado = new VoEstados()
                    {
                        IdCodigo = int.Parse(row["ID_ESTADO"].ToString()),
                        NombreEstado1 = row["NOMBRE_ESTADO"].ToString(),
                        NombreReferencia_Estado1 = row["REFERENCIA_ESTADO"].ToString(),
                        NombreReferencia_Tipo1 = row["REFERENCIA_TIPO"].ToString(),
                    };
                    return newEstado;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error desconocido {0} ", ex.Message));
            }
        }

        public object ConsultarSQL(int id)
        {
            try
            {
                String sql = String.Format("SELECT * FROM dbo.APID_ESTADOS WHERE ID_ESTADO = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoEstados newEstado = new VoEstados()
                    {
                        IdCodigo = int.Parse(row["ID_ESTADO"].ToString()),
                        NombreEstado1 = row["NOMBRE_ESTADO"].ToString(),
                        NombreReferencia_Estado1 = row["REFERENCIA_ESTADO"].ToString(),
                        NombreReferencia_Tipo1 = row["REFERENCIA_TIPO"].ToString(),
                    };
                    return newEstado;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error desconocido {0} ", ex.Message));
            }
        }

        public DataTable ConsultarSQLTodosLIKE(String nombre)
        {
            try
            {
                String sql = String.Format("SELECT * FROM dbo.APID_ESTADOS WHERE NOMBRE_ESTADO LIKE '%{0}%'", nombre);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    return tblResults;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ConsultarSQLTodosLIKEParametros(String nombreColumnaTabla, String PalabraClave)
        {
            try
            {
                String sql = String.Format("SELECT * FROM dbo.APID_ESTADOS WHERE " + nombreColumnaTabla + " LIKE '%{0}%'", PalabraClave);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    return tblResults;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

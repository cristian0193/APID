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
    public class DaoAreas : CRUDareas
    {
        private ConexionSQL conexion = new ConexionSQL();

        public int insert(object obj)
        {
            try
            {
                if (obj is VoAreas)
                {
                    VoAreas newAreas = (VoAreas)obj;
                    String sql = String.Format("INSERT INTO dbo.APID_AREAS VALUES ('{0}','{1}')", newAreas.NombreAreas1, newAreas.Fecha_Creacion1);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Prueba de objeto no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("pruebaDao: " + ex.Message);
            }
        }

        public int update(int codigo, String nombre)
        {
            try
            {
                //VoCargos newCargo = (VoCargos)obj;
                String sql = String.Format(" UPDATE [dbo].[APID_AREAS] SET [NOMBRE_AREA] = '{1}' WHERE [ID_AREA] = {0}",
                                              codigo, nombre);
                Console.Write(sql);
                return conexion.ExecuteStatementNoneReturnRows(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("pruebaDao: " + ex.Message);
            }
        }

        public int delete(int id)
        {
            try
            {
                if (id != null)
                {
                    String sql = String.Format("DELETE FROM dbo.APID_AREAS WHERE ID_AREA = {0}", id);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Area de ID no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("DaoArea: " + ex.Message);
            }
        }

        public DataTable ConsultarSQLTodos()
        {
            try
            {
                String sql = String.Format("SELECT * FROM dbo.APID_AREAS");

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
                String sql = String.Format("SELECT * FROM dbo.APID_AREAS where ID_AREA = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoAreas newAreas = new VoAreas()
                    {
                        IdCodigo = int.Parse(row["ID_AREA"].ToString()),
                        NombreAreas1 = row["NOMBRE_AREA"].ToString(),
                    };
                    return newAreas;
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
                String sql = String.Format("SELECT * FROM dbo.AREAS where ID_AREA = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoAreas newPrueba = new VoAreas()
                    {
                        IdCodigo = int.Parse(row["ID_AREA"].ToString()),
                        NombreAreas1 = row["NOMBRE_AREA"].ToString(),

                    };
                    return newPrueba;
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
                String sql = String.Format("SELECT * FROM dbo.APID_AREAS where NOMBRE_AREA LIKE '%{0}%'", nombre);

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

        public DataTable ConsultarSQLTodosLIKEParametros(String nombreColumnaTabla,String PalabraClave)
        {
            try
            {
                String sql = String.Format("SELECT * FROM dbo.APID_AREAS where " + nombreColumnaTabla + " LIKE '%{0}%'", PalabraClave);

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

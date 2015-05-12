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
    public class DaoMaquina : CRUDmaquina
    {
        private ConexionSQL conexion = new ConexionSQL();

        #region Query

        public int insert(object obj)
        {
            try
            {
                if (obj is VoMaquinas)
                {
                    VoMaquinas newMaquina = (VoMaquinas)obj;
                    String sql = String.Format("insert into dbo.APID_MAQUINAS values ('{0}','{1}','{2}')", newMaquina.NombreMaquina1, newMaquina.ReferenciaMaquina1, newMaquina.Planta1);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Prueba de objeto no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("MaquinaDao: " + ex.Message);
            }
        }

        public int update(int codigo, String nombreMaquina, String referenciaMaquina, String Planta)
        {
            try
            {
                String sql = String.Format("UPDATE [APID].[dbo].[APID_MAQUINAS]  SET [NOMBRE_MAQUINA] = '{1}',[REFERENCIA_MAQUINA] = '{2}' ,[ID_CODIGO_PLANTA] = {3} WHERE [ID_MAQUINA] = {0}",
                                              codigo, nombreMaquina, referenciaMaquina, Planta);
                Console.Write(sql);
                return conexion.ExecuteStatementNoneReturnRows(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("MaquinaDao: " + ex.Message);
            }
        }

        public int delete(int id)
        {
            try
            {
                if (id != null)
                {
                    String sql = String.Format("DELETE FROM dbo.APID_MAQUINAS WHERE ID_MAQUINA = {0}", id);
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
                String sql = String.Format("SELECT M.ID_MAQUINA,M.NOMBRE_MAQUINA,M.REFERENCIA_MAQUINA,P.NOMBRE_PLANTA " +
                                           " FROM dbo.APID_MAQUINAS M, dbo.APID_PLANTAS P " +
                                           " WHERE P.ID_PLANTA = M.ID_CODIGO_PLANTA");

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
                //String sql = String.Format("select M.IdCodigo,M.Nombre_Maquina,M.Indicativo_Maquina,P.idCodigo as planta" +
                //                           " FROM dbo.MAQUINAS M, dbo.PLANTAS P  "+
                //                            " WHERE P.idCodigo = M.idCodigo_Planta" +
                //                            " AND M.IdCodigo = {0}", id);

                String sql = String.Format("SELECT M.ID_MAQUINA,M.NOMBRE_MAQUINA,M.REFERENCIA_MAQUINA,P.ID_PLANTA AS PLANTA " +
                                           " FROM dbo.APID_MAQUINAS M, dbo.APID_PLANTAS P " +
                                           " WHERE P.ID_PLANTA = M.ID_CODIGO_PLANTA " +
                                           " AND M.ID_MAQUINA = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoMaquinas newMaquina = new VoMaquinas()
                    {
                        IdCodigo = int.Parse(row["ID_MAQUINA"].ToString()),
                        NombreMaquina1 = row["NOMBRE_MAQUINA"].ToString(),
                        ReferenciaMaquina1 = row["REFERENCIA_MAQUINA"].ToString(),
                        Planta1 = row["PLANTA"].ToString(),
                    };
                    return newMaquina;
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
                String sql = String.Format("SELECT * FROM dbo.APID_MAQUINAS WHERE ID_MAQUINA = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoMaquinas newMaquina = new VoMaquinas()
                    {
                        IdCodigo = int.Parse(row["ID_MAQUINA"].ToString()),
                        NombreMaquina1 = row["NOMBRE_MAQUINA"].ToString(),
                        ReferenciaMaquina1 = row["REFERENCIA_MAQUINA"].ToString(),
                        Planta1 = row["PLANTA"].ToString(),
                    };
                    return newMaquina;
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
                String sql = String.Format("SELECT * FROM dbo.APID_MAQUINAS WHERE NOMBRE_MAQUINA LIKE '%{0}%'", nombre);

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
                String sql = String.Format("SELECT * FROM dbo.APID_MAQUINAS WHERE " + nombreColumnaTabla + " LIKE '%{0}%'", PalabraClave);

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

        #endregion

        #region Procedimiento

        public DataTable ListaPlanta()
        {
            DataTable dt = conexion.consulta("exec cons_planta");
            return dt;
        }

        #endregion

    }
}

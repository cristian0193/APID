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
    public class DaoTipoMaquina : CRUDtipomaquina
    {
        private ConexionSQL conexion = new ConexionSQL();

        #region Query

        public int insert(object obj)
        {
            try
            {
                if (obj is VoTipoMaquinas)
                {
                    VoTipoMaquinas newTipoMaquina = (VoTipoMaquinas)obj;
                    String sql = String.Format("INSERT INTO dbo.APID_PARTES_MAQUINAS VALUES ('{0}','{1}',{2})", newTipoMaquina.NombreTipoMaquina1, newTipoMaquina.referenciaTipoMaquina1, newTipoMaquina.Maquina1);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Prueba de objeto no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("TipoMaquinaDao: " + ex.Message);
            }
        }

        public int update(int codigo, String nombreMaquina, String referenciaMaquina, String Maquina)
        {
            try
            {
                String sql = String.Format("UPDATE [APID].[dbo].[APID_PARTES_MAQUINAS]  SET [NOMBRE_PARTE] = '{1}',[REFERENCIA_PARTE_MAQUINA] = '{2}' ,[ID_CODIGO_MAQUINA] = {3} WHERE [ID_PARTES_MAQUINA] = {0}",
                                              codigo, nombreMaquina, referenciaMaquina, Maquina);
                Console.Write(sql);
                return conexion.ExecuteStatementNoneReturnRows(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("TipoMaquinasDao: " + ex.Message);
            }
        }

        public int delete(int id)
        {
            try
            {
                if (id != null)
                {
                    String sql = String.Format("DELETE FROM dbo.APID_PARTES_MAQUINAS WHERE ID_PARTES_MAQUINA = {0}", id);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Cargo de ID no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("DaoPlanta: " + ex.Message);
            }
        }

        public DataTable ConsultarSQLTodos()
        {
            try
            {
                String sql = String.Format("SELECT P.ID_PARTES_MAQUINA, P.NOMBRE_PARTE,P.REFERENCIA_PARTE_MAQUINA,M.NOMBRE_MAQUINA " +
                                           " FROM dbo.APID_MAQUINAS M, dbo.APID_PARTES_MAQUINAS p  " +
                                           " WHERE P.ID_CODIGO_MAQUINA = M.ID_MAQUINA ");

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
                String sql = String.Format("SELECT P.ID_PARTES_MAQUINA, P.NOMBRE_PARTE,P.REFERENCIA_PARTE_MAQUINA,M.ID_MAQUINA AS MAQUINA " +
                                           " FROM dbo.APID_MAQUINAS M, dbo.APID_PARTES_MAQUINAS P  " +
                                            " WHERE P.ID_CODIGO_MAQUINA = M.ID_MAQUINA " +
                                            " AND P.ID_PARTES_MAQUINA = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoTipoMaquinas newMaquina = new VoTipoMaquinas()
                    {
                        IdCodigo = int.Parse(row["ID_PARTES_MAQUINA"].ToString()),
                        NombreTipoMaquina1 = row["NOMBRE_PARTE"].ToString(),
                        referenciaTipoMaquina1 = row["REFERENCIA_PARTE_MAQUINA"].ToString(),
                        Maquina1 = row["MAQUINA"].ToString(),
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
                String sql = String.Format("SELECT * FROM dbo.APID_PARTES_MAQUINAS WHERE ID_PARTES_MAQUINA = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoTipoMaquinas newMaquina = new VoTipoMaquinas()
                    {
                        IdCodigo = int.Parse(row["ID_PARTES_MAQUINA"].ToString()),
                        NombreTipoMaquina1 = row["NOMBRE_PARTE"].ToString(),
                        referenciaTipoMaquina1 = row["REFERENCIA_PARTE_MAQUINA"].ToString(),
                        Maquina1 = row["MAQUINA"].ToString(),
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
                String sql = String.Format("SELECT * FROM dbo.APID_PARTES_MAQUINAS WHERE NOMBRE_PARTE LIKE '%{0}%'", nombre);

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
                String sql = String.Format("SELECT * FROM dbo.APID_PARTES_MAQUINAS WHERE " + nombreColumnaTabla + " LIKE '%{0}%'", PalabraClave);

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

        public DataTable ListaMaquina()
        {
            DataTable dt = conexion.consulta("exec cons_maquina");
            return dt;
        }

        #endregion

    }
}

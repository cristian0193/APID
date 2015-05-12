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
    public class DaoPlanta : CRUDplanta
    {
        private ConexionSQL conexion = new ConexionSQL();

        public int insert(object obj)
        {
            try
            {
                if (obj is VoPlanta)
                {
                    VoPlanta newPlanta = (VoPlanta)obj;
                    String sql = String.Format("INSERT INTO dbo.APID_PLANTAS VALUES ('{0}','{1}','{2}')", newPlanta.NombrePlanta1, newPlanta.ReferenciaPlanta1, newPlanta.Fecha_Creacion1);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Prueba de objeto no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("PlantaDao: " + ex.Message);
            }
        }

        public int update(int codigo, String nombre, String referencia)
        {
            try
            {
                //VoCargos newCargo = (VoCargos)obj;
                String sql = String.Format(" UPDATE [dbo].[APID_PLANTAS] SET [NOMBRE_PLANTA] = '{1}', [REFERENCIA_PLANTA] = '{2}'  WHERE [ID_PLANTA] = {0}",
                                              codigo, nombre, referencia);
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
                    String sql = String.Format("DELETE FROM dbo.APID_PLANTAS WHERE ID_PLANTA = {0}", id);
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
                String sql = String.Format("SELECT * FROM dbo.APID_PLANTAS");

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
                String sql = String.Format("SELECT * FROM dbo.APID_PLANTAS WHERE ID_PLANTA = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoPlanta newPlanta = new VoPlanta()
                    {
                        IdCodigo = int.Parse(row["ID_PLANTA"].ToString()),
                        NombrePlanta1 = row["NOMBRE_PLANTA"].ToString(),
                        ReferenciaPlanta1 = row["REFERENCIA_PLANTA"].ToString(),
                    };
                    return newPlanta;
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
                String sql = String.Format("SELECT * FROM dbo.APID_PLANTAS WHERE ID_PLANTA = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoPlanta newPlanta = new VoPlanta()
                    {
                        IdCodigo = int.Parse(row["ID_PLANTA"].ToString()),
                        NombrePlanta1 = row["NOMBRE_PLANTA"].ToString(),
                        ReferenciaPlanta1 = row["REFERENCIA_PLANTA"].ToString(),
                    };
                    return newPlanta;
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
                String sql = String.Format("SELECT * FROM dbo.APID_PLANTAS WHERE NOMBRE_PLANTA LIKE '%{0}%'", nombre);

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
                String sql = String.Format("SELECT * FROM dbo.APID_PLANTAS WHERE " + nombreColumnaTabla + " LIKE '%{0}%'", PalabraClave);

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

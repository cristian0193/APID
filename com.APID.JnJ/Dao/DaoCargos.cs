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
    public class DaoCargos : CRUDcargos
    {
        private ConexionSQL conexion = new ConexionSQL();

        public int insert(object obj)
        {
            try
            {
                if (obj is VoCargos)
                {
                    VoCargos newCargo = (VoCargos)obj;
                    String sql = String.Format("insert into dbo.APID_CARGOS values ('{0}','{1}')", newCargo.NombreCargos1, newCargo.Fecha_Creacion1);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Prueba de objeto no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("cargoDao: " + ex.Message);
            }
        }

        public int update(int codigo, String nombre)
        {
            try
            {
                //VoCargos newCargo = (VoCargos)obj;
                String sql = String.Format(" UPDATE [dbo].[APID_CARGOS] SET [NOMBRE_CARGO] = '{1}' WHERE [ID_CARGO] = {0}",
                                              codigo, nombre);
                Console.Write(sql);
                return conexion.ExecuteStatementNoneReturnRows(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("cargoDao: " + ex.Message);
            }
        }

        public int delete(int id)
        {
            try
            {
                if (id != null)
                {
                    String sql = String.Format("DELETE FROM dbo.APID_CARGOS WHERE ID_CARGO = {0}", id);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Cargo de ID no valido");
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
                String sql = String.Format("SELECT * FROM dbo.APID_CARGOS");

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
                String sql = String.Format("SELECT * FROM dbo.APID_CARGOS WHERE ID_CARGO = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoCargos newCargo = new VoCargos()
                    {
                        IdCodigo = int.Parse(row["ID_CARGO"].ToString()),
                         NombreCargos1 = row["NOMBRE_CARGO"].ToString(),
                    };
                    return newCargo;
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
                String sql = String.Format("SELECT * FROM dbo.APID_CARGOS WHERE ID_CARGO = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoCargos newPrueba = new VoCargos()
                    {
                        IdCodigo = int.Parse(row["ID_CARGO"].ToString()),
                        NombreCargos1 = row["NOMBRE_CARGO"].ToString(),

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
                String sql = String.Format("select * from dbo.APID_CARGOS where NOMBRE_CARGO LIKE '%{0}%'", nombre);

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
                String sql = String.Format("SELECT * FROM dbo.APID_CARGOS WHERE " + nombreColumnaTabla + " LIKE '%{0}%'", PalabraClave);

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

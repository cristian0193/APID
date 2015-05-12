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
    public class DaoTipoPlanos : CRUDtipoplano
    {
        private ConexionSQL conexion = new ConexionSQL();

        public int insert(object obj)
        {
            try
            {
                if (obj is VoTiposPlano)
                {
                    VoTiposPlano newTipoPlano = (VoTiposPlano)obj;
                    String sql = String.Format("INSERT INTO dbo.APID_TIPOS_PLANOS VALUES ('{0}','{1}','{2}')", newTipoPlano.NombreTipo1, newTipoPlano.Referencia1, newTipoPlano.Fecha_Creacion1);
                    return conexion.ExecuteStatementNoneReturnRows(sql);
                }
                else
                {
                    throw new Exception("Prueba de objeto no valido");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("TipoPlanosDao: " + ex.Message);
            }
        }

        public int update(int codigo, String nombre, String referencia)
        {
            try
            {
                //VoCargos newCargo = (VoCargos)obj;
                String sql = String.Format(" UPDATE [dbo].[APID_TIPOS_PLANOS] SET [NOMBRE_TIPO] = '{1}', [REFERENCIA_TIPO_PLANO] = '{2}'  WHERE [ID_TIPO_PLANOS] = {0}",
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
                    String sql = String.Format("DELETE FROM dbo.APID_TIPOS_PLANOS WHERE ID_TIPO_PLANOS = {0}", id);
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
                String sql = String.Format("SELECT * FROM dbo.APID_TIPOS_PLANOS");

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
                String sql = String.Format("SELECT * FROM dbo.APID_TIPOS_PLANOS WHERE ID_TIPO_PLANOS = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoTiposPlano newTipoPlanos = new VoTiposPlano()
                    {
                        IdCodigo = int.Parse(row["ID_TIPO_PLANOS"].ToString()),
                        NombreTipo1 = row["NOMBRE_TIPO"].ToString(),
                        Referencia1 = row["REFERENCIA_TIPO_PLANO"].ToString(),
                    };
                    return newTipoPlanos;
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
                String sql = String.Format("SELECT * FROM dbo.APID_TIPOS_PLANOS WHERE ID_TIPO_PLANOS = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoTiposPlano newTipoPlanos = new VoTiposPlano()
                    {
                        IdCodigo = int.Parse(row["ID_TIPO_PLANOS"].ToString()),
                        NombreTipo1 = row["NOMBRE_TIPO"].ToString(),
                        Referencia1 = row["REFERENCIA_TIPO_PLANO"].ToString(),
                    };
                    return newTipoPlanos;
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
                String sql = String.Format("SELECT * FROM dbo.APID_TIPOS_PLANOS WHERE NOMBRE_TIPO LIKE '%{0}%'", nombre);

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
                String sql = String.Format("SELECT * FROM dbo.APID_TIPOS_PLANOS WHERE " + nombreColumnaTabla + " LIKE '%{0}%'", PalabraClave);

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

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
    public class DaoRoles : CRUDroles
    {
        private ConexionSQL conexion = new ConexionSQL();

        public int insert(object obj)
        {
            try
            {
                if (obj is VoRoles)
                {
                    VoRoles newRoles = (VoRoles)obj;
                    String sql = String.Format("insert into dbo.ROLES values ('{0}','{1}')", newRoles.NombreRoles1, newRoles.Fecha_Creacion1);
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
                String sql = String.Format(" UPDATE [dbo].[ROLES] SET [Nombre_Rol] = '{1}' WHERE [idRol] = {0}",
                                              codigo, nombre);
                Console.Write(sql);
                return conexion.ExecuteStatementNoneReturnRows(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("pruebaDao: " + ex.Message);
            }
        }

        public DataTable ConsultarSQLTodos()
        {
            try
            {
                String sql = String.Format("select * from dbo.ROLES");

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
                String sql = String.Format("select * from dbo.ROLES where idRol = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoRoles newRoles = new VoRoles()
                    {
                         IdRoles = int.Parse(row["idRol"].ToString()),
                         NombreRoles1 = row["Nombre_Rol"].ToString(),
                    };
                    return newRoles;
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
                String sql = String.Format("select * from dbo.ROLES where idRol = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoRoles newRoles = new VoRoles()
                    {
                        IdRoles = int.Parse(row["idRol"].ToString()),
                        NombreRoles1 = row["Nombre_Rol"].ToString(),

                    };
                    return newRoles;
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
                String sql = String.Format("select * from dbo.ROLES where Nombre_Rol LIKE '%{0}%'",nombre);

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

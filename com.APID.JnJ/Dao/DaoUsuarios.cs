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
    public class DaoUsuarios : CRUDusuarios
    {
        private ConexionSQL conexion = new ConexionSQL();

        #region Query

        public int insert(object obj)
        {
            try
            {
                if (obj is VoUsuarios)
                {
                    VoUsuarios newUsuario = (VoUsuarios)obj;
                    String sql = String.Format("insert into dbo.USUARIOS values ({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12})", newUsuario.Wwid, newUsuario.Nombres1, newUsuario.Apellidos1,newUsuario.Password1,newUsuario.Celular1,newUsuario.CorreoElectronico1,newUsuario.FechaCreacion1,newUsuario.TituloProfesional1,newUsuario.Observaciones1,newUsuario.Areas1,newUsuario.Cargos1,newUsuario.Roles1,newUsuario.Estado1);
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

        public int update(int codigo, String nombre, String apellido, String password, String celular, String correo, String titulo, String Observacion, String area, String cargo, String rol, String estado)
        {
            try
            {
                String sql = String.Format("UPDATE [APID].[dbo].[USUARIOS]  SET [Nombres] = '{1}',[Apellidos] = '{2}' ,[Password] = '{3}' ,[Celular] = '{4}' ,[CorreoElectronico] = '{5}' ,[TituloProfecional] = '{6}' ,[Observacion] = '{7}' ,[idAreas] = {8} ,[idCargos] = {9} ,[idRol] = {10} ,[idEstado] = {11} WHERE [wwid] = {0}",
                                              codigo, nombre, apellido, password, celular,correo,titulo,Observacion,area,cargo,rol,estado);
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
                String sql = String.Format("select U.wwid,U.Nombres,U.Apellidos,U.Celular,U.CorreoElectronico,E.Nombre_Estado"+
                                           " from dbo.USUARIOS U, dbo.ESTADOS E "+
                                           " WHERE U.idEstado = E.idEstado");

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
                String sql = String.Format("SELECT U.wwid,U.Nombres,U.Apellidos,U.Password,U.Celular,U.CorreoElectronico,U.TituloProfecional,U.Observacion,A.idAreas as area,C.idCargos as cargo,R.idRol as rol,E.idEstado as estado " +
                                           " FROM dbo.USUARIOS U, dbo.AREAS A, dbo.CARGOS C, dbo.ESTADOS E, dbo.ROLES R"+
                                            " WHERE u.idAreas = A.idAreas" +
                                            " AND u.idCargos = C.idCargos" +
                                            " AND u.idRol = R.idRol" +
                                            " AND u.idEstado = E.idEstado" +
                                            " AND u.wwid = {0}", id);    

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoUsuarios newUsuario = new VoUsuarios()
                    {
                         Wwid = int.Parse(row["wwid"].ToString()),
                         Nombres1 = row["Nombres"].ToString(),
                         Apellidos1 = row["Apellidos"].ToString(),
                         Password1 = row["Password"].ToString(),
                         Celular1 = row["Celular"].ToString(),
                         CorreoElectronico1 = row["CorreoElectronico"].ToString(),
                         TituloProfesional1 = row["TituloProfecional"].ToString(),
                         Observaciones1 = row["Observacion"].ToString(),
                         Areas1 = row["area"].ToString(),
                         Cargos1 = row["cargo"].ToString(),
                         Roles1 = row["rol"].ToString(),
                         Estado1 = row["estado"].ToString(),
                    };
                    return newUsuario;
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
                String sql = String.Format("select * from dbo.USUARIOS where wwid = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoUsuarios newUsuario = new VoUsuarios()
                    {
                        Wwid = int.Parse(row["wwid"].ToString()),
                        Nombres1 = row["Nombres"].ToString(),
                        Apellidos1 = row["Apellidos"].ToString(),
                        Password1 = row["Password"].ToString(),
                        Celular1 = row["Celular"].ToString(),
                        CorreoElectronico1 = row["CorreoElectronico"].ToString(),
                        TituloProfesional1 = row["TituloProfecional"].ToString(),
                        Observaciones1 = row["Observacion"].ToString(),
                        Areas1 = row["idAreas"].ToString(),
                        Cargos1 = row["idCargos"].ToString(),
                        Roles1 = row["idRol"].ToString(),
                        Estado1 = row["idEstado"].ToString(),
                    };
                    return newUsuario;
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
                String sql = String.Format("select * from dbo.USUARIOS where Nombres LIKE '%{0}%'",nombre);

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

        public DataTable ListaAreas()
        {
            DataTable dt = conexion.consulta("exec cons_areas");
            return dt;
        }

        public DataTable ListaCargo()
        {
            DataTable dt = conexion.consulta("exec cons_cargo");
            return dt;
        }


        public DataTable ListaRoles()
        {
            DataTable dt = conexion.consulta("exec cons_roles");
            return dt;
        }


        public DataTable ListaEstado()
        {
            DataTable dt = conexion.consulta("exec cons_estado");
            return dt;
        }


        #endregion



    }
}

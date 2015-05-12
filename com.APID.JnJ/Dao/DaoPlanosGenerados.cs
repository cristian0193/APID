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
    public class DaoPlanosGenerados : CRUDplanosgenerados
    {
        private ConexionSQL conexion = new ConexionSQL();

        #region QueryCreacionNuevoPlano

        public int insert(object obj)
        {
            try
            {
                if (obj is VoPlanosGenerados)
                {
                    VoPlanosGenerados newUsuario = (VoPlanosGenerados)obj;
                    String sql = String.Format("INSERT INTO dbo.APID_PLANOS_GENERADOS VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", newUsuario.CodigoGenerado1, newUsuario.Consecutivo1, newUsuario.Revision1, newUsuario.Descripcion1, newUsuario.RazonCreacion1, "getDate()", newUsuario.RutaPlano1, newUsuario.Usuario1, "6", newUsuario.Elaborador1);
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

        public int update(int codigo, String Descripcion, String usuario, String elaborador, String Razoncreacion, String Ruta)
        {
            try
            {
                String sql = String.Format("UPDATE [APID].[dbo].[APID_PLANOS_GENERADOS] SET [DESCRIPCION] = '{1}' ,[ID_WWID] = '{2}' ,[WWID_ELABORADOR] = '{3}',[RAZON_CREACION] = '{4}' ,[RUTA_PLANO] = '{5}' WHERE [ID_PLANOS_GENERADOS] = {0}",
                                              codigo, Descripcion, usuario, elaborador, Razoncreacion, Ruta);
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
                    String sql = String.Format("DELETE FROM dbo.APID_PLANOS_GENERADOS WHERE ID_PLANOS_GENERADOS = {0}", id);
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
                String sql = String.Format("SELECT P.ID_PLANOS_GENERADOS,P.CODIGO_GENERADO+''+P.CONSECUTIVO+' REV.'+P.REVISION AS CODIGOS_GENERADOS,P.DESCRIPCION "
                                          +" FROM dbo.APID_PLANOS_GENERADOS P");

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
                String sql = String.Format("SELECT P.ID_PLANOS_GENERADOS, P.CODIGO_GENERADO,P.CONSECUTIVO,P.REVISION,P.DESCRIPCION,P.RAZON_CREACION,P.RUTA_PLANO,U.ID_WWID as USUARIO,WWID_ELABORADOR as ELABORADOR,E.NOMBRE_ESTADO as ESTADO, P.ULTIMA_FECHA_ACTUALIZADA " +
                                           " FROM dbo.APID_USUARIOS U,dbo.APID_ESTADOS E, dbo.APID_PLANOS_GENERADOS P "+
                                           " WHERE P.ID_ESTADO = E.ID_ESTADO "+
                                           " AND P.ID_WWID = U.WWID " +
                                           " AND P.ID_PLANOS_GENERADOS = {0}", id);    

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoPlanosGenerados newUsuario = new VoPlanosGenerados()
                    {
                        idCodigoCodigo1 = Convert.ToInt32(row["ID_PLANOS_GENERADOS"].ToString()),
                        CodigoGenerado1 = row["CODIGO_GENERADO"].ToString(),
                        Consecutivo1 = row["CONSECUTIVO"].ToString(),
                        Revision1 = row["REVISION"].ToString(),
                        Descripcion1 = row["DESCRIPCION"].ToString(),
                        RazonCreacion1 = row["RAZON_CREACION"].ToString(),
                        RutaPlano1 = row["RUTA_PLANO"].ToString(),
                         Elaborador1 = row["ELABORADOR"].ToString(),
                         Usuario1 = row["USUARIO"].ToString(),
                         Estado1 = row["ESTADO"].ToString(),
                        UltimaFechaActualizacion1 = row["ULTIMA_FECHA_ACTUALIZADA"].ToString(),
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
                String sql = String.Format("SELECT * FROM dbo.APID_PLANOS_GENERADOS WHERE ID_PLANOS_GENERADOS = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoPlanosGenerados newUsuario = new VoPlanosGenerados()
                    {
                        idCodigoCodigo1 = Convert.ToInt32(row["ID_PLANOS_GENERADOS"].ToString()),
                        CodigoGenerado1 = row["CODIGO_GENERADO"].ToString(),
                        Consecutivo1 = row["CONSECUTIVO"].ToString(),
                        Revision1 = row["REVISION"].ToString(),
                        Descripcion1 = row["DESCRIPCION"].ToString(),
                        RazonCreacion1 = row["RAZON_CREACION"].ToString(),
                        RutaPlano1 = row["RUTA_PLANO"].ToString(),                        
                        Usuario1 = row["USUARIO"].ToString(),
                        Estado1 = row["ESTADO"].ToString(),                        

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
                String sql = String.Format("SELECT * FROM dbo.APID_PLANOS_GENERADOS WHERE DESCRIPCION LIKE '%{0}%'", nombre);

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
                String sql = String.Format("SELECT * FROM dbo.APID_PLANOS_GENERADOS WHERE " + nombreColumnaTabla + " LIKE '%{0}%'", PalabraClave);

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

        #region QueryActualizarPlano

        public DataTable ConsultarSQLTodosOficiales()
        {
            try
            {
                String sql = String.Format("SELECT p.ID_PLANOS_GENERADOS,P.CODIGO_GENERADO+''+P.CONSECUTIVO+' REV.'+P.REVISION AS CODIGOS_GENERADOS,P.DESCRIPCION "
                                          + " FROM dbo.APID_PLANOS_GENERADOS P, dbo.APID_ESTADOS E  "
                                          + " WHERE P.ID_ESTADO = E.ID_ESTADO "
                                          + " AND E.REFERENCIA_ESTADO = 'OFI' ");

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

        public object findByIdActualizacion(string id)
        {
            try
            {
                String sql = String.Format("SELECT P.ID_PLANOS_GENERADOS, P.CODIGO_GENERADO,P.CONSECUTIVO,P.REVISION,P.DESCRIPCION,P.RAZON_CREACION,P.RUTA_PLANO,U.ID_WWID as USUARIO,WWID_ELABORADOR as ELABORADOR,E.NOMBRE_ESTADO as ESTADO, P.ULTIMA_FECHA_ACTUALIZADA " +
                                           " FROM dbo.APID_USUARIOS U,dbo.APID_ESTADOS E, dbo.APID_PLANOS_GENERADOS P " +
                                           " WHERE P.ID_ESTADO = E.ID_ESTADO " +
                                           " AND P.ID_WWID = U.WWID " +
                                           " AND P.ID_PLANOS_GENERADOS = {0}", id);

                DataTable tblResults = conexion.ExecuteQuery(sql);

                if (tblResults.Rows.Count > 0)
                {
                    DataRow row = tblResults.Rows[0];

                    VoPlanosGenerados newUsuario = new VoPlanosGenerados()
                    {
                        idCodigoCodigo1 = Convert.ToInt32(row["id_planosGenerados"].ToString()),
                        CodigoGenerado1 = row["Codigo_Generado"].ToString(),
                        Consecutivo1 = row["Consecutivo"].ToString(),
                        Revision1 = row["Revision"].ToString(),
                        Descripcion1 = row["Descripcion"].ToString(),
                        RazonCreacion1 = row["Razon_Creacion"].ToString(),
                        RutaPlano1 = row["RutaPlano"].ToString(),
                        Elaborador1 = row["elaborador"].ToString(),
                        Usuario1 = row["usuario"].ToString(),
                        Estado1 = row["estado"].ToString(),
                        UltimaFechaActualizacion1 = row["UltimaFechaActualizada"].ToString(),
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

        #endregion


        #region ProcedimineotCreacionPlano


        public DataTable codigo_plano_final(int cod_tipo_planta, int cod_planta, int cod_maquina, int cod_partes_maquina)
        {
            DataTable dt = conexion.consulta("exec cons_codigo_plano_final " + cod_tipo_planta + "," + cod_planta + "," + cod_maquina + "," + cod_partes_maquina + "");
            return dt;
        }

        public DataTable codigo_planos(String codigos_generados)
        {
            DataTable dt = conexion.consulta("exec cons_codigo_planos '" + codigos_generados + "'");
            return dt;
        }

        public DataTable insertar_datos_Nuevos(String Codigo_Generado, String Consecutivo, String descripcion,String razon_creacion,String RutaPlano, String wwid,String idEstado, String wwidElaborador)
        {                                 
            DataTable dt = conexion.consulta("exec ins_datos '" + Codigo_Generado + "'" + "," + "'" + Consecutivo + "'"+  "," + "'" + descripcion + "'"+ "," + "'" +razon_creacion + "'"+ "," + "'" +RutaPlano + "'"+ "," + "'" + wwid + "'"+ "," + "'" + idEstado + "'"+ "," + "'" + wwidElaborador + "'");
            return dt;             
        }

        public DataTable nuevos_consecutivos(String codigo)
        {
            DataTable dt = conexion.consulta("exec ins_nuevo_consecutivo '" + codigo + "'");
            return dt;
        }

        public DataTable planta()
        {
            DataTable dt = conexion.consulta("exec cons_planta");
            return dt;
        }

        public DataTable maquinas(int cod_planta)
        {
            DataTable dt = conexion.consulta("exec cons_maquinas_parametros '" + cod_planta + "'");
            return dt;
        }

        public DataTable tipo_partes_maquinas(int cod_maquina)
        {
            DataTable dt = conexion.consulta("exec cons_partes_maquinas '" + cod_maquina + "'");
            return dt;
        }

        public DataTable tipo_planos()
        {
            DataTable dt = conexion.consulta("exec cons_tipos_planos");
            return dt;
        }

        public DataTable aprobadores()
        {
            DataTable dt = conexion.consulta("exec cons_aprobadores");
            return dt;
        }

        public DataTable revisores()
        {
            DataTable dt = conexion.consulta("exec cons_revisores");
            return dt;
        }

        #endregion

        #region ProcedimineotActualizacionPlano

        public DataTable ins_nueva_revisiones(String Codigo_Generado, String Consecutivo, int Revision, String Descripcion, String Razon_Creacion, String RutaPlano, String wwid, String wwidElaborador, String idEstado)
        {                                                               
            DataTable dt = conexion.consulta("exec ins_nueva_revision '" + Codigo_Generado + "','" + Consecutivo + "','" + Revision+ "','" + Descripcion + "','" + Razon_Creacion+ "','" + RutaPlano + "','" + wwid+ "','" + wwidElaborador + "','" + idEstado +"'");
            return dt;
        }

         public DataTable upd_version_obsoleta(int codigo, int estado)
        {
            DataTable dt = conexion.consulta("exec upd_version_obsoleta " + codigo + "," +estado);
            return dt;
        }

         public DataTable cons_estadoActual(int codigo)
        {
            DataTable dt = conexion.consulta("exec cons_estadoActual " + codigo);
            return dt;
        }

        #endregion

    }
}

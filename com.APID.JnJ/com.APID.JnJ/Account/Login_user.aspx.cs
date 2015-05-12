using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Dao;
using Control;
using System.Collections;
using System.Configuration;
using System.Data;
using UTILIDADES.Clases;


namespace com.APID.JnJ.Account
{
    public partial class Login_user : System.Web.UI.Page
    {
        #region "Variables"

        private string idUsuario = "";
        private string nombreUsu = "";
        private string apellidoUsu = "";
        private string estado = "";
        private string rol = "";
        private string path = "";
        private ArrayList roles = new ArrayList();
        private User_login user;
        

        #endregion

        #region "Atributos"

        public string Id_usuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombreUsu;
            }
            set
            {
                nombreUsu = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellidoUsu;
            }
            set
            {
                apellidoUsu = value;
            }
        }

        public string Usuario
        {
            get
            {
                return this.TBUsuario.Text;
            }
            set
            {
                this.TBUsuario.Text = value;
            }
        }

        public string Clave
        {
            get
            {
                return this.TBClave.Text;
            }
            set
            {
                this.TBClave.Text = value;
            }
        }

        public string Clave_Nueva
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Activo
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public string Mensaje
        {
            get
            {
                return this.LBError.Text;
            }
            set
            {
                this.LBError.Text = value;
            }
        }

        public ArrayList Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value;
            }
        }

        public string Rol
        {
            get
            {
                return rol;
            }
            set
            {
                rol = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public Menu Menu
        {
            get
            {
                return (Menu)this.Master.FindControl("NavigationMenu");
            }
            set
            {
                Menu menuPrincipal = ((Menu)this.Master.FindControl("NavigationMenu"));
                menuPrincipal = value;
            }
        }

        #endregion

        #region "Web-Form"

        protected void Page_Load(object sender, EventArgs e)
        {
            //limpia los etiquetas de error del sistema.
            this.LBError.Visible = false;
            if (!IsPostBack)
            {

            }
        }

        #endregion

        #region "Button"

        protected void BTingresar_Click(object sender, EventArgs e)
        {
            Iniciar_Sesion();
        }

        #endregion

        #region "Metodos"

        public void Iniciar_Sesion()
        {

            //Encriptar la clave de acceso del usuario.
            Encriptar encriptar = new Encriptar();

            ConexionSQL con = new ConexionSQL();

            con.Abrir_Conexion("", "");

            DataTable usu = con.Select("SELECT PASSWORD,NOMBRES,APELLIDOS,USUARIO,WWID from dbo.APID_USUARIOS WHERE USUARIO = '" + this.TBUsuario.Text.Trim() + "'", "", "");
            if (usu != null && usu.Rows.Count > 0)
            {
                if (encriptar.DesencriptarPassword(usu.Rows[0]["PASSWORD"].ToString()) == this.TBClave.Text.Trim())
                {
                    String valo = "SELECT ID_ROL from APID_ROLESXUSUARIO where ID_WWID = '" + usu.Rows[0]["WWID"].ToString() + "'";

                    DataTable rol = con.Select("SELECT ID_ROL from APID_ROLESXUSUARIO where ID_WWID = '" + usu.Rows[0]["WWID"].ToString() + "'", "", "");
                    if (rol != null && rol.Rows.Count > 0)
                    {
                        //Carga el usuario logueado
                        user = new User_login();
                        user.IdRol = rol.Rows[0]["ID_ROL"].ToString();
                        user.Nombre = usu.Rows[0]["NOMBRES"].ToString();
                        user.IdUsuario = usu.Rows[0]["WWID"].ToString();
                        user.Usuario = usu.Rows[0]["USUARIO"].ToString();
                        Session["User"] = user;
                        this.Server.Transfer("~/Default.aspx");
                    }
                    else
                    {
                        this.LBError.Visible = true;
                        this.LBError.Text = "El usuario no tiene roles asociados.";
                    }
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "El password ingresado es incorrecto.";
                }
            }
            else
            {
                this.LBError.Visible = true;
                this.LBError.Text = "El usuario ingresado no existe en el sistema.";
            }
            con.Cerrar_Conexion();
        }


        #endregion
    }
}
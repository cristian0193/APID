using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Control;
using Modelo;
using com.APID.JnJ.Account;
using System.Configuration;
using UTILIDADES.Clases;
using System.IO;
using System.Data;

namespace com.APID.JnJ
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        #region "Variables"

        User_login user;

        #endregion

        #region "Web-Form"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                user = (User_login)Session["User"];
                this.LBUser.Text = "Bienvenido: " + user.Nombre;
                this.LoginUser.Text = "Cerrar sesión";
                Menu_Principal(this.NavigationMenu, MapPath(ConfigurationManager.AppSettings.Get("logFile")), user.Usuario, user.IdRol);
            }
        }

        #endregion

        #region "LinkButton"

        protected void LoginUser_Click(object sender, EventArgs e)
        {
            if (LoginUser.Text.Equals("Iniciar sesión"))
            {
                this.Server.Transfer("~/Account/Login_user.aspx");
            }
            else
            {
                this.LoginUser.Text = " ";
                this.LBUser.Text = "";
                Session.Clear();
                Session.Abandon();
                this.Server.Transfer("~/Account/Login_user.aspx");
            }
        }

        #endregion

        #region "Metodo"

        public void Menu_Principal(System.Web.UI.WebControls.Menu menu, string path, string usuario, string rol_user)
        {
            ConexionSQL con = new ConexionSQL();

            con.Abrir_Conexion(path, usuario);
            Menu_Principal menuPrincipal = new Menu_Principal("Menu principal", menu);
            List<SubMenus> subMenus = new List<SubMenus>();
            DataTable listaPadres = con.Select("SELECT * FROM APID_OPCIONES_MENU opm,APID_ROLESXOPCIONES_MENU opr WHERE opr.ID_ROL='" + rol_user + "' AND opm.ID_OPCIONES_MENU=opr.ID_OPCIONES_MENU AND PADRE IS NULL ORDER BY ORDEN", path, usuario);
            for (int i = 0; i < listaPadres.Rows.Count; i++)
            {
                SubMenus subMenu;
                //Verifica la url de la opción de Menu si esta nula significa que el menu es un padre
                if (listaPadres.Rows[i]["URL"].ToString() == null)
                    subMenu = new SubMenus(listaPadres.Rows[i]["DESCRIPCION"].ToString(), i + 1, listaPadres.Rows[i]["IMAGEN"].ToString());
                else
                    subMenu = new SubMenus(listaPadres.Rows[i]["DESCRIPCION"].ToString(), listaPadres.Rows[i]["URL"].ToString(), i + 1, listaPadres.Rows[i]["IMAGEN"].ToString());
                DataTable listaHijos = con.Select("SELECT * FROM APID_OPCIONES_MENU opm,APID_ROLESXOPCIONES_MENU opr WHERE opr.ID_ROL='" + rol_user + "' AND opm.ID_OPCIONES_MENU=opr.ID_OPCIONES_MENU AND PADRE='" + listaPadres.Rows[i]["ID_OPCIONES_MENU"].ToString() + "' ORDER BY ORDEN", path, usuario);
                for (int j = 0; j < listaHijos.Rows.Count; j++)
                {
                    OpcionesSubMenu opcSubMenu = new OpcionesSubMenu(listaHijos.Rows[j]["DESCRIPCION"].ToString(), listaHijos.Rows[j]["URL"].ToString(), j + 1, listaHijos.Rows[j]["IMAGEN"].ToString());
                    subMenu.SetHijos(opcSubMenu);
                }
                menuPrincipal.SetSubMenus(subMenu);
            }
            menuPrincipal.CargarMenuPrincipal();
            con.Cerrar_Conexion();
        }


        #endregion

    }
}
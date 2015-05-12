using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control;
using Dao;
using Modelo;
using System.Data.SqlClient;
using System.Data;


namespace com.APID.JnJ.PaginasWeb.Administrador
{
    public partial class AdminTipoMaquina : System.Web.UI.Page

    {
        private ConexionSQL conexion = new ConexionSQL();
        DaoTipoMaquina elem = new DaoTipoMaquina();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               this.gvTipoMaquinas.DataBind();

               DataTable ListPlantas = new DataTable();

               ListPlantas = elem.ListaMaquina();
               DropDownMaquinas.DataSource = ListPlantas;
               DropDownMaquinas.DataTextField = "NOMBRE_MAQUINA".ToString();
               DropDownMaquinas.DataValueField = "ID_MAQUINA".ToString();
               DropDownMaquinas.DataBind();
            }

            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.LBError0.Visible = false;
            this.LBError0.Text = "";
        }

        protected void BTGuardar_Click(object sender, EventArgs e)
        {

            if(TXTCodigoTipoMaquinas.Text.Equals(""))
            {
                if (ControlMaquinas.insert(Convert.ToString(this.TxTNombreTipoMaquinas.Text), Convert.ToString(this.TxTReferenciaTipoMaquinas.Text), Convert.ToString(this.DropDownMaquinas.SelectedValue)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Guardados con Exito";
                    this.TxTNombreTipoMaquinas.Text = "";
                    this.TXTCodigoTipoMaquinas.Text = "";
                    this.TxTReferenciaTipoMaquinas.Text = "";
                    this.DropDownMaquinas.SelectedIndex = 0;
                    this.gvTipoMaquinas.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Guardar Los Datos";
                    this.TxTNombreTipoMaquinas.Text = "";
                    this.TXTCodigoTipoMaquinas.Text = "";
                    this.TxTReferenciaTipoMaquinas.Text = "";
                    this.DropDownMaquinas.SelectedIndex = 0;
                }
            }
            else if (!TXTCodigoTipoMaquinas.Text.Equals(""))
            {
                if (ControlMaquinas.update(Convert.ToInt32(this.TXTCodigoTipoMaquinas.Text), Convert.ToString(this.TxTNombreTipoMaquinas.Text), Convert.ToString(this.TxTReferenciaTipoMaquinas.Text), Convert.ToString(this.DropDownMaquinas.SelectedValue.ToString())) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Actualizados con Exito";
                    this.TxTNombreTipoMaquinas.Text = "";
                    this.TXTCodigoTipoMaquinas.Text = "";
                    this.TxTReferenciaTipoMaquinas.Text = "";
                    this.DropDownMaquinas.SelectedIndex = 0;
                    this.DropDownMaquinas.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Actualizar los Datos";
                    this.TxTNombreTipoMaquinas.Text = "";
                    this.TXTCodigoTipoMaquinas.Text = "";
                    this.TxTReferenciaTipoMaquinas.Text = "";
                    this.DropDownMaquinas.SelectedIndex = 0;
                }
            }


            

        }

        protected void BTBuscar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            VoTipoMaquinas n = ControlTipoMaquinas.findById(id);

            if (n != null)
            {
                TXTCodigoTipoMaquinas.Text = n.IdCodigo.ToString();
                TxTNombreTipoMaquinas.Text = n.NombreTipoMaquina1;
                TxTReferenciaTipoMaquinas.Text = n.referenciaTipoMaquina1;
                DropDownMaquinas.SelectedValue = n.Maquina1;
            }
        }

        protected void BTEliminar_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            int val = Convert.ToInt32(id);
            int n = ControlMaquinas.delete(val);


            if (n > 0)
            {
                this.gvTipoMaquinas.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
        }

        protected void BTnuevo_Click(object sender, EventArgs e)
        {
            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.TxTNombreTipoMaquinas.Text = "";
            this.TXTCodigoTipoMaquinas.Text = "";
            this.DropDownMaquinas.SelectedIndex = 0;
        }

        protected void BTBuscar_Click(object sender, EventArgs e)
        {
            String val = this.TextBuscar.Text;
            DaoTipoMaquina dao = new DaoTipoMaquina();
            String Lista = ListaFiltro.SelectedValue.ToString();

            if (val.Equals("") || Lista == "0")
            {
                this.LBError0.Visible = true;
                this.LBError0.Text = "Seleccion/Ingrese Datos";
                this.BTConsultar_ModalPopupExtender.Show();
            }
            else 
            {
                gvTipoMaquinas.DataSource = dao.ConsultarSQLTodosLIKEParametros(Lista, val);
                this.gvTipoMaquinas.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
            
        }
    
    }
}
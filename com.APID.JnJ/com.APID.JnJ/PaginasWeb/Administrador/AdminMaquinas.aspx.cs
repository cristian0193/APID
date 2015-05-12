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
    public partial class AdminMaquinas : System.Web.UI.Page

    {
        private ConexionSQL conexion = new ConexionSQL();
        DaoMaquina elem = new DaoMaquina();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               this.gvMaquinas.DataBind();

               DataTable ListPlantas = new DataTable();

               ListPlantas = elem.ListaPlanta();
               DropDownPlanta.DataSource = ListPlantas;
               DropDownPlanta.DataTextField = "NOMBRE_PLANTA".ToString();
               DropDownPlanta.DataValueField = "ID_PLANTA".ToString();
               DropDownPlanta.DataBind();
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

            if(TXTCodigoMaquinas.Text.Equals(""))
            {
                if (ControlMaquinas.insert(Convert.ToString(this.TxTNombreMaquinas.Text), Convert.ToString(this.TxTReferenciaMaquina.Text), Convert.ToString(this.DropDownPlanta.SelectedValue)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Guardados con Exito";
                    this.TxTNombreMaquinas.Text = "";
                    this.TXTCodigoMaquinas.Text = "";
                    this.TxTReferenciaMaquina.Text = "";
                    this.DropDownPlanta.SelectedIndex = 0;
                    this.gvMaquinas.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Guardar Los Datos";
                    this.TxTNombreMaquinas.Text = "";
                    this.TXTCodigoMaquinas.Text = "";
                    this.TxTReferenciaMaquina.Text = "";
                    this.DropDownPlanta.SelectedIndex = 0;
                }
            }
            else if (!TXTCodigoMaquinas.Text.Equals(""))
            {
                if (ControlMaquinas.update(Convert.ToInt32(this.TXTCodigoMaquinas.Text), Convert.ToString(this.TxTNombreMaquinas.Text), Convert.ToString(this.TxTReferenciaMaquina.Text), Convert.ToString(this.DropDownPlanta.SelectedValue.ToString())) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Actualizados con Exito";
                    this.TxTNombreMaquinas.Text = "";
                    this.TXTCodigoMaquinas.Text = "";
                    this.TxTReferenciaMaquina.Text = "";
                    this.DropDownPlanta.SelectedIndex = 0;
                    this.gvMaquinas.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Actualizar los Datos";
                    this.TxTNombreMaquinas.Text = "";
                    this.TXTCodigoMaquinas.Text = "";
                    this.TxTReferenciaMaquina.Text = "";
                    this.DropDownPlanta.SelectedIndex = 0;
                }
            }


            

        }

        protected void BTBuscar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            VoMaquinas n = ControlMaquinas.findById(id);

            if (n != null)
            {
                TXTCodigoMaquinas.Text = n.IdCodigo.ToString();
                TxTNombreMaquinas.Text = n.NombreMaquina1;
                TxTReferenciaMaquina.Text = n.ReferenciaMaquina1;
                DropDownPlanta.SelectedValue = n.Planta1;
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
                this.gvMaquinas.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
        }

        protected void BTnuevo_Click(object sender, EventArgs e)
        {
            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.TxTNombreMaquinas.Text = "";
            this.TXTCodigoMaquinas.Text = "";
            this.DropDownPlanta.SelectedIndex = 0;
        }

        protected void BTBuscar_Click(object sender, EventArgs e)
        {
            String val = this.TextBuscar.Text;
            DaoMaquina dao = new DaoMaquina();
            String Lista = ListaFiltro.SelectedValue.ToString();

            if (val.Equals("") || Lista == "0")
            {
                this.LBError0.Visible = true;
                this.LBError0.Text = "Seleccion/Ingrese Datos";
                this.BTConsultar_ModalPopupExtender.Show();
            }
            else 
            {
                gvMaquinas.DataSource = dao.ConsultarSQLTodosLIKEParametros(Lista, val);
                this.gvMaquinas.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
            
        }
    
    }
}
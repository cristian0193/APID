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
    public partial class AdminPlantas : System.Web.UI.Page

    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               this.gvPlantas.DataBind();
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

            if(TXTCodigoPlantas.Text.Equals(""))
            {
                if (ControlPlanta.insert(Convert.ToString(this.TxTNombrePlantas.Text), Convert.ToString(this.TxTReferenciaPlantas.Text)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Guardados con Exito";
                    this.TxTNombrePlantas.Text = "";
                    this.TXTCodigoPlantas.Text = "";
                    this.TxTReferenciaPlantas.Text = "";
                    this.gvPlantas.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Guardar Los Datos";
                    this.TxTNombrePlantas.Text = "";
                    this.TXTCodigoPlantas.Text = "";
                    this.TxTReferenciaPlantas.Text = "";
                }
            }
            else if (!TXTCodigoPlantas.Text.Equals(""))
            {
                if (ControlPlanta.update(Convert.ToInt32(this.TXTCodigoPlantas.Text), Convert.ToString(this.TxTNombrePlantas.Text), Convert.ToString(this.TxTReferenciaPlantas.Text)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Actualizados con Exito";
                    this.TxTNombrePlantas.Text = "";
                    this.TXTCodigoPlantas.Text = "";
                    this.TxTReferenciaPlantas.Text = "";
                    this.gvPlantas.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Actualizar los Datos";
                    this.TxTNombrePlantas.Text = "";
                    this.TXTCodigoPlantas.Text = "";
                    this.TxTReferenciaPlantas.Text = "";
                }
            }


            

        }

        protected void BTBuscar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            VoPlanta n = ControlPlanta.findById(id);

            if (n != null)
            {
                TXTCodigoPlantas.Text = n.IdCodigo.ToString();
                TxTNombrePlantas.Text = n.NombrePlanta1;
                TxTReferenciaPlantas.Text = n.ReferenciaPlanta1;
            }
        }

        protected void BTEliminar_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            int val = Convert.ToInt32(id);
            int n = ControlPlanta.delete(val);


            if (n > 0)
            {
                this.gvPlantas.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
        }

        protected void BTnuevo_Click(object sender, EventArgs e)
        {
            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.TxTNombrePlantas.Text = "";
            this.TXTCodigoPlantas.Text = "";
            this.TxTReferenciaPlantas.Text = "";
        }

        protected void BTBuscar_Click(object sender, EventArgs e)
        {
            String val = this.TextBuscar.Text;
            DaoPlanta dao = new DaoPlanta();
            String Lista = ListaFiltro.SelectedValue.ToString();

            if (val.Equals("") || Lista == "0")
            {
                this.LBError0.Visible = true;
                this.LBError0.Text = "Seleccion/Ingrese Datos";
                this.BTConsultar_ModalPopupExtender.Show();
            }
            else 
            {
                gvPlantas.DataSource = dao.ConsultarSQLTodosLIKEParametros(Lista, val);
                this.gvPlantas.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
            
        }
    
    }
}
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
    public partial class AdminEstados : System.Web.UI.Page

    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               this.gvEstados.DataBind();
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

            if(TXTCodigoEstado.Text.Equals(""))
            {
                if (ControlEstado.insert(Convert.ToString(this.TxTNombreEstado.Text), Convert.ToString(this.TxTReferenciaEstado.Text), Convert.ToString(this.TxTReferenciaTipo.Text)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Guardados con Exito";
                    this.TxTNombreEstado.Text = "";
                    this.TXTCodigoEstado.Text = "";
                    this.TxTReferenciaEstado.Text = "";
                    this.TxTReferenciaTipo.Text = "";
                    this.gvEstados.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Guardar Los Datos";
                    this.TxTNombreEstado.Text = "";
                    this.TXTCodigoEstado.Text = "";
                    this.TxTReferenciaEstado.Text = "";
                    this.TxTReferenciaTipo.Text = "";
                }
            }
            else if (!TXTCodigoEstado.Text.Equals(""))
            {
                if (ControlEstado.update(Convert.ToInt32(this.TXTCodigoEstado.Text), Convert.ToString(this.TxTNombreEstado.Text), Convert.ToString(this.TxTReferenciaEstado.Text), Convert.ToString(this.TxTReferenciaTipo.Text)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Actualizados con Exito";
                    this.TxTNombreEstado.Text = "";
                    this.TXTCodigoEstado.Text = "";
                    this.TxTReferenciaEstado.Text = "";
                    this.TxTReferenciaTipo.Text = "";
                    this.gvEstados.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Actualizar los Datos";
                    this.TxTNombreEstado.Text = "";
                    this.TXTCodigoEstado.Text = "";
                    this.TxTReferenciaEstado.Text = "";
                    this.TxTReferenciaTipo.Text = "";
                }
            }


            

        }

        protected void BTBuscar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            VoEstados n = ControlEstado.findById(id);

            if (n != null)
            {
                TXTCodigoEstado.Text = n.IdCodigo.ToString();
                TxTNombreEstado.Text = n.NombreEstado1;
                TxTReferenciaEstado.Text = n.NombreReferencia_Estado1;
                TxTReferenciaTipo.Text = n.NombreReferencia_Tipo1;
            }
        }

        protected void BTEliminar_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            int val = Convert.ToInt32(id);
            int n = ControlEstado.delete(val);


            if (n > 0)
            {
                this.gvEstados.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
        }

        protected void BTnuevo_Click(object sender, EventArgs e)
        {
            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.TxTNombreEstado.Text = "";
            this.TXTCodigoEstado.Text = "";
        }

        protected void BTBuscar_Click(object sender, EventArgs e)
        {
            String val = this.TextBuscar.Text;
            DaoEstado dao = new DaoEstado();
            String Lista = ListaFiltro.SelectedValue.ToString();

            if (val.Equals("") || Lista == "0")
            {
                this.LBError0.Visible = true;
                this.LBError0.Text = "Seleccion/Ingrese Datos";
                this.BTConsultar_ModalPopupExtender.Show();
            }
            else 
            {
                gvEstados.DataSource = dao.ConsultarSQLTodosLIKEParametros(Lista, val);
                this.gvEstados.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
            
        }
    
    }
}
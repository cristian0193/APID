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
    public partial class AdminCargo : System.Web.UI.Page

    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               this.gvCargos.DataBind();
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

            if(TXTCodigoCargo.Text.Equals(""))
            {
                if (ControlCargos.insert(Convert.ToString(this.TxTNombreCargo.Text)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Guardados con Exito";
                    this.TxTNombreCargo.Text = "";
                    this.TXTCodigoCargo.Text = "";
                    this.gvCargos.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Guardar Los Datos";
                    this.TxTNombreCargo.Text = "";
                    this.TXTCodigoCargo.Text = "";
                }
            }
            else if (!TXTCodigoCargo.Text.Equals(""))
            {
                if (ControlCargos.update(Convert.ToInt32(this.TXTCodigoCargo.Text),Convert.ToString(this.TxTNombreCargo.Text)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Actualizados con Exito";
                    this.TxTNombreCargo.Text = "";
                    this.TXTCodigoCargo.Text = "";
                    this.gvCargos.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Actualizar los Datos";
                    this.TxTNombreCargo.Text = "";
                    this.TXTCodigoCargo.Text = "";
                }
            }


            

        }

        protected void BTBuscar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            VoCargos n = ControlCargos.findById(id);

            if (n != null)
            {
                TXTCodigoCargo.Text = n.IdCodigo.ToString();
                TxTNombreCargo.Text = n.NombreCargos1;
            }
        }

        protected void BTEliminar_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            int val = Convert.ToInt32(id);
            int n = ControlCargos.delete(val);


            if (n > 0)
            {
                this.gvCargos.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
        }

        protected void BTnuevo_Click(object sender, EventArgs e)
        {
            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.TxTNombreCargo.Text = "";
            this.TXTCodigoCargo.Text = "";
        }

        protected void BTBuscar_Click(object sender, EventArgs e)
        {
            String val = this.TextBuscar.Text;
            DaoCargos dao = new DaoCargos();
            String Lista = ListaFiltro.SelectedValue.ToString();

            if (val.Equals("") || Lista == "0")
            {
                this.LBError0.Visible = true;
                this.LBError0.Text = "Seleccion/Ingrese Datos";
                this.BTConsultar_ModalPopupExtender.Show();
            }
            else 
            {
                gvCargos.DataSource = dao.ConsultarSQLTodosLIKEParametros(Lista, val);
                this.gvCargos.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
            
        }
    
    }
}
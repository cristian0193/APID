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
    public partial class AdminTiposPlanos : System.Web.UI.Page

    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               this.gvTipoPlanos.DataBind();
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

            if(TXTCodigoTiposPlanos.Text.Equals(""))
            {
                if (ControlTiposPlanos.insert(Convert.ToString(this.TxTNombreTiposPlanos.Text), Convert.ToString(this.TxTReferenciaTiposPlanos.Text)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Guardados con Exito";
                    this.TxTNombreTiposPlanos.Text = "";
                    this.TXTCodigoTiposPlanos.Text = "";
                    this.TxTReferenciaTiposPlanos.Text = "";
                    this.gvTipoPlanos.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Guardar Los Datos";
                    this.TxTNombreTiposPlanos.Text = "";
                    this.TXTCodigoTiposPlanos.Text = "";
                    this.TxTReferenciaTiposPlanos.Text = "";
                }
            }
            else if (!TXTCodigoTiposPlanos.Text.Equals(""))
            {
                if (ControlTiposPlanos.update(Convert.ToInt32(this.TXTCodigoTiposPlanos.Text), Convert.ToString(this.TxTNombreTiposPlanos.Text), Convert.ToString(this.TxTReferenciaTiposPlanos.Text)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Actualizados con Exito";
                    this.TxTNombreTiposPlanos.Text = "";
                    this.TXTCodigoTiposPlanos.Text = "";
                    this.TxTReferenciaTiposPlanos.Text = "";
                    this.gvTipoPlanos.DataBind();
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Actualizar los Datos";
                    this.TxTNombreTiposPlanos.Text = "";
                    this.TXTCodigoTiposPlanos.Text = "";
                    this.TxTReferenciaTiposPlanos.Text = "";
                }
            }


            

        }

        protected void BTBuscar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            VoTiposPlano n = ControlTiposPlanos.findById(id);

            if (n != null)
            {
                TXTCodigoTiposPlanos.Text = n.IdCodigo.ToString();
                TxTNombreTiposPlanos.Text = n.NombreTipo1;
                TxTReferenciaTiposPlanos.Text = n.Referencia1;
            }
        }

        protected void BTEliminar_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            int val = Convert.ToInt32(id);
            int n = ControlTiposPlanos.delete(val);


            if (n > 0)
            {
                this.gvTipoPlanos.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
        }

        protected void BTnuevo_Click(object sender, EventArgs e)
        {
            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.TxTNombreTiposPlanos.Text = "";
            this.TXTCodigoTiposPlanos.Text = "";
            this.TxTReferenciaTiposPlanos.Text = "";
        }

        protected void BTBuscar_Click(object sender, EventArgs e)
        {
            String val = this.TextBuscar.Text;
            DaoTipoPlanos dao = new DaoTipoPlanos();
            String Lista = ListaFiltro.SelectedValue.ToString();

            if (val.Equals("") || Lista == "0")
            {
                this.LBError0.Visible = true;
                this.LBError0.Text = "Seleccion/Ingrese Datos";
                this.BTConsultar_ModalPopupExtender.Show();
            }
            else 
            {
                gvTipoPlanos.DataSource = dao.ConsultarSQLTodosLIKEParametros(Lista, val);
                this.gvTipoPlanos.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
            
        }
    
    }
}
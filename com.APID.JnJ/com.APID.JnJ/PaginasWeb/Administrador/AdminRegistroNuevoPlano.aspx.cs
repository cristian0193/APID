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
    public partial class AdminRegistroNuevoPlano : System.Web.UI.Page

    {
        private ConexionSQL conexion = new ConexionSQL();
        DaoPlanosGenerados elem = new DaoPlanosGenerados();

        protected void Page_Load(object sender, EventArgs e)
        {

            
                if (!IsPostBack)
                {
                    this.gvRegistroPlanos.DataBind();

                    //carga de los aprobadores disponibles en la base de datos
                    DataTable dt8 = new DataTable();

                    dt8 = elem.aprobadores();
                    DropDownAprobador.DataSource = dt8;
                    DropDownAprobador.DataTextField = "USUARIO".ToString();
                    DropDownAprobador.DataValueField = "WWID".ToString();
                    DropDownAprobador.DataBind();

                    //carga de los revisores disponibles en la base de datos
                    DataTable dt9 = new DataTable();
                    dt9 = elem.revisores();
                    DropDownElaborador.DataSource = dt9;
                    DropDownElaborador.DataTextField = "USUARIO".ToString();
                    DropDownElaborador.DataValueField = "WWID".ToString();
                    DropDownElaborador.DataBind();

                    //carga de los tipos de planos disponibles en la base de datos
                    DataTable dt6 = new DataTable();

                    dt6 = elem.tipo_planos();
                    ListaTiposPlanos.DataSource = dt6;
                    ListaTiposPlanos.DataTextField = "NOMBRE_TIPO".ToString();
                    ListaTiposPlanos.DataValueField = "ID_TIPO_PLANOS".ToString();
                    ListaTiposPlanos.DataBind();

                    //carga de los plantas disponibles en la base de datos
                    DataTable dt7 = new DataTable();
                    dt7 = elem.planta();
                    ListaPlanta.DataSource = dt7;
                    ListaPlanta.DataTextField = "NOMBRE_PLANTA".ToString();
                    ListaPlanta.DataValueField = "ID_PLANTA".ToString();
                    ListaPlanta.DataBind();

                }
            

            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.LBError0.Visible = false;
            this.LBError0.Text = "";
        }

        protected void BTGenerar_Codigo(object sender, EventArgs e)
        {
            if (ListaMaquinas.SelectedValue.Equals(""))
            {
                this.LBError1.Text = "SELECCIONE UNA MAQUINA";
            }
            else if (ListaTipoMaquinas.SelectedValue.Equals(""))
            {
                this.LBError1.Text = "";
                this.LBError2.Text = "SELECCIONE UNA PARTE";
            }
            else
            {
                this.LBError1.Text = "";
                this.LBError2.Text = "";
                int codigo1 = Convert.ToInt32(this.ListaTiposPlanos.SelectedValue);
                int codigo2 = Convert.ToInt32(this.ListaPlanta.SelectedValue);
                int codigo3 = Convert.ToInt32(this.ListaMaquinas.SelectedValue);
                int codigo4 = Convert.ToInt32(this.ListaTipoMaquinas.SelectedValue);

                DataTable dt = new DataTable();

                dt = elem.codigo_plano_final(codigo1, codigo2, codigo3, codigo4);

                TxTCodigoPlano.Text = dt.Rows[0]["CODIGOS"].ToString();
            }


        }

        protected void BTGuardar_Click(object sender, EventArgs e)
        {

            if(TXTCodigoRegistro.Text.Equals(""))
            {
                if (ControlPlanosGenerados.insert(Convert.ToString(this.TxTCodigoPlano.Text), Convert.ToString(this.TxTCodigoPlanoConsecutivo.Text), Convert.ToString(this.TxTCodigoPlanoRevision.Text), Convert.ToString(this.TxTDescripcion.Text), Convert.ToString(this.TxtObservacion.Text), Convert.ToString(this.FileUploadRuta.FileName), Convert.ToString(this.DropDownAprobador.SelectedValue), Convert.ToString(this.TXTEstado.Text), Convert.ToString(this.DropDownElaborador.SelectedValue)) > 0)
                {
                    //limpia los mensajes de errores generados
                    this.LBError.Text = "";
                    this.LBOk.Text = "";

                    //declaracion objetos para carturar datos de tabla
                    DataTable datos_codigo_plano = new DataTable();
                    DataTable contado_datos_codigos_generados = new DataTable();
                    DataTable insertar_datos_Nuevos = new DataTable();
                    DataTable nuevo_consecutivo = new DataTable();

                    //se pasa la consulta del dato generado
                    String codigogenerado = TxTCodigoPlano.Text;
                    contado_datos_codigos_generados = elem.codigo_planos(codigogenerado);

                    int contador = Convert.ToInt32(contado_datos_codigos_generados.Rows.Count.ToString());

                    if (contador == 0)//codigo nuevo
                    {
                        //datos_codigo_plano.Rows[0]["Codigos"].ToString();
                        String codigogenerado1 = codigogenerado;
                        String descripcion = TxTDescripcion.Text;
                        String razon = TxtObservacion.Text;
                        String ruta = FileUploadRuta.ToString();
                        String elaborador = DropDownElaborador.SelectedValue.ToString();
                        String aprobador = DropDownAprobador.SelectedValue.ToString();
                        String estado = "6";

                        elem.insertar_datos_Nuevos(codigogenerado1, "001", descripcion, razon, ruta, aprobador, estado, elaborador);
                        this.gvRegistroPlanos.DataBind();
                    }
                    else //codigo encontrado aumento en consecutivo
                    {
                        String cod_generado = TxTCodigoPlano.Text;
                        nuevo_consecutivo = elem.nuevos_consecutivos(cod_generado);

                        int consecutivo = Convert.ToInt32(nuevo_consecutivo.Rows[0]["MAXIMO_CONSECUTIVO"].ToString());
                        consecutivo++;
                        consecutivo.ToString("000");
                        String contador2 = String.Format("{0:000}", consecutivo);

                        String consecutvo_final = Convert.ToString(contador2);

                        String codigogenerado1 = TxTCodigoPlano.Text;
                        String descripcion = TxTDescripcion.Text;
                        String razon = TxtObservacion.Text;
                        String ruta = FileUploadRuta.ToString();
                        String elaborador = DropDownElaborador.SelectedValue.ToString();
                        String aprobador = DropDownAprobador.SelectedValue.ToString();
                        String estado = "13";

                        elem.insertar_datos_Nuevos(codigogenerado1, consecutvo_final, descripcion, razon, ruta, aprobador, estado, elaborador);
                        this.gvRegistroPlanos.DataBind();

                    }


                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Guardar Los Datos";
                    this.TXTCodigoRegistro.Text = "";
                    this.TxTCodigoPlano.Text = "";
                    this.TxTCodigoPlanoConsecutivo.Text = "";
                    this.TxTCodigoPlanoRevision.Text = "";
                    this.DropDownAprobador.SelectedIndex = 0;
                    this.DropDownElaborador.SelectedIndex = 0;
                    this.TxtObservacion.Text = "";
                    this.TXTEstado.Text = "";
                    this.TxTDescripcion.Text = "";
                }
            }
            else if (!LBCodigoPlano.Text.Equals(""))
            {
                if (ControlPlanosGenerados.update(Convert.ToInt32(this.TXTCodigoRegistro.Text), Convert.ToString(this.TxTDescripcion.Text), Convert.ToString(this.DropDownAprobador.SelectedValue), Convert.ToString(this.DropDownElaborador.SelectedValue), Convert.ToString(this.TxtObservacion.Text), Convert.ToString(this.FileUploadRuta.FileName)) > 0)
                {
                    this.LBOk.Visible = true;
                    this.LBOk.Text = "Datos Actualizados con Exito";
                    this.TXTCodigoRegistro.Text = "";
                    this.TxTCodigoPlano.Text = "";
                    this.TxTCodigoPlanoConsecutivo.Text = "";
                    this.TxTCodigoPlanoRevision.Text = "";
                    this.DropDownAprobador.SelectedIndex = 0;
                    this.DropDownElaborador.SelectedIndex = 0;
                    this.TxtObservacion.Text = "";
                    this.TXTEstado.Text = "";
                    this.TxTDescripcion.Text = "";
                }
                else
                {
                    this.LBError.Visible = true;
                    this.LBError.Text = "Error al Actualizar los Datos";
                    this.TXTCodigoRegistro.Text = "";
                    this.TxTCodigoPlano.Text = "";
                    this.TxTCodigoPlanoConsecutivo.Text = "";
                    this.TxTCodigoPlanoRevision.Text = "";
                    this.DropDownAprobador.SelectedIndex = 0;
                    this.DropDownElaborador.SelectedIndex = 0;
                    this.TxtObservacion.Text = "";
                    this.TXTEstado.Text = "";
                    this.TxTDescripcion.Text = "";
                }
            }


            

        }

        protected void BTBuscar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            VoPlanosGenerados n = ControlPlanosGenerados.findById(id);

            if (n != null)
            {
                TXTCodigoRegistro.Text = n.idCodigoCodigo1.ToString();
                TxTCodigoPlano.Text = n.CodigoGenerado1;
                TxTCodigoPlanoConsecutivo.Text = n.Consecutivo1;
                TxTCodigoPlanoRevision.Text = n.Revision1;
                DropDownAprobador.SelectedValue = n.Usuario1;
                DropDownElaborador.SelectedValue = n.Elaborador1;
                TxtObservacion.Text = n.RazonCreacion1;
                TXTEstado.Text = n.Estado1;
                TxTDescripcion.Text = n.Descripcion1;
                
            }
        }

        protected void BTEliminar_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            GridViewRow gvrRow = (GridViewRow)btn.NamingContainer;
            String id = gvrRow.Cells[0].Text;
            int val = Convert.ToInt32(id);
            int n = ControlPlanosGenerados.delete(val);


            if (n > 0)
            {
                this.gvRegistroPlanos.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
        }

        protected void BTnuevo_Click(object sender, EventArgs e)
        {
            this.LBError.Visible = false;
            this.LBError.Text = "";
            this.LBOk.Visible = false;
            this.LBOk.Text = "";
            this.TXTCodigoRegistro.Text = "";
            this.TxTCodigoPlano.Text = "";
            this.TxTCodigoPlanoConsecutivo.Text = "";
            this.TxTCodigoPlanoRevision.Text = "";
            this.DropDownAprobador.SelectedIndex = 0;
            this.DropDownElaborador.SelectedIndex = 0;
            this.TxtObservacion.Text = "";
            this.TXTEstado.Text = "";
            this.TxTDescripcion.Text = "";
        }

        protected void BTBuscar_Click(object sender, EventArgs e)
        {
            String val = this.TextBuscar.Text;
            DaoPlanosGenerados dao = new DaoPlanosGenerados();
            String Lista = ListaFiltro.SelectedValue.ToString();

            if (val.Equals("") || Lista == "0")
            {
                this.LBError0.Visible = true;
                this.LBError0.Text = "Seleccion/Ingrese Datos";
                this.BTConsultar_ModalPopupExtender.Show();
            }
            else 
            {
                gvRegistroPlanos.DataSource = dao.ConsultarSQLTodosLIKEParametros(Lista, val);
                this.gvRegistroPlanos.DataBind();
                this.BTConsultar_ModalPopupExtender.Show();
            }
            
        }

        protected void ListaMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.ListaMaquinas.SelectedValue);


            // carga de las Tipo de Parte disponibles en la base de datos, segun su Maquina
            DataTable dt7 = new DataTable();
            ListaTipoMaquinas.Items.Clear();
            dt7 = elem.tipo_partes_maquinas(codigo);
            ListaTipoMaquinas.DataSource = dt7;
            ListaTipoMaquinas.DataTextField = "NOMBRE_PARTE".ToString();
            ListaTipoMaquinas.DataValueField = "ID_PARTES_MAQUINA".ToString();
            ListaTipoMaquinas.DataBind();
            this.BTGenerarCodigo_ModalPopupExtender1.Show();

        }

        protected void ListaPlanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.ListaPlanta.SelectedValue);

            // carga de las Maquinas disponibles en la base de datos, segun su Planta
            DataTable dt7 = new DataTable();
            ListaMaquinas.Items.Clear();
            dt7 = elem.maquinas(codigo);
            ListaMaquinas.DataSource = dt7;
            ListaMaquinas.DataTextField = "NOMBRE_MAQUINA".ToString();
            ListaMaquinas.DataValueField = "ID_MAQUINA".ToString();
            ListaMaquinas.DataBind();
            this.BTGenerarCodigo_ModalPopupExtender1.Show();
        }

        protected void ListaTipoMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BTGenerarCodigo_ModalPopupExtender1.Show();
        }
    }
}
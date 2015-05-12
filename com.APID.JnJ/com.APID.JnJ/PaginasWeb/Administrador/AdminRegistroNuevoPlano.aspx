<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="AdminRegistroNuevoPlano.aspx.cs" Inherits="com.APID.JnJ.PaginasWeb.Administrador.AdminRegistroNuevoPlano" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.quicksearch.js" type="text/javascript"></script>
    <script src="Script/jquery.quicksearch.js" type="text/javascript"></script>
    <script src="Script/MicrosoftAjax.js" type="text/javascript"></script>
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap.css" rel="stylesheet" />
     <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            width: 121px;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            z-index: 10000;
        }
         .auto-style5 {
             width: 224px;
         }
    .auto-style6 {
        height: 23px;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Styles/bootstrap.css" rel="stylesheet" />
    <table class="auto-style1">
        <tr>
            <td colspan="6">
                <asp:Label ID="LBTitulo" runat="server" CssClass="LabelTitulo"
                    Text="Maquinas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                         <%--PANEL 1--%>
                        <asp:Panel ID="PanelPrincipal" runat="server" CssClass="Panel">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style5">&nbsp;</td>
                                    <td>
                                        <asp:Label ID="LBMensaje" runat="server" CssClass="LabelError"
                                            Text="(*) Campos obligatorios."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="LBDRegistro" runat="server" CssClass="LabelTituloEditar"
                                            Text="Datos del registro:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LBError" runat="server" CssClass="LabelError" Visible="False"></asp:Label>
                                        <asp:Label ID="LBOk" runat="server" CssClass="LabelOk" Visible="False"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style5">&nbsp;
                            <asp:Label ID="LBCodigoRegistro" runat="server" CssClass="Label" Text="  ID PLANO :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTCodigoRegistro" runat="server" CssClass="TextBox" Width="10%" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label1" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBCodigoPlano" runat="server" CssClass="Label" Text="CODIGO DE PLANO :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxTCodigoPlano" runat="server" CssClass="TextBox" Width="70px" Enabled="False"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="TxTCodigoPlanoConsecutivo" runat="server" CssClass="TextBox" Width="70px" Enabled="False" ></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="TxTCodigoPlanoRevision" runat="server" CssClass="TextBox" Width="70px" Enabled="False" ></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label4" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBDescripcion" runat="server" CssClass="Label" Text="DESCRIPCION :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxTDescripcion" runat="server" CssClass="TextBox" Width="791px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label3" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBElaborador" runat="server" CssClass="Label" Text="ELABORADOR:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownElaborador" runat="server" ></asp:DropDownList>                                     
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label5" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBAprobador" runat="server" CssClass="Label" Text="APROBADOR:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownAprobador" runat="server" ></asp:DropDownList>                                
                                    </td>
                                </tr>

                                
                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label2" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBObservaciones" runat="server" CssClass="Label" Text="OBSERVACIONES:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtObservacion" runat="server" TextMode="MultiLine" Height="65px" Width="797px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label6" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBUltimaFechaActualizar" runat="server" CssClass="Label" Text="ULTIM. FECHA ACTUALIZACION:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxUltimaFechaActualizar" runat="server" CssClass="TextBox" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label7" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBEstado" runat="server" CssClass="Label" Text="ESTADO:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTEstado" runat="server" CssClass="TextBox" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label8" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBRutaPlano" runat="server" CssClass="Label" Text="RUTA PLANO:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUploadRuta" runat="server" CssClass="TextBox" Width="455px"/>
                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
        
        <tr>
            <td class="auto-style3">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PNAcciones" runat="server" GroupingText="Acciones" CssClass="Panel" Width="1312px">

                            <asp:Button ID="BTnuevo" runat="server" CssClass="Button"
                                Text="Nuevo" OnClick="BTnuevo_Click" />
                            &nbsp;
                            <asp:Button ID="BTGuardar" runat="server" CssClass="Button"
                                Text="Guardar" ValidationGroup="Guardar" OnClick="BTGuardar_Click" />
                            &nbsp;               
                <asp:Button ID="BTConsultar" runat="server" CssClass="Button"
                    Text="Consultar" />

                             <asp:Button ID="BTGenerarCodigo" runat="server" CssClass="Button"
                    Text="Generar Codigo" />

                            <ajaxToolkit:ModalPopupExtender ID="BTConsultar_ModalPopupExtender" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="BTConsultar" PopupControlID="PNPrueba" BackgroundCssClass="modalBackground">
                            </ajaxToolkit:ModalPopupExtender>

                            <ajaxToolkit:ModalPopupExtender ID="BTGenerarCodigo_ModalPopupExtender1" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="BTGenerarCodigo" PopupControlID="PanelGenerarCodigo" BackgroundCssClass="modalBackground">
                            </ajaxToolkit:ModalPopupExtender>

                        </asp:Panel>
                          </ContentTemplate>
                </asp:UpdatePanel>
             
                        <%--PANEL 2--%>
                        <asp:Panel ID="PNPrueba" runat="server" GroupingText="Tabla de Datos de Maquina" CssClass="Panel" Width="1253px" Height="400px" Style="background: white;">

                            <table class="auto-style1">
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBuscar" runat="server" CssClass="TextBox" Width="35%"></asp:TextBox>
                                        &nbsp;<asp:DropDownList ID="ListaFiltro" runat="server" CssClass="DropDown">
                                            <asp:ListItem value="0">Seleccionar</asp:ListItem>
                                            <asp:ListItem Value="CODIGO_GENERADO">Codigo</asp:ListItem>
                                            <asp:ListItem Value="DESCRIPCION">Descripcion</asp:ListItem>
                                            <asp:ListItem Value="WWID_ELABORADOR">ID Elaborador</asp:ListItem>
                                            <asp:ListItem Value="ID_WWID">ID Aprobador</asp:ListItem>
                                            <asp:ListItem Value="ID_PLANOS_GENERADOS">Todos</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:Button ID="BTbuscar" runat="server" OnClick="BTBuscar_Click" CssClass="Button" Text="Buscar" />
                                        &nbsp;<asp:Label ID="LBError0" runat="server" CssClass="LabelError" Font-Size="Small" Visible="False"></asp:Label>
                                    </td>
                                </tr>


                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="LBMensaje2" runat="server"  Text="* Consultar Todos Los Datos ingrese (%)" Font-Size="Small" ForeColor="Blue"></asp:Label></td>
                                </tr>
                                
                                <tr>
                                    <td colspan="6">&nbsp;</td>
                                </tr>

                                <tr>
                                    <td>
                                        <div style="overflow-y: scroll;" class="scroll">
                                            <center>
                                                <asp:GridView ID="gvRegistroPlanos" runat="server" AutoGenerateColumns="False" CssClass="ui-table" Width="1094px" PageSize="6" >
                                                    <Columns>
                                                        <asp:BoundField DataField="CODIGO_GENERADO" HeaderText="CODIGO PLANO" />
                                                        <asp:BoundField DataField="REVISION" HeaderText="REVISION" />    
                                                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />    
                                                        <asp:BoundField DataField="ID_WWID" HeaderText="APROBADOR" />
                                                        <asp:BoundField DataField="WWID_ELABORADOR" HeaderText="ELABORADOR" />    
                                                        <asp:BoundField DataField="ID_ESTADO" HeaderText="ESTADO" />                                                    
                                                        <asp:TemplateField HeaderText="Opciones">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgConsular" runat="server" ImageUrl="~/Imagenes/search.png" OnClick="BTBuscar_Click" />
                                                                &nbsp;     
                                                                <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Imagenes/delete.png" OnClick="BTEliminar_Click" />                                                     

                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle Width="76px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        NO HAY REGISTROS
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </center>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <center>
                                            <asp:Button ID="BTCerrrar" runat="server" CssClass="Button" Text="Cerrar" />
                                        </center>
                                    </td>
                                </tr>
                            </table>                           
                        </asp:Panel>

                <%--PANEL 3--%>
                <asp:Panel ID="PanelGenerarCodigo" runat="server" GroupingText="Tabla de Datos de Generar Datos" CssClass="Panel" Width="1253px" Height="349px" Style="background: white;">

                    
                        <div class="modal-header">
                            <h3>DATOS DE GENERACION DE CODIGO</h3>
                        </div>

                        <div class="modal-body">

                            <div>


                                <table style="width: 100%">
                                    <tr>
                                        <td align="center" class="auto-style6">
                                            <asp:Label ID="LBTiposPlanos" runat="server" Text="Tipos Planos"></asp:Label></td>
                                        <td class="auto-style6"></td>
                                        <td align="center" class="auto-style6">
                                            <asp:Label ID="LBPlanta" runat="server" Text="Planta"></asp:Label></td>
                                        <td class="auto-style6"></td>
                                        <td align="center" class="auto-style6">
                                            <asp:Label ID="LBMaquina" runat="server" Text="Maquina"></asp:Label></td>
                                        <td class="auto-style6"></td>
                                        <td align="center" class="auto-style6">
                                            <asp:Label ID="LBParteMaquina" runat="server" Text="Parte Maquina"></asp:Label></td>
                                        <td class="auto-style6"></td>
                                    </tr>

                                    <tr>
                                        <td align="center">
                                            <div class="styled-select">
                                                <asp:DropDownList ID="ListaTiposPlanos" runat="server"
                                                    Height="25px" Style="margin-left: 0px; margin-top: 0px;" Width="220px">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td></td>
                                        <td align="center">
                                            <div class="styled-select">
                                                <asp:DropDownList ID="ListaPlanta" AutoPostBack="true" runat="server"
                                                    Height="25px" Style="margin-left: 0px; margin-top: 0px;" Width="220px"
                                                    OnSelectedIndexChanged="ListaPlanta_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td></td>
                                        <td align="center">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="styled-select">
                                                        <asp:DropDownList ID="ListaMaquinas" runat="server" Height="27px" Style="margin-left: 0px"
                                                            Width="220px" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ListaMaquinas_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ListaPlanta" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td></td>
                                        <td align="center">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="styled-select">
                                                        <asp:DropDownList ID="ListaTipoMaquinas" runat="server" Height="27px" Style="margin-left: 0px"
                                                            Width="220px" AutoPostBack="True" OnSelectedIndexChanged="ListaTipoMaquinas_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <br />
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ListaMaquinas" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="LB4" runat="server"></asp:Label></td>
                                        <td></td>
                                        <td align="center">
                                            <asp:Label ID="LB3" runat="server" Text=""></asp:Label></td>
                                        <td></td>
                                        <td align="center">
                                            <asp:Label ID="LBError1" runat="server" Text="*" Font-Bold="True"
                                                Font-Size="Large" ForeColor="Red"></asp:Label></td>
                                        <td></td>
                                        <td align="center">
                                            <asp:Label ID="LBError2" runat="server" Text="*" Font-Bold="True"
                                                Font-Size="Large" ForeColor="Red"></asp:Label></td>
                                        <td></td>
                                    </tr>

                                </table>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">CLOSE</button>
                            <asp:Button ID="BotonGenerar" runat="server" Text="GENERAR" class="btn btn-primary" OnClick="BTGenerar_Codigo"></asp:Button>
                        </div>                   

                </asp:Panel>

            </td>
        </tr>

    </table>
</asp:Content>

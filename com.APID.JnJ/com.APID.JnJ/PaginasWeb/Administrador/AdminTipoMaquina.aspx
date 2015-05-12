<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="AdminTipoMaquina.aspx.cs" Inherits="com.APID.JnJ.PaginasWeb.Administrador.AdminTipoMaquina" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.quicksearch.js" type="text/javascript"></script>
    <script src="Script/jquery.quicksearch.js" type="text/javascript"></script>
    <script src="Script/MicrosoftAjax.js" type="text/javascript"></script>

     <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 177px;
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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="auto-style1">
        <tr>
            <td colspan="6">
                <asp:Label ID="LBTitulo" runat="server" CssClass="LabelTitulo"
                    Text="Parte de Maquinas"></asp:Label>
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
                                    <td class="auto-style2">&nbsp;</td>
                                    <td>
                                        <asp:Label ID="LBMensaje" runat="server" CssClass="LabelError"
                                            Text="(*) Campos obligatorios."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="LBDRegistro" runat="server" CssClass="LabelTituloEditar"
                                            Text="Datos del registro:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LBError" runat="server" CssClass="LabelError" Visible="False"></asp:Label>
                                        <asp:Label ID="LBOk" runat="server" CssClass="LabelOk" Visible="False"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style2">&nbsp;
                            <asp:Label ID="LBCodigoTipoMaquinas" runat="server" CssClass="Label" Text="  CODIGO :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTCodigoTipoMaquinas" runat="server" CssClass="TextBox" Width="10%" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label1" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBNombreTipoMaquinas" runat="server" CssClass="Label" Text="TIPO DE MAQUINA :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxTNombreTipoMaquinas" runat="server" CssClass="TextBox" Width="30%"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label2" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBReferenciaTipoMaquinas" runat="server" CssClass="Label" Text="ESTADO REFERENCIA :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxTReferenciaTipoMaquinas" runat="server" CssClass="TextBox" Width="7%"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label3" runat="server" CssClass="LabelError" Text="*"></asp:Label>
                                        <asp:Label ID="LBMaquinas" runat="server" CssClass="Label" Text="MAQUINAS:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownMaquinas" runat="server" CssClass="DropDown"></asp:DropDownList>                                       
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


                            <ajaxToolkit:ModalPopupExtender ID="BTConsultar_ModalPopupExtender" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="BTConsultar" PopupControlID="PNPrueba" BackgroundCssClass="modalBackground">
                            </ajaxToolkit:ModalPopupExtender>

                        </asp:Panel>
                          </ContentTemplate>
                </asp:UpdatePanel>
             
                        <%--PANEL 2--%>
                        <asp:Panel ID="PNPrueba" runat="server" GroupingText="Tabla de Datos de Maquina" CssClass="Panel" Width="600px" Height="400px" Style="background: white;">

                            <table class="auto-style1">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBuscar" runat="server" CssClass="TextBox" Width="35%" ></asp:TextBox>
                                        &nbsp;<asp:DropDownList ID="ListaFiltro" runat="server" CssClass="DropDown">
                                            <asp:ListItem value="0">Seleccionar</asp:ListItem>
                                            <asp:ListItem Value="ID_PARTES_MAQUINA">ID</asp:ListItem>
                                            <asp:ListItem Value="NOMBRE_PARTE">Nombre</asp:ListItem>
                                            <asp:ListItem Value="REFERENCIA_PARTE_MAQUINA">Referencia</asp:ListItem>
                                            <asp:ListItem Value="ID_CODIGO_MAQUINA">Plantas</asp:ListItem>
                                            <asp:ListItem Value="ID_PARTES_MAQUINA">Todos</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:Button ID="BTbuscar" runat="server" OnClick="BTBuscar_Click" CssClass="Button" Text="Buscar" />
                                        &nbsp;<asp:Label ID="LBError0" runat="server" CssClass="LabelError" Font-Size="Small" Visible="False"></asp:Label>
                                    </td>
                                </tr>


                                <tr>
                                    <td><asp:Label ID="LBMensaje2" runat="server"  Text="* Consultar Todos Los Datos ingrese (%)" Font-Size="Small" ForeColor="Blue"></asp:Label></td>
                                </tr>
                                
                                <tr>
                                    <td colspan="6">&nbsp;</td>
                                </tr>

                                <tr>
                                    <td>
                                        <div style="overflow-y: scroll;" class="scroll">
                                            <center>
                                                <asp:GridView ID="gvTipoMaquinas" runat="server" AutoGenerateColumns="False" CssClass="ui-table" Width="499px" PageSize="6" >
                                                    <Columns>
                                                        <asp:BoundField DataField="ID_PARTES_MAQUINA" HeaderText="ID_PARTE" />
                                                        <asp:BoundField DataField="NOMBRE_PARTE" HeaderText="NOMBRE_PARTE" />    
                                                        <asp:BoundField DataField="REFERENCIA_PARTE_MAQUINA" HeaderText="REFERENCIA" />     
                                                        <asp:BoundField DataField="ID_PARTES_MAQUINA" HeaderText="MAQUINA" />                                                     
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
            </td>
        </tr>

    </table>
</asp:Content>

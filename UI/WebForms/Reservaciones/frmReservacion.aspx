<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmReservacion.aspx.cs" Inherits="UI.WebForms.Reservaciones.frmReservacion" %>

<%@ Register Src="~/WebForms/Base/ControlesGenericos/Mensajes.ascx" TagPrefix="uc1" TagName="Mensajes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="Form1" runat="server">
        <uc1:Mensajes runat="server" ID="Mensajes" />
        <div style="height: 360px; margin-bottom: 110px; margin-left: auto; width: 1200px;">
            <br />
            <div class="divCentradoTitulosPrincipal">
                <asp:Label ID="lblitutloPrincipal" runat="server" CssClass="tituloPrincipal" Text="Proceso General"></asp:Label>
                <br />
                <br />
                <div class="divCentradoTitulosSecundario">
                    <asp:Label ID="lbTitulo" runat="server" CssClass="titulo" Text="Reservaciones"></asp:Label>
                </div>
                <hr class="lineaHorizontal" />
                <br />
            </div>
            <asp:Table runat="server" ID="tbMantenimientoUsuarios">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:GridView ID="tablaReservaciones" runat="server" AllowPaging="true" DataKeyNames="ID_Reservacion" 
                            OnRowDataBound="tablaReservaciones_RowDataBound" AutoGenerateColumns="false" OnDataBinding="tablaReservaciones_DataBinding"
                            OnSelectedIndexChanged="tablaReservaciones_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="ID_Reservacion" HeaderText="ID Reservacion"/>
                                <asp:BoundField DataField="Fecha_Desde" HeaderText="Fecha Desde"/>
                                <asp:BoundField DataField="Fecha_Hasta" HeaderText="Fecha Hasta"/>                                
                                <asp:BoundField DataField="Nombre_Estado" HeaderText="Estado"/>                                
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table runat="server" ID="tbMantenimientoUsuariosBotones">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button runat="server" Text="Consultar" ID="btnConsultar" OnClick="btnConsultar_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button runat="server" Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button runat="server" Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</asp:Content>

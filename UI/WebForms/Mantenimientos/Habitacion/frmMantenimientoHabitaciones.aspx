<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="false" CodeBehind="frmMantenimientoHabitaciones.aspx.cs" Inherits="UI.WebForms.Mantenimientos.Habitacion.frmMantenimientoHabitaciones" %>

<%@ Register Src="~/WebForms/Base/ControlesGenericos/Mensajes.ascx" TagPrefix="uc1" TagName="Mensajes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="Form1" runat="server">
        <uc1:Mensajes runat="server" ID="Mensajes" />
        <div style="height: 360px; margin-bottom: 110px; margin-left: auto; width: 1200px;">
            <br />
            <div class="divCentradoTitulosPrincipal">
                <asp:Label ID="lblitutloPrincipal" runat="server" CssClass="tituloPrincipal" Text="Mantenimientos"></asp:Label>
                <br />
                <br />
                <div class="divCentradoTitulosSecundario">
                    <asp:Label ID="lbTitulo" runat="server" CssClass="titulo" Text="Mantenimiento de Habitaciones"></asp:Label>
                </div>
                <hr class="lineaHorizontal" />
                <br />
            </div>
            <asp:Table runat="server" ID="tbMantenimientoUsuarios">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:GridView ID="tablaHabitaciones" runat="server" AllowPaging="true" DataKeyNames="ID_Habitacion" 
                            OnRowDataBound="tablaHabitaciones_RowDataBound" AutoGenerateColumns="false" OnDataBinding="tablaHabitaciones_DataBinding"
                            OnSelectedIndexChanged="tablaHabitaciones_SelectedIndexChanged">
                            <Columns>                                
                                <asp:BoundField DataField="Numero" HeaderText="Número de Habitación"/>
                                <asp:BoundField DataField="NombreEstado" HeaderText="Estado"/>                                
                                <asp:BoundField DataField="NombreTipo" HeaderText="Tipo"/>                                
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
                        <asp:Button runat="server" Text="Editar" ID="btnEditar" OnClick="btnEditar_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button runat="server" Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmCRUDReservacion.aspx.cs" Inherits="UI.WebForms.Reservaciones.frmCRUDReservacion" %>

<%@ Register Src="~/WebForms/Base/ControlesGenericos/Mensajes.ascx" TagPrefix="uc1" TagName="Mensajes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="Form1" runat="server">
        <uc1:Mensajes runat="server" ID="Mensajes" />
        <div style="height: 460px; margin-bottom: 160px; margin-left: auto; width: 1200px;">
            <br />
            <div class="divCentradoTitulosPrincipal">
                <asp:Label ID="lblitutloPrincipal" runat="server" CssClass="tituloPrincipal" Text="Reservaciones"></asp:Label>
                <br />
                <br />
                <div class="divCentradoTitulosSecundario">
                    <asp:Label ID="lbTitulo" runat="server" CssClass="titulo" Text=""></asp:Label>
                </div>
                <hr class="lineaHorizontal" />
                <br />
            </div>
            <asp:Table runat="server" ID="tbMantenimientoUsuarios">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox TextMode="Date" ID="dateFechaDesde" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox TextMode="Date" ID="dateFechaHasta" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbCantidadAdultos" runat="server" Text="Cant. Adultos:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtCantAdultos" TextMode="Number" MaxLength="9" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lbCantidadNinos" runat="server" Text="Cant. Niños:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtCantidadNinos" TextMode="Number" MaxLength="9" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbCliente" runat="server" Text="Cliente:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlCliente" DataTextField="Nombre_Completo_Ident" runat="server" OnDataBinding="ddlCliente_DataBinding" DataValueField="ID_Cliente">
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lbEstado" runat="server" Text="Estado:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlEstado" runat="server">
                            <asp:ListItem Text="Activo" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Inactivo" Value="11"></asp:ListItem>                            
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbHabitaciones" runat="server" Text="Habitación Disponibles:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ListBox ID="lbxHabitacion" runat="server" Width="300px" Height="200px" DataValueField="ID_Habitacion" DataTextField="Numero" SelectionMode="Multiple" OnDataBinding="lbxHabitacion_DataBinding" AutoPostBack="true">                            
                        </asp:ListBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div>
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </form>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="false" CodeBehind="frmCRUDHabitaciones.aspx.cs" Inherits="UI.WebForms.Mantenimientos.Habitacion.frmCRUDHabitaciones" %>

<%@ Register Src="~/WebForms/Base/ControlesGenericos/Mensajes.ascx" TagPrefix="uc1" TagName="Mensajes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="Form1" runat="server">
        <uc1:Mensajes runat="server" ID="Mensajes" />
        <div style="height: 360px; margin-bottom: 160px; margin-left: auto; width: 1200px;">
            <br />
            <div class="divCentradoTitulosPrincipal">
                <asp:Label ID="lblitutloPrincipal" runat="server" CssClass="tituloPrincipal" Text="Mantenimiento de Habitaciones"></asp:Label>
                <br />
                <br />
                <div class="divCentradoTitulosSecundario">
                    <asp:Label ID="lbTitulo" runat="server" CssClass="titulo" Text=""></asp:Label>
                </div>
                <hr class="lineaHorizontal" />
                <br />
            </div>
            <asp:Table runat="server" ID="tbMantenimientoHabitaciones">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbNumero" runat="server" Text="Número de Habitación:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNumero" MaxLength="50" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lbEstado" runat="server" Text="Estado:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlEstado" runat="server">
                            <asp:ListItem Value="7" Text="Activo"></asp:ListItem>
                            <asp:ListItem Value="8" Text="Inactivo"></asp:ListItem>
                            <asp:ListItem Value="9" Text="Reservado"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbCompania" runat="server" Text="Compañia:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlCompania" DataTextField="Nombre" runat="server" OnDataBinding="ddlCompania_DataBinding" DataValueField="ID_Compania">
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lbCantCamas" runat="server" Text="Cantidad de Camas:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtCantidadCamas" MaxLength="9" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbTipo" runat="server" Text="Tipo:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlTipo" runat="server">
                            <asp:ListItem Value="4" Text="Regular"></asp:ListItem>
                            <asp:ListItem Value="5" Text="Junior Suite"></asp:ListItem>
                            <asp:ListItem Value="6" Text="Suite"></asp:ListItem>
                        </asp:DropDownList>
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

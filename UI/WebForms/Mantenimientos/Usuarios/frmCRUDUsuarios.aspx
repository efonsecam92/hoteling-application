<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmCRUDUsuarios.aspx.cs" Inherits="UI.WebForms.Mantenimientos.Usuarios.frmCRUDUsuarios" %>

<%@ Register Src="~/WebForms/Base/ControlesGenericos/Mensajes.ascx" TagPrefix="uc1" TagName="Mensajes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="Form1" runat="server">
        <uc1:Mensajes runat="server" ID="Mensajes" />
        <div style="height: 360px; margin-bottom: 160px; margin-left: auto; width: 1200px;">
            <br />
            <div class="divCentradoTitulosPrincipal">
                <asp:Label ID="lblitutloPrincipal" runat="server" CssClass="tituloPrincipal" Text="Mantenimiento de Usuario"></asp:Label>
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
                        <asp:Label ID="lbNombreCompleto" runat="server" Text="Nombre Completo:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNombreCompleto" MaxLength="100" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lbNombreUsuario" runat="server" Text="Nombre Usuario:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNombreUsuario" MaxLength="100" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbIdentificacion" runat="server" Text="Identificación:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtIdentificacion" MaxLength="20" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lbPerfil" runat="server" Text="Perfil:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlPerfil" runat="server">
                            <asp:ListItem Value="1" Text="Administrador"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Operativo"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbContrasena" runat="server" Text="Contraseña:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtContrasena" MaxLength="10" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lbCompania" runat="server" Text="Compania:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlCompania" DataTextField="Nombre" runat="server" OnDataBinding="ddlCompania_DataBinding" DataValueField="ID_Compania">                            
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox Text="Estado" ID="cbEstado" runat="server" />
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

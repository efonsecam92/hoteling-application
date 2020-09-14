<%@ Page Title="" Language="C#" MasterPageFile="~/MastePageLogin.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="UI.WebForms.Base.Login.Login" %>

<%@ Register Src="~/WebForms/Base/ControlesGenericos/Mensajes.ascx" TagPrefix="uc1" TagName="Mensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:Mensajes runat="server" ID="Mensajes" />
    <center>       
        <div style="height:470px; margin-bottom:110px; width:600px;">
             <br />
              <br />
            <asp:table runat="server" ID="tableInicioSesion">               
                <asp:TableRow>
                    <asp:TableCell>                        
                        <asp:Label ID="lblTitulo" runat="server" Text="SISTEMA DE GESTIÓN PARA RESERVACIONES"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                </asp:Table>
            <br />
            <br />
            <asp:Table runat="server" ID="tableLogin">                
                       <asp:TableRow>
                           <asp:TableCell>
                               <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                           </asp:TableCell>
                           <asp:TableCell>
                               <asp:TextBox ID="txtUsuario" runat="server" onkeypress="return soloLetras(event);" MaxLength="20"></asp:TextBox>
                               <br />
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtUsuario" Display="Dynamic" runat="server" ForeColor="Red" Text="*Campo requerido"></asp:RequiredFieldValidator>
                           </asp:TableCell>
                       </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox TextMode="Password"  ID="txtClave" runat="server" MaxLength="20"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic"  ControlToValidate="txtClave" runat="server" ForeColor="Red" Text="*Campo requerido"></asp:RequiredFieldValidator>      
                        </asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lbCompania" runat="server" Text="Compañia"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList runat="server" ID="ddlCompania" DataTextField="Nombre" DataValueField="ID_Compania" 
                                OnDataBinding="ddlCompania_DataBinding" ></asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic"  ControlToValidate="ddlCompania" runat="server" ForeColor="Red" Text="*Campo requerido"></asp:RequiredFieldValidator>      
                        </asp:TableCell>
                    </asp:TableRow>
                 </asp:Table>      
            <div style="align-content:center">
                <asp:Button ID="btnLogin" CssClass="ingresar" style="align-content:center" runat="server" Text="Iniciar" OnClick="btnLogin_Click" />
            </div>        
        </div>                    
    </center>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensajes.ascx.cs" Inherits="UI.WebForms.Base.ControlesGenericos.Mensajes" %>

<asp:ValidationSummary CssClass="MensajeError" ValidationGroup="error" ID="sumaryValidacionesErrores" runat="server"  />
<asp:ValidationSummary CssClass="MensajeAdvertencia" ValidationGroup="advertencia" ID="sumaryValidacionesAdvertencia" runat="server"  />
<asp:ValidationSummary CssClass="MensajeInformacion" ValidationGroup="notificacion" ID="sumaryValidacionesInformacion" runat="server"  />
<asp:ValidationSummary CssClass="MensajeExito" ValidationGroup="satisfaccion" ID="sumaryValidacionesSatisfaccion" runat="server"  />







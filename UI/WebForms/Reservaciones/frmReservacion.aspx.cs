using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Utilitarios;
using BI.Reservacion;

namespace UI.WebForms.Reservaciones
{
    public partial class frmReservacion : System.Web.UI.Page
    {
        Rervacion_BI reservacionBI = new Rervacion_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["agregarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha realiza correctamente la reservación");
                    Session.Remove("agregarExitoso");
                }
                tablaReservaciones.DataBind();
            }
            catch (Exception ex)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de cargar la información");
            }
        }

        protected void tablaReservaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(tablaReservaciones, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void tablaReservaciones_DataBinding(object sender, EventArgs e)
        {
            tablaReservaciones.DataSource = reservacionBI.obtenerReservaciones();
        }

        protected void tablaReservaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in tablaReservaciones.Rows)
            {
                if (row.RowIndex == tablaReservaciones.SelectedIndex)
                {
                    Session["reservacionSeleccionada"] = Convert.ToInt32(tablaReservaciones.SelectedValue);
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["reservacionSeleccionada"] != null)
                {
                    Session["funcionalidad"] = 3;
                    Util.redirect("frmCRUDReservacion");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de consultar la reservación");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session["funcionalidad"] = 1;
            Util.redirect("frmCRUDReservacion");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["reservacionSeleccionada"] != null)
                {
                    if (reservacionBI.eliminarReservacion((int)Session["reservacionSeleccionada"]))
                    {
                        Util.agregarMensajeSatisfaccion(this, "Se ha cancelado la reservación correctamente");
                        tablaReservaciones.DataBind();
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar la reservación");
                    }
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
                
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar la reservación");
            }
        }
    }
}
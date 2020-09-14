using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Utilitarios;
using BI.Mantenimientos;

namespace UI.WebForms.Mantenimientos.Habitacion
{
    public partial class frmMantenimientoHabitaciones : System.Web.UI.Page
    {
        Habitaciones_BI habitacionBI = new Habitaciones_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["agregarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha agregado correctamente la habitación");
                    Session.Remove("agregarExitoso");
                }
                else if (Session["editarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha editado correctamente la habitación");
                    Session.Remove("editarExitoso");
                }
                tablaHabitaciones.DataBind();
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de cargar la información");
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["habitacionSeleccionada"] != null)
                {
                    Session["funcionalidad"] = 3;
                    Util.redirect("frmCRUDHabitaciones");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de consultar la habitación");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Util.redirect("frmCRUDHabitaciones");
            Session["funcionalidad"] = 1;

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["habitacionSeleccionada"] != null)
                {
                    Session["funcionalidad"] = 2;
                    Util.redirect("frmCRUDHabitaciones");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de editar la habitación");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["habitacionSeleccionada"] != null)
                {
                    if (habitacionBI.eliminarHabitacion((int)Session["habitacionSeleccionada"]))
                    {
                        Util.agregarMensajeSatisfaccion(this, "Se ha eliminado correctamente la habitación");
                        Session.Remove("habitacionSeleccionada");
                        tablaHabitaciones.DataBind();
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar la habitación");
                    }
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar la habitación");
            }
        }

        protected void tablaHabitaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(tablaHabitaciones, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void tablaHabitaciones_DataBinding(object sender, EventArgs e)
        {
            tablaHabitaciones.DataSource = habitacionBI.listarHabitaciones();

        }

        protected void tablaHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in tablaHabitaciones.Rows)
            {
                if (row.RowIndex == tablaHabitaciones.SelectedIndex)
                {
                    Session["habitacionSeleccionada"] = Convert.ToInt32(tablaHabitaciones.SelectedValue);
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
    }
}
using BI.Mantenimientos;
using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Utilitarios;

namespace UI.WebForms.Mantenimientos.Companias
{
    public partial class frmMantenimientoCompanias : System.Web.UI.Page
    {
        Companias_BI companiaBI = new Companias_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["agregarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha agregado correctamente el compania");
                    Session.Remove("agregarExitoso");
                }
                else if (Session["editarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha editado correctamente el compania");
                    Session.Remove("editarExitoso");
                }
                tablaCompanias.DataBind();
            }
            catch (Exception ex)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de cargar la información");
            }
        }

        /// <summary>
        /// Evento click del botón consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["companiaSeleccionado"] != null)
                {
                    Session["funcionalidad"] = 3;
                    Util.redirect("frmCRUDCompanias");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de consultar el compania");
            }
        }
        /// <summary>
        /// Evento click del botón agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Util.redirect("frmCRUDCompanias");
            Session["funcionalidad"] = 1;
        }
        /// <summary>
        /// Evento click del botón editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["companiaSeleccionado"] != null)
                {
                    Session["funcionalidad"] = 2;
                    Util.redirect("frmCRUDCompanias");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de editar el compania");
            }

        }
        /// <summary>
        /// Evento click del botón eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["companiaSeleccionado"] != null)
                {
                    if (companiaBI.eliminarCompania((int)Session["companiaSeleccionado"]))
                    {
                        Util.agregarMensajeSatisfaccion(this, "Se ha eliminado correctamente el compania");
                        Session.Remove("companiaSeleccionado");
                        tablaCompanias.DataBind();
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar el compania");
                    }
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar el compania");
            }
        }

        /// <summary>
        /// Evento de la selección de un row de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaCompanias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(tablaCompanias, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        /// <summary>
        /// Evento del cambio de selección de un row de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaCompanias_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in tablaCompanias.Rows)
            {
                if (row.RowIndex == tablaCompanias.SelectedIndex)
                {
                    Session["companiaSeleccionado"] = Convert.ToInt32(tablaCompanias.SelectedValue);
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

        /// <summary>
        /// Evento que se encarga de cargar la lista de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaCompanias_DataBinding(object sender, EventArgs e)
        {
            tablaCompanias.DataSource = companiaBI.listarCompanias();
        }
    }
}
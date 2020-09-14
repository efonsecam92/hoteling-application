using BI.Mantenimientos;
using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Utilitarios;

namespace UI.WebForms.Mantenimientos.Clientes
{
    public partial class frmMantenimientoClientes : System.Web.UI.Page
    {
        Clientes_BI clienteBI = new Clientes_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["agregarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha agregado correctamente el cliente");
                    Session.Remove("agregarExitoso");
                }
                else if (Session["editarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha editado correctamente el cliente");
                    Session.Remove("editarExitoso");
                }
                tablaClientes.DataBind();
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
                if (Session["clienteSeleccionado"] != null)
                {
                    Session["funcionalidad"] = 3;
                    Util.redirect("frmCRUDClientes");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de consultar el cliente");
            }
        }
        /// <summary>
        /// Evento click del botón agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Util.redirect("frmCRUDClientes");
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
                if (Session["clienteSeleccionado"] != null)
                {
                    Session["funcionalidad"] = 2;
                    Util.redirect("frmCRUDClientes");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de editar el cliente");
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
                if (Session["clienteSeleccionado"] != null)
                {
                    if (clienteBI.eliminarCliente((int)Session["clienteSeleccionado"]))
                    {
                        Util.agregarMensajeSatisfaccion(this, "Se ha eliminado correctamente el cliente");
                        Session.Remove("clienteSeleccionado");
                        tablaClientes.DataBind();
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar el cliente");
                    }
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar el cliente");
            }
        }

        /// <summary>
        /// Evento de la selección de un row de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(tablaClientes, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        /// <summary>
        /// Evento del cambio de selección de un row de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in tablaClientes.Rows)
            {
                if (row.RowIndex == tablaClientes.SelectedIndex)
                {
                    Session["clienteSeleccionado"] = Convert.ToInt32(tablaClientes.SelectedValue);
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
        protected void tablaClientes_DataBinding(object sender, EventArgs e)
        {
            tablaClientes.DataSource = clienteBI.listarClientes();
        }
    }
}
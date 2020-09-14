using BI.Mantenimientos;
using ENTITIES;
using System;
using UI.Utilitarios;

namespace UI.WebForms.Mantenimientos.Companias
{
    public partial class frmCRUDCompanias : System.Web.UI.Page
    {
        Companias_BI companiasBI = new Companias_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Agregar
                if ((int)Session["funcionalidad"] == 1)
                {
                    lbTitulo.Text = "Agregar";
                }
                //Editar
                else if ((int)Session["funcionalidad"] == 2)
                {
                    lbTitulo.Text = "Editar";
                    obtenerCargarInfoCompania((int)Session["companiaSeleccionado"]);
                }
                else
                {
                    lbTitulo.Text = "Consultar";
                    obtenerCargarInfoCompania((int)Session["companiaSeleccionado"]);
                    Session.Remove("companiaSeleccionado");
                }
            }
        }

        /// <summary>
        /// Método que se encarga de obtener y cargar la información del Compania seleccionado
        /// </summary>
        /// <param name="idCompania"></param>
        private void obtenerCargarInfoCompania(int idCompania)
        {
            try
            {
                SGR_Companias companiaBD = companiasBI.obtenerCompaniaDatos(idCompania);
                txtNombre.Text = companiaBD.Nombre;
                cbEstado.Checked = companiaBD.Estado;                
                //Valida si la funcionalidad es consultar para inhabilitar los componentes
                if ((int)Session["funcionalidad"] != 2)
                {
                    txtNombre.Enabled = false;
                    cbEstado.Enabled = false;                    
                    btnAceptar.Visible = false;
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de obtener la información del Compania");
            }
        }

        /// <summary>
        /// Evento click del botón aceptar - Agrega un nuevo Compania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcionalidad Agregar
                if ((int)Session["funcionalidad"] == 1)
                {
                    SGR_Companias compania = new SGR_Companias
                    {
                        Nombre = txtNombre.Text,
                        Estado = cbEstado.Checked,
                        Fecha_Creacion = DateTime.Now,
                    };
                    if (companiasBI.agregarCompania(compania))
                    {
                        Util.redirect("frmMantenimientoCompanias");
                        Session["agregarExitoso"] = true;
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de agregar el Compania");
                    }
                }
                //Funcionalidad Editar
                else
                {
                    SGR_Companias companiaEditar = new SGR_Companias
                    {
                        ID_Compania = (int)Session["companiaSeleccionado"],
                        Nombre = txtNombre.Text,
                        Estado = cbEstado.Checked,
                        Fecha_Creacion = DateTime.Now,
                    };
                    if (companiasBI.editarCompania(companiaEditar))
                    {
                        Util.redirect("frmMantenimientoCompanias");
                        Session["editarExitoso"] = true;
                        Session.Remove("companiaSeleccionado");
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de editar el Compania");
                    }
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de procesar la información");
            }
        }
        /// <summary>
        /// Evento click del botón cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Util.redirect("frmMantenimientoCompanias");
        }
    }
}
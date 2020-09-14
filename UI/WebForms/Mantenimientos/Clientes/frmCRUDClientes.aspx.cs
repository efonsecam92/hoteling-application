using BI.Mantenimientos;
using ENTITIES;
using System;
using UI.Utilitarios;

namespace UI.WebForms.Mantenimientos.Clientes
{
    public partial class frmCRUDClientes : System.Web.UI.Page
    {
        Clientes_BI clientesBI = new Clientes_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Agregar
                if ((int)Session["funcionalidad"] == 1)
                {
                    lbTitulo.Text = "Agregar";
                    txtFechaCreacion.Text = DateTime.Now.ToString();
                }
                //Editar
                else if ((int)Session["funcionalidad"] == 2)
                {
                    lbTitulo.Text = "Editar";
                    obtenerCargarInfoCliente((int)Session["clienteSeleccionado"]);
                }
                else
                {
                    lbTitulo.Text = "Consultar";
                    obtenerCargarInfoCliente((int)Session["clienteSeleccionado"]);
                    Session.Remove("clienteSeleccionado");
                }
            }
        }

        /// <summary>
        /// Método que se encarga de obtener y cargar la información del cliente seleccionado
        /// </summary>
        /// <param name="idCliente"></param>
        private void obtenerCargarInfoCliente(int idCliente)
        {
            try
            {
                SGR_Clientes clienteBD = clientesBI.obtenerClienteDatos(idCliente);
                txtNombreCompleto.Text = clienteBD.Nombre_Completo;
                txtIdentificacion.Text = clienteBD.Identificacion;
                txtTelefono.Text = clienteBD.Telefono;
                txtCelular.Text = clienteBD.Celular;
                txtCorreo.Text = clienteBD.Correo;
                txtFechaCreacion.Text = clienteBD.Fecha_Creacion.ToString();
                cbEstado.Checked = Convert.ToBoolean(clienteBD.Estado);

                //Valida si la funcionalidad es consultar para inhabilitar los componentes
                if ((int)Session["funcionalidad"] != 2)
                {
                    txtNombreCompleto.Enabled = false;
                    txtIdentificacion.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtCelular.Enabled = false;
                    txtCorreo.Enabled = false;
                    txtFechaCreacion.Enabled = false;
                    cbEstado.Enabled = false;
                    btnAceptar.Visible = false;
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de obtener la información del cliente");
            }
        }

        /// <summary>
        /// Evento click del botón aceptar - Agrega un nuevo cliente
        /// </summary
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcionalidad Agregar
                if ((int)Session["funcionalidad"] == 1)
                {
                    SGR_Clientes cliente = new SGR_Clientes
                    {
                        Nombre_Completo = txtNombreCompleto.Text,
                        Identificacion = txtIdentificacion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Correo = txtCorreo.Text,
                        Fecha_Creacion = DateTime.Now,
                        Estado = cbEstado.Checked,
                       
                    };
                    if (clientesBI.agregarCliente(cliente))
                    {
                        Util.redirect("frmMantenimientoClientes");
                        Session["agregarExitoso"] = true;
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de agregar el cliente");
                    }
                }
                //Funcionalidad Editar
                else
                {
                    SGR_Clientes clienteEditar = new SGR_Clientes
                    {
                        ID_Cliente = (int)Session["clienteSeleccionado"],
                        Nombre_Completo = txtNombreCompleto.Text,
                        Identificacion = txtIdentificacion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Correo = txtCorreo.Text,
                        Fecha_Creacion = Convert.ToDateTime(txtFechaCreacion.Text),
                        Estado = cbEstado.Checked,
                    };
                    if (clientesBI.editarCliente(clienteEditar))
                    {
                        Util.redirect("frmMantenimientoClientes");
                        Session["editarExitoso"] = true;
                        Session.Remove("clienteSeleccionado");
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de editar el cliente");
                    }
                }
            }
            catch (Exception ex)
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
            Util.redirect("frmMantenimientoClientes");
        }
    }
}
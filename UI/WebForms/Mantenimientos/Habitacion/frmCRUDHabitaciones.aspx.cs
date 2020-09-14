using BI.Mantenimientos;
using ENTITIES;
using System;
using UI.Utilitarios;

namespace UI.WebForms.Mantenimientos.Habitacion
{
    public partial class frmCRUDHabitaciones : System.Web.UI.Page
    {
        Habitaciones_BI habitacionBI = new Habitaciones_BI();
        Usuarios_BI usuariosBI = new Usuarios_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCompania.DataBind();
                //Agregar
                if ((int)Session["funcionalidad"] == 1)
                {
                    lbTitulo.Text = "Agregar";
                }
                //Editar
                else if ((int)Session["funcionalidad"] == 2)
                {
                    lbTitulo.Text = "Editar";
                    obtenerCargarInfoHabitacion((int)Session["habitacionSeleccionada"]);
                }
                else
                {
                    btnAceptar.Visible = false;
                    lbTitulo.Text = "Consultar";
                    obtenerCargarInfoHabitacion((int)Session["habitacionSeleccionada"]);
                    Session.Remove("habitacionSeleccionada");
                }
            }
        }

        /// <summary>
        /// Método que se encarga de obtener y cargar la información de la habitación seleccionada
        /// </summary>
        /// <param name="idHabitacion"></param>
        private void obtenerCargarInfoHabitacion(int idHabitacion)
        {
            try
            {
                SGR_Habitaciones habitacionBD = habitacionBI.obtenerHabitacionDatos(idHabitacion);
                txtNumero.Text = habitacionBD.Numero;
                ddlEstado.SelectedValue = habitacionBD.ID_Estado.ToString();
                ddlCompania.SelectedValue = habitacionBD.ID_Compañia.ToString();
                txtCantidadCamas.Text = habitacionBD.Cant_Camas.ToString();
                ddlTipo.SelectedValue = habitacionBD.ID_Tipo.ToString();

                //Valida si la funcionalidad es consultar para inhabilitar los componentes
                if ((int)Session["funcionalidad"] != 2)
                {
                    txtNumero.Enabled = false;
                    ddlEstado.Enabled = false;
                    ddlCompania.Enabled = false;
                    txtCantidadCamas.Enabled = false;
                    ddlTipo.Enabled = false;
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de obtener la información de la habitación");
            }
        }

        /// <summary>
        /// Evento click del botón aceptar - Agrega una nueva habitación
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
                    SGR_Habitaciones habitacion = new SGR_Habitaciones
                    {
                        Numero = txtNumero.Text,
                        ID_Estado = Convert.ToInt32(ddlEstado.SelectedValue),
                        ID_Compañia = Convert.ToInt32(ddlCompania.SelectedValue),
                        Cant_Camas = Convert.ToInt32(txtCantidadCamas.Text),
                        ID_Tipo = Convert.ToInt32(ddlTipo.SelectedValue)
                    };
                    if (habitacionBI.agregarHabitacion(habitacion))
                    {
                        Util.redirect("frmMantenimientoHabitaciones");
                        Session["agregarExitoso"] = true;
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de agregar la habitación");
                    }
                }
                //Funcionalidad Editar
                else
                {
                    SGR_Habitaciones habitacionEditar = new SGR_Habitaciones
                    {
                        ID_Habitacion = (int)Session["habitacionSeleccionada"],
                        Numero = txtNumero.Text,
                        ID_Estado = Convert.ToInt32(ddlEstado.SelectedValue),
                        ID_Compañia = Convert.ToInt32(ddlCompania.SelectedValue),
                        Cant_Camas = Convert.ToInt32(txtCantidadCamas.Text),
                        ID_Tipo = Convert.ToInt32(ddlTipo.SelectedValue)
                    };
                    if (habitacionBI.editarHabitacion(habitacionEditar))
                    {
                        Util.redirect("frmMantenimientoHabitaciones");
                        Session["editarExitoso"] = true;
                        Session.Remove("habitacionSeleccionada");
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de editar la habitación");
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
            Util.redirect("frmMantenimientoHabitaciones");
        }
        /// <summary>
        /// Evento que se encarga de listar las compañias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCompania_DataBinding(object sender, EventArgs e)
        {
            try
            {
                ddlCompania.DataSource = usuariosBI.listarCompaniaSeleccionada((int)Session["compañiaSeleccioanda"]);
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de obtener las compañias");
            }
        }
    }
}
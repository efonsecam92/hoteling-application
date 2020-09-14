using BI.Mantenimientos;
using BI.Reservacion;
using ENTITIES;
using ENTITIES.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UI.Utilitarios;

namespace UI.WebForms.Reservaciones
{
    public partial class frmCRUDReservacion : System.Web.UI.Page
    {
        Rervacion_BI reservacionBI = new Rervacion_BI();
        Habitaciones_BI habitacionBI = new Habitaciones_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlCliente.DataBind();
                    ddlEstado.DataBind();
                    lbxHabitacion.DataBind();
                    //Agregar
                    if ((int)Session["funcionalidad"] == 1)
                    {
                        lbTitulo.Text = "Agregar";
                    }
                    else
                    {
                        lbTitulo.Text = "Consultar";
                        obtenerCargarInfo((int)Session["reservacionSeleccionada"]);
                        Session.Remove("reservacionSeleccionada");
                    }
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de obtener la información de la reservación");
            }
        }

        public void obtenerCargarInfo(int idReservacion)
        {
            try
            {
                btnAceptar.Visible = false;
                dateFechaDesde.Enabled = false;
                dateFechaHasta.Enabled = false;
                txtCantAdultos.Enabled = false;
                txtCantidadNinos.Enabled = false;
                ddlCliente.Enabled = false;
                ddlEstado.Enabled = false;
                lbxHabitacion.Enabled = false;
                Reservacion reservacion = reservacionBI.obtenerInfoReservacion(idReservacion);
                dateFechaDesde.Text = reservacion.Fecha_Desde.ToString("yyyy-MM-dd");
                dateFechaHasta.Text = reservacion.Fecha_Hasta.ToString("yyyy-MM-dd");
                txtCantAdultos.Text = reservacion.Cant_Adultos.ToString();
                txtCantidadNinos.Text = reservacion.Cant_Ninos.ToString();
                ddlCliente.SelectedValue = reservacion.ID_Cliente.ToString();
                ddlEstado.SelectedValue = reservacion.ID_Estado.ToString();
                List<SGR_Habitaciones> listaHabitacion = new List<SGR_Habitaciones>();
                foreach (var reserHabit in reservacion.listaReservacionHabitacion)
                {
                    listaHabitacion.Add(habitacionBI.obtenerHabitacionDatos(Convert.ToInt32(reserHabit.ID_Habitacion)));
                }
                Session["listaHabitacion"] = listaHabitacion;
                lbxHabitacion.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ddlCliente_DataBinding(object sender, EventArgs e)
        {
            ddlCliente.DataSource = reservacionBI.obtenerClientes();
        }
        protected void lbxHabitacion_DataBinding(object sender, EventArgs e)
        {
            if ((int)Session["funcionalidad"] == 1)
            {
                lbxHabitacion.DataSource = reservacionBI.obtenerHabitaciones();
            }
            else
            {
                lbxHabitacion.DataSource = (List<SGR_Habitaciones>)Session["listaHabitacion"];
            }

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(dateFechaDesde.Text) > Convert.ToDateTime(dateFechaHasta.Text))
                {
                    Util.agregarMensajeError(this, "La fecha desde debe ser mayor a la fecha hasta");
                }
                else
                {
                    SGR_Reservaciones reservacion = new SGR_Reservaciones
                    {
                        Fecha_Desde = Convert.ToDateTime(dateFechaDesde.Text),
                        Fecha_Hasta = Convert.ToDateTime(dateFechaHasta.Text),
                        ID_Detalle_Estado = Convert.ToInt32(ddlEstado.SelectedItem.Value),
                        ID_Usuario = (int)Session["usuarioIngresado"],
                        ID_Cliente = Convert.ToInt32(ddlCliente.SelectedItem.Value),
                        Cant_Adultos = Convert.ToInt32(txtCantAdultos.Text),
                        Cant_Ninos = Convert.ToInt32(txtCantidadNinos.Text)
                    };

                    List<int> listaIDHabitaciones = new List<int>();
                    foreach (ListItem listitem in lbxHabitacion.Items)
                    {
                        if (listitem.Selected == true)
                        {
                            listaIDHabitaciones.Add(Convert.ToInt32(listitem.Value));
                        }
                    }

                    foreach (var idHabitacion in listaIDHabitaciones)
                    {
                        SGR_Reservaciones_Habitaciones reservacionHabitaciones = new SGR_Reservaciones_Habitaciones
                        {
                            ID_Habitacion = idHabitacion
                        };
                        reservacion.SGR_Reservaciones_Habitaciones.Add(reservacionHabitaciones);
                    }


                    if (reservacionBI.agregarReservacion(reservacion))
                    {
                        Util.redirect("frmReservacion");
                        Session["agregarExitoso"] = true;
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de agregar la habitación");
                    }
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de procesar la información");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Util.redirect("frmReservacion");
        }
    }
}
using BI.Mantenimientos;
using ENTITIES;
using System;
using UI.Utilitarios;

namespace UI.WebForms.Mantenimientos.Usuarios
{
    public partial class frmCRUDUsuarios : System.Web.UI.Page
    {
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
                    obtenerCargarInfoUsuario((int)Session["usuarioSeleccionado"]);
                }
                else
                {
                    lbTitulo.Text = "Consultar";
                    obtenerCargarInfoUsuario((int)Session["usuarioSeleccionado"]);
                    Session.Remove("usuarioSeleccionado");
                }
            }
        }

        /// <summary>
        /// Método que se encarga de obtener y cargar la información del usuario seleccionado
        /// </summary>
        /// <param name="idUsuario"></param>
        private void obtenerCargarInfoUsuario(int idUsuario)
        {
            try
            {
                SGR_Usuarios usuarioBD = usuariosBI.obtenerUsuarioDatos(idUsuario);
                txtNombreCompleto.Text = usuarioBD.Nombre_Completo;
                txtNombreUsuario.Text = usuarioBD.Nombre_Usuario;
                txtIdentificacion.Text = usuarioBD.Identificacion;
                ddlPerfil.SelectedValue = usuarioBD.ID_Perfil.ToString();
                txtContrasena.Text = usuarioBD.Contrasena;
                ddlCompania.SelectedValue = usuarioBD.ID_Compañia.ToString();
                cbEstado.Checked = usuarioBD.Estado;
                //Valida si la funcionalidad es consultar para inhabilitar los componentes
                if ((int)Session["funcionalidad"] != 2)
                {
                    txtNombreCompleto.Enabled = false;
                    txtNombreUsuario.Enabled = false;
                    txtIdentificacion.Enabled = false;
                    ddlPerfil.Enabled = false;
                    txtContrasena.Enabled = false;
                    ddlCompania.Enabled = false;
                    cbEstado.Enabled = false;
                    btnAceptar.Visible = false;
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de obtener la información del usuario");
            }
        }

        /// <summary>
        /// Evento click del botón aceptar - Agrega un nuevo usuario
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
                    SGR_Usuarios usuario = new SGR_Usuarios
                    {
                        Nombre_Completo = txtNombreCompleto.Text,
                        Nombre_Usuario = txtNombreUsuario.Text,
                        Identificacion = txtIdentificacion.Text,
                        Fecha_Creacion = DateTime.Now,
                        Estado = cbEstado.Checked,
                        Contrasena = txtContrasena.Text,
                        ID_Compañia = Convert.ToInt32(ddlCompania.SelectedValue),
                        ID_Perfil = Convert.ToInt32(ddlPerfil.SelectedValue)
                    };
                    if (usuariosBI.agregarUsuario(usuario))
                    {
                        Util.redirect("frmMantenimientoUsuarios");
                        Session["agregarExitoso"] = true;
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de agregar el usuario");
                    }
                }
                //Funcionalidad Editar
                else
                {
                    SGR_Usuarios usuarioEditar = new SGR_Usuarios
                    {
                        ID_Usuario = (int)Session["usuarioSeleccionado"],
                        Nombre_Completo = txtNombreCompleto.Text,
                        Nombre_Usuario = txtNombreUsuario.Text,
                        Identificacion = txtIdentificacion.Text,
                        Estado = cbEstado.Checked,
                        Contrasena = txtContrasena.Text,
                        ID_Compañia = Convert.ToInt32(ddlCompania.SelectedValue),
                        ID_Perfil = Convert.ToInt32(ddlPerfil.SelectedValue)
                    };
                    if (usuariosBI.editarUsuario(usuarioEditar))
                    {
                        Util.redirect("frmMantenimientoUsuarios");
                        Session["editarExitoso"] = true;
                        Session.Remove("usuarioSeleccionado");
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de editar el usuario");
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
            Util.redirect("frmMantenimientoUsuarios");
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
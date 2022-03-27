using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_2_logica;
using Capa_4_Entidades;

namespace Capa_0_Web
{
    public partial class Session : System.Web.UI.Page
    {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    txtUsuario.Focus();
                }

            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje" +
                        " ('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            Entidad_estudiante estudiante = new Entidad_estudiante();
            BlEstudiante logica = new BlEstudiante(clsConfiguracion.getConnectionString);
            /*DB_CentroIdiomasDataContext data = new DB_CentroIdiomasDataContext();
            ESTUDIANTES estudiante = new ESTUDIANTES();*/

            try
            {
                if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtContrasena.Text))
                {
                    /*var query = from iniciarEstudiante in data.ESTUDIANTES
                                join sesion in data.LOGINS
                                on iniciarEstudiante.ID_ESTUDIANTE equals sesion.ID_ESTUDIANTE
                                where Convert.ToInt32(txtUsuario.Text) == sesion.ID_ESTUDIANTE &&*/
                                

                   estudiante = logica.ObtenerEstudiante(txtUsuario.Text, txtContrasena.Text);
                }
                else
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('Debe digitar ambos campos');");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    if (string.IsNullOrEmpty(txtUsuario.Text))
                    {
                        txtUsuario.Focus();
                    }
                    else
                    {
                        txtContrasena.Focus();
                    }
                }

                if (estudiante.Existe)
                {
                    Session["id_estudiante"] = Convert.ToInt32(estudiante.Id_estudiante);
                    Response.Redirect("DatosUsuario.aspx");
                }
                else
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('Los datos son incorrectos o no existe el Usuario');");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        /*public void InsertarUsuario()
        {
            if (string.IsNullOrEmpty(mUsuario.Value) ||
                string.IsNullOrEmpty(mNombre.Value) ||
                string.IsNullOrEmpty(mEmail.Value) ||
                string.IsNullOrEmpty(mPapellido.Value) ||
                string.IsNullOrEmpty(mSapellido.Value) ||
                string.IsNullOrEmpty(mTelefono.Value) ||
                string.IsNullOrEmpty(mContrasena1.Value) ||
                string.IsNullOrEmpty(mContrasena2.Value))
            {

                ClientScript.RegisterStartupScript(this.GetType(),
                                "alert", "alert('Hay campos sin completar');", true);

            }
            else
            {
                using (DB_CentroIdiomasDataContext data = new DB_CentroIdiomasDataContext())
                {
                    ESTUDIANTES Estudiante = new ESTUDIANTES();
                    // fields to be insert
                    Estudiante.NOMBRE = mNombre.Value;
                    Estudiante.EMAIL = mEmail.Value;
                    Estudiante.P_APELLIDO = mPapellido.Value;
                    Estudiante.S_APELLIDO = mSapellido.Value;
                    Estudiante.TELEFONO = mTelefono.Value;
                    data.ESTUDIANTES.InsertOnSubmit(Estudiante);

                    LOGINS login = new LOGINS();
                    login.CONTRASENA = mContrasena1.Value;
                    login.USUARIO = mUsuario.Value;
                    data.LOGINS.InsertOnSubmit(login);

                    // executes the commands to implement the changes to the database
                    data.SubmitChanges();

                }
            }
        }*/

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            InsertarUsuario();
        }

        public void InsertarUsuario()
        {
            int resultado = 0;
            BlEstudiante logica = new BlEstudiante(clsConfiguracion.getConnectionString);
            try
            {

                resultado = logica.BuscarUsuario(txtUsuario.Text);

                if (resultado > 0)
                {
                    if (mContrasena1.Value == mContrasena2.Value)
                    {
                        resultado = 0;
                        if (string.IsNullOrEmpty(mNombre.Value) || string.IsNullOrEmpty(mTelefono.Value) ||
                            string.IsNullOrEmpty(mUsuario.Value) || string.IsNullOrEmpty(mPapellido.Value) ||
                            string.IsNullOrEmpty(mSapellido.Value) || string.IsNullOrEmpty(mEmail.Value) ||
                            string.IsNullOrEmpty(mEdad.Value))
                        {
                           // MessageBox.Show("Datos incompletos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Entidad_estudiante estudiante = new Entidad_estudiante();
                            estudiante.Nombre = mNombre.Value;
                            estudiante.Pr_apellido = mPapellido.Value;
                            estudiante.Se_apellido = mSapellido.Value;
                            estudiante.Edad = int.Parse(mEdad.Value);
                            estudiante.Telefono = mTelefono.Value;
                            estudiante.Email = mEmail.Value;
                            estudiante.Usuario = mUsuario.Value;
                            estudiante.Password = mContrasena1.Value;



                            resultado = logica.InsertarEst(estudiante);
                        }

                        if (resultado > 0)
                        {

                            ClientScript.RegisterStartupScript(this.GetType(),
                                            "alert", "alert('Operación Realizada');", true);
                            Limpiar();
                            Response.Redirect("Session.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(),
                                            "alert", "alert('Operación no Realizada');", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(),
                                             "alert", "alert('Las contraseñas no coinciden');", true);
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),
                                            "alert", "alert('Ya existe un usuario con ese nombre de usuario');", true);
                   
                    mUsuario.Value = string.Empty;
                    mUsuario.Focus();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Limpiar()
        {
            mUsuario.Value = string.Empty;
            mNombre.Value = string.Empty;
            mPapellido.Value = string.Empty;
            mSapellido.Value = string.Empty;
            mTelefono.Value = string.Empty;
            mEdad.Value = string.Empty;
            mEmail.Value = string.Empty;
            mContrasena1.Value = string.Empty;
            mContrasena2.Value = string.Empty;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Capa_4_Entidades;
using Capa_2_logica;

namespace Capa_0_Web
{
    public partial class ProgramarClase : System.Web.UI.Page
    {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                eldia.Value = DateTime.Now.AddDays(2).ToShortDateString();
                Session["dia"] = Convert.ToDateTime(eldia.Value);
            }
            else
            {
                Session["dia"] = Convert.ToDateTime(eldia.Value);
                Session["hora"] = Convert.ToDateTime(horas.SelectedValue);
                lbl_hora.Text = Convert.ToDateTime(Session["hora"]).ToShortTimeString();
                lbl_dia.Text = Convert.ToDateTime(Session["dia"]).ToShortDateString();
                try
                {
                    //convertimos el viewstate "dia" a fecha para probar si 
                    //se puede castear, si se castea, se comprueba
                    //que sea 2 dias posteriores, si no mostrara alert
                    if (DateTime.TryParse(Session["dia"].ToString(), out DateTime fechaP))
                    {
                        DateTime hoy = DateTime.Now.AddDays(2);
                        if (fechaP.Date < hoy.Date)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(),
                                    "alert", "alert('Debe ser al menos 2 dias posterior a la actual fecha');", true);
                        }
                    }

                    if (DateTime.TryParse(lbl_dia.Text, out var Temp1)
                        && DateTime.TryParse(lbl_hora.Text, out var Temp2))
                    {
                        CargarProfesoresDisponibles();
                    }

                }
                catch(Exception ex)
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, false); ;
                }
            }
        }
        
        protected void enviar_Click(object sender, EventArgs e)
        {
            Session["dia"] = Convert.ToDateTime(eldia.Value);
            Session["hora"] = Convert.ToDateTime(horas.SelectedValue);
        }

        public void CargarProfesoresDisponibles()
        {
            string idioma;
            //buscamos el idioma del curso que estamos matriculando
            idioma = buscarIdiomaCurso();
            //asignamos el valor de la hora seleccionada a una variable DateTime
            DateTime HoraInicio = Convert.ToDateTime(lbl_hora.Text);
            //la hora final sera definida agregando 2 horas, lo cual correpondera a la duracion de la clase
            DateTime HoraFinal = HoraInicio.Add(new TimeSpan(0, -1, 0)).AddHours(2);
            DataSet profesoresDispo;
            BlProfesores logica = new BlProfesores(clsConfiguracion.getConnectionString);
            try
            {
                //se cargara al datagridview los datos de los profesores disponibles
                profesoresDispo = logica.profesoresDisponibles(HoraInicio, HoraFinal, idioma);
                grdProfesores.DataSource = profesoresDispo;
                grdProfesores.DataBind();
                //grdProfesores.DataMember = profesoresDispo.Tables["PROFESORES"].TableName;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public string buscarIdiomaCurso()
        {
            //Buscaremos el idioma trayendo el curso del cual se va a crear
            //la clase sincronica
            string idioma;
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);
            try
            {
                //gracias a la variable global idCurso. nos damos cuenta cual es el curso
                //del cual queremos programar clase sincronica
                idioma = logica.buscarIdiomaCurso((int)Session["id_curso"]);
            }
            catch
            {
                throw;
            }

            return idioma;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatosUsuario.aspx");
        }

        protected void btnProgramarClase_Command(object sender, CommandEventArgs e)
        {
            //crearemos la clase
            Entidad_clase clase = new Entidad_clase();
            int afectada;
            bool fueraDeCurso = false;

            BlClases logica = new BlClases(clsConfiguracion.getConnectionString);

            try
            {
                fueraDeCurso = revisarFinalCurso((int)Session["id_curso"]);
                if (fueraDeCurso)
                {
                    clase.InicioClase = Convert.ToDateTime(lbl_hora.Text);
                    clase.FinClase = clase.InicioClase.Add(new TimeSpan(0, -1, 0)).AddHours(2);
                    clase.Id_profesor = Convert.ToInt32(e.CommandArgument.ToString());
                    clase.Id_estudiante = (int)Session["id_estudiante"];
                    clase.Id_curso = (int)Session["id_curso"];

                    afectada = logica.crearClase(clase);

                    if (afectada > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(),
                                    "alert", "alert('Se ha creado la clase');", true);
                        Response.Redirect("DatosUsuario.aspx");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),
                                    "alert", "alert('La fecha sobrepasa la fecha final de este curso');", true);
                }
                CargarProfesoresDisponibles();
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, false); ;
            }
            //la clase debe ser dos dias posteriores al dia que se genera
            //debe encontrarse entre la fecha de inicio y de fin del curso
        }

        public bool revisarFinalCurso(int id)
        {
            bool resultado;
            Entidad_curso_estudiante curso_estudiante;
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);

            try
            {
                curso_estudiante = logica.ObtenerC_estudiante(id);
                if (curso_estudiante.Fecha_inicio < Convert.ToDateTime(lbl_dia.Text) &&
                    curso_estudiante.Fecha_final > Convert.ToDateTime(lbl_dia.Text).AddHours(2))
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
    }
}
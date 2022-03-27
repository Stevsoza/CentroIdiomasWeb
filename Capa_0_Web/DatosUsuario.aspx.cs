using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_2_logica;
using Capa_4_Entidades;

namespace Capa_0_Web
{
    public partial class DatosUsuario : System.Web.UI.Page
    {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = (int)Session["id_estudiante"];

            
            if (IsPostBack)
            {
                CargarEstudiante(id);
                CargarCursos();
                CargarClases();
                Session["programa"] = Programa.SelectedItem.Value;
                Session["index_intensidad"] = Intensidad.SelectedIndex;

                if (Session["programa"].ToString() == "PROGRAMA")
                {
                    Intensidad.Enabled = false;
                    btnMatricular.Enabled = false;
                }
                else
                {
                    Intensidad.Enabled = true;
                }

                if ((int)Session["index_intensidad"] >= 1)
                {
                    btnMatricular.Enabled = true;
                }
                else
                {
                    btnMatricular.Enabled = false;
                }

                if ((byte)Session["deuda"] == 1)
                {
                    btnDeudas.Enabled = true;
                    Programa.Enabled = false;
                }
                else
                {
                    Programa.Enabled = true;
                    btnDeudas.Enabled = false;
                }
            }
            else
            {
                Session["programa"] = "PROGRAMA";
                Session["curso"] = 0;
                Intensidad.Enabled = false;
                Session["index_intensidad"] = 0;
            }

            try
            {
                CargarEstudiante(id);
                CargarCursos();
                CargarClases();

                if ((byte)Session["deuda"] == 1)
                {
                    btnDeudas.Enabled = true;
                    Programa.Enabled = false;
                }
                else
                {
                    btnDeudas.Enabled = false;
                    Programa.Enabled = true; 
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        public void CargarEstudiante(int id)
        {
            Entidad_estudiante estudiante = new Entidad_estudiante();
            BlEstudiante logica = new BlEstudiante(clsConfiguracion.getConnectionString);
            try
            {
                //recuperamos una entidad de estudiante
                estudiante = logica.ObtenerEstudiante(id);
                if (estudiante != null)
                {
                    //asignamos los datos de la entidad en la pagina de datos personales
                    lblId.Text = "ID: " + estudiante.Id_estudiante.ToString();
                    label_nom.Text = estudiante.Nombre;
                    label_tel.Text = estudiante.Telefono;
                    label_ape.Text = estudiante.Pr_apellido;
                    label_seg.Text = estudiante.Se_apellido;
                    label_email.Text = estudiante.Email;
                    lblMatriculados.Text = "Cursos Matriculados: " + estudiante.Cursos_matriculados.ToString();
                    lblNombre.Text = "Nombre: " + estudiante.Nombre;
                    label_edad.Text = estudiante.Edad.ToString();
                    Session["deuda"] = estudiante.Deuda;
                    
                    //sesion = estudiante;
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        private void CargarCursos()
        {
            //cargar cursos realizá el proceso de cargar
            //los cursos en el datagrid de los cursos que actualmente
            //cursa el estudiante
            DataSet DS;
            string condicion = Session["id_estudiante"].ToString(); //la condicion se convierte en el campo
            //que hay en la etiquete txt_id 
            string orden = "";
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);
            try
            {
                //se mandan a pedir los datos por medio de un dataset
                DS = logica.ListarCursosHistoria(condicion, orden);
                grdCursos.DataSource = DS;
                grdCursos.DataBind();
                //grd.DataMember = DS.Tables["CURSOS_ESTUDIANTE"].TableName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CargarClases()
        {
            BlClases logica = new BlClases(clsConfiguracion.getConnectionString);
            DataSet DsClases;
            try
            {
                DsClases = logica.CargarClases(Convert.ToInt32(Session["id_estudiante"]));
                if (DsClases != null)
                {
                    grdClases.DataSource = DsClases;
                    //DataMember = DsClases.Tables["CLASES"].TableName;
                    grdClases.DataBind();

                }
            }
            catch (Exception)
            {
                throw;
            }
            //cargar en dgvClases
        }

        protected void Programa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Intensidad.SelectedIndex = 0;
            btnMatricular.Enabled = false;
            lblFecha.Text = "debe seleccionar un nivel de intensidad";
            DB_CentroIdiomasDataContext data = new DB_CentroIdiomasDataContext();
            string programa_load = Session["programa"].ToString();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("NOMBRE_CURSO");
            tabla.Columns.Add("HORAS");
            tabla.Columns.Add("COSTO");
            DataRow _curso = tabla.NewRow();
            string mensaje = "";
            int idcurso = 0;
            int id_estudiante = (int)Session["id_estudiante"];
            try
            {
                if (programa_load != "PROGRAMA")
                {
                    data.CURSO_NEXT(id_estudiante, programa_load, ref mensaje);

                    //tratamos de convertir el mensaje que devuelve
                    //el procedimiento almacenado
                    // "CURSO_NEXT" a entero
                    //si es un entero será el cogido del curso
                    if (int.TryParse(mensaje, out idcurso))
                    {
                        //si sucede
                        //trateremos de obtener los datos del curso
                        var query = (from curs in data.CURSOS
                                     where curs.ID_CURSO == idcurso
                                     select new
                                     {
                                         NOMBRE_CURSO = curs.NOMBRE_CURSO,
                                         HORAS = curs.HORAS,
                                         COSTO = curs.COSTO
                                     }).FirstOrDefault();
                        if (query != null)
                        {
                            //asignamos los valores al la variable _curso
                            //la cual es una fila del tipo DataTable antes creado

                            _curso["NOMBRE_CURSO"] = query.NOMBRE_CURSO;
                            _curso["HORAS"] = query.HORAS;
                            _curso["COSTO"] = query.COSTO;

                            //asignamos la fila a la table DataTable
                            tabla.Rows.Add(_curso);

                            grdCurso_d.DataSource = tabla;
                            grdCurso_d.DataBind();
                        }
                        Session["curso"] = idcurso;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No hay materias por aprobar para este programa');", true);
                    }
                }
                else
                {
                    lblFecha.Text = "debe seleccionar un programa";
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, false);
            }
        }

        public string cargarFechaFinalizacion(int id)
        {
            string fecha = null;
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);
            Entidad_curso curso = null;
            double horas;

            int intensidad = (int)Session["index_intensidad"];

            try
            {
                curso = logica.ObtenerEntidadCurso(id);
                horas = curso.Horas;
                if (intensidad >= 1)
                {
                    fecha = Obtenerfecha(horas, intensidad);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),
                        "alert", "alert('Seleccione una Intensidad');", true);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return fecha;
        }
        public string Obtenerfecha(double horas, int intensidad)
        {
            string fechaEnviar = string.Empty;
            int anio = DateTime.Now.Year;
            List<Entidad_feriados> enFeriado = null;
            DateTime[] listaFechas;
            int resta = 0;
            bool feriado = false;
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);

            //
            try
            {
                //se obtiene los dias feriados para guardarlos en un array
                //que luego comprobaremos
                enFeriado = logica.ObtenerFeriados(anio);

                listaFechas = new DateTime[enFeriado.Count];

                for (int i = 0; i < enFeriado.Count; i++)
                {
                    listaFechas[i] = enFeriado[i].Fecha;
                }

                //de acuerdo a las siguientes condiciones
                //haremos la resta de dia a dia de las horas
                //que deberia consumir el estudiante
                //estudiando :P
                if (intensidad == 1) { resta = 1; }
                else if (intensidad == 2) { resta = 2; }
                else if (intensidad == 3) { resta = 3; }
                else if (intensidad == 4) { resta = 4; }

                horas = horas - (horas * 0.25);

                DateTime fechaActual = DateTime.Now;


                //este ciclo revisara los feriados
                //y tambien excluira del proceso 
                //
                do
                {
                    fechaActual = fechaActual.AddDays(1);
                    //para cada vez que se añade un dia
                    //se verifica que no se encuentre entre las fechas
                    //de feriados
                    foreach (DateTime fecha in listaFechas)
                    {
                        feriado = false;
                        if (fecha.ToShortDateString() == fechaActual.ToShortDateString())
                        {
                            feriado = true;
                            break;
                        }
                    }
                    //aca se verifica que no sean sabado o domingo =>
                    if (fechaActual.DayOfWeek.ToString() == "Saturday" || fechaActual.DayOfWeek.ToString() == "Sunday")
                    {
                        feriado = true;
                    }
                    if (feriado != true)
                    {
                        horas -= resta;
                    }
                    if (horas < 0)
                    {
                        horas = 0;
                    }
                } while (horas != 0);
                //al final convertimos la fecha en un string en modo corto
                //de esta manera la retorna esta función
                fechaEnviar = fechaActual.ToShortDateString();

            }
            catch (Exception)
            {
                throw;
            }
            return fechaEnviar;
        }


        protected void Intensidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int idCurso = (int)Session["curso"];
            if ((int)Session["index_intensidad"] > 0 && idCurso != 0)
            {
                lblFecha.Text = cargarFechaFinalizacion(idCurso);
            }
            else
            {
                lblFecha.Text = "Debe seleccionar un nivel de intensidad";
                btnMatricular.Enabled = false;
            }
            DateTime probar;
            if(DateTime.TryParse(lblFecha.Text, out probar))
            {
                btnMatricular.Enabled = true;
            }
            if ((byte)Session["deuda"] == 1)
            {
                btnMatricular.Enabled = false;
                ClientScript.RegisterStartupScript(this.GetType(),
                       "alert", "alert('Deudas Pendientes, Proceda a pagar');", true);
            }
        }

        protected void btnProgramarClase_Command(object sender, CommandEventArgs e)
        {
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);
            bool existe;
            int id;
            id = Convert.ToInt32(e.CommandArgument.ToString());
            existe = logica.existeClaseCurso(id, (int)Session["id_estudiante"]);
            if (!existe)
            {
                /*PClases = new ProgramarClase(sesion, id);
                PClases.AceptarClase += new EventHandler(Aceptar);
                PClases.ShowDialog();*/
                Session["id_curso"] = id;
                Response.Redirect("ProgramarClase.aspx");

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),
                        "alert", "alert('Este curso ya tiene una clase asignada" +
                        " completela para asignar otra clase');", true);
            }
        }

        protected void btnEliminarClase_Command(object sender, CommandEventArgs e)
        {
            int resultado;
            DateTime diaHoy = DateTime.Now;
            BlClases logica = new BlClases(clsConfiguracion.getConnectionString);
            Entidad_clase clase;
            try
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                clase = logica.ObtenerClase(id);
                if (clase != null)
                {
                    //realizamos un comparacion de fechas que nos devuelve la diferencia de horas
                    //entre la actual fecha y hora, y la fecha y hora del inicio de la clase
                    TimeSpan difHoras = clase.InicioClase.Subtract(diaHoy);
                    if (difHoras > new TimeSpan(12, 0, 0))
                    {
                        resultado = logica.EliminarClase(id);
                        if (resultado > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(),
                            "alert", "alert('Se ha eliminado la clase');", true);
                            CargarClases();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(),
                            "alert", "alert('La siguiente clase inicia en menos de 12 horas, ya no se puede " +
                            "procesar la cancelación de la misma');", true);
                    }

                }

            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, false);
            }
        }

        protected void btnMatricular_Click(object sender, EventArgs e)
        {

            int cursoID = (int)Session["curso"];
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);
            BlMatriculas logicaM = new BlMatriculas(clsConfiguracion.getConnectionString);
            Entidad_curso curso = null;
            bool necesitaCurso;
            bool cursoMatriculado;
            bool mismoCurso;

            try
            {
                CargarEstudiante((int)Session["id_estudiante"]);
                if ((byte)Session["deuda"] == 0)
                {
                    curso = logica.ObtenerEntidadCurso(cursoID);
                    mismoCurso = BuscarCurso(curso.NombreCurso, (int)Session["id_estudiante"]);
                    if (string.IsNullOrEmpty(curso.Requisito))
                    {
                        necesitaCurso = false;
                    }
                    else
                    {
                        necesitaCurso = logica.BuscarRequisito(curso.Requisito);
                    }

                    if (necesitaCurso || mismoCurso)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(),
                            "alert", "alert('Este curso tiene requisito y no ha sido aprobado, o ya esta matriculado');", true);
                        
                    }
                    else
                    {

                        if (curso != null)
                        {
                            Entidad_matricula matricula = new Entidad_matricula();

                            //se asignan los valores que debemos guardar en el curso del estudiante
                            matricula.Id_curso = (int)Session["curso"];
                            matricula.Id_estudiante = (int)Session["id_estudiante"];
                            matricula.Fecha = DateTime.Now.AddDays(1);
                            matricula.Nivel_intensidad = Intensidad.SelectedValue;
                            matricula.Costo = curso.Costo;
                            matricula.Cancelado = 0;

                            cursoMatriculado = logicaM.InsertarEnMatricula(matricula);
                            //cursoMatriculado = logica.InsertarC_estudiante(matricular);

                            if (cursoMatriculado)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(),
                                    "alert", "alert('Hubo un error');", true);
                            }
                            else
                            {
                                btnMatricular.Enabled = false;
                                Intensidad.SelectedIndex = 0;
                                Programa.Enabled = false;
                                Intensidad.Enabled = false;
                                btnDeudas.Enabled = true;
                                lblFecha.Text = "Pagar deuda";
                                ClientScript.RegisterStartupScript(this.GetType(),
                                    "alert", "alert('El curso ha sido matriculado solo falta, proceder al pago');", true);

                            }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),
                                    "alert", "alert('No puede matricular, tiene deudas\nDirijase a pestaña cursos, botón 'pagar deudas');", true);
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, false);
            }
            CargarEstudiante((int)Session["id_estudiante"]);

        }

        private bool BuscarCurso(string Nombre_curso, int id)
        {
            bool hayCursoIgual = false;
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);
            try
            {
                hayCursoIgual = logica.BuscarCurso(Nombre_curso, id);
            }
            catch (Exception)
            {
                throw;
            }
            return hayCursoIgual;
        }

        protected void btnDeudas_Click(object sender, EventArgs e)
        {
            BlCursos logica = new BlCursos(clsConfiguracion.getConnectionString);
            BlMatriculas logica2 = new BlMatriculas(clsConfiguracion.getConnectionString);
            DB_CentroIdiomasDataContext data = new DB_CentroIdiomasDataContext();
            Entidad_curso curso;
            Entidad_matricula matricula;
            int id = 0;
            int id_curso;
            int intensidad = 0;
            bool procesoCompletado;
            try
            {

                var query = (from est in data.ESTUDIANTES
                             join matri in data.MATRICULA
                             on est.ID_ESTUDIANTE equals matri.ID_ESTUDIANTE
                             where est.ID_ESTUDIANTE == (int)Session["id_estudiante"] && matri.CANCELADO == false
                             select matri)
                             .FirstOrDefault();
                //asignamos el id de la matricula a esta variable
                id = query.ID_MATRICULA;
                //asignamos el id del curso a esta variable
                id_curso = query.ID_CURSO;
                //la matricula se tornara en cancelado true
                ActualizarMatricula(id);
                //cargamos los datos de la matricula
                //para posteriormente saber la intensidad y demas datos 
                //necesarios para colocar finalmente el curso en
                //cursos del estudiante
                matricula = logica2.ObtenerEntidadMatricula(id);
                Entidad_curso_estudiante matriculaHecha = new Entidad_curso_estudiante();

                //asignaremos los valores al curso que vamos a introducir
                //en la tabla de cursos estudiante
                curso = logica.ObtenerEntidadCurso(id_curso);
                matriculaHecha.Id_estudiante = (int)Session["id_estudiante"];
                matriculaHecha.Id_curso = curso.Id_curso;
                matriculaHecha.NombreCurso = curso.NombreCurso;
                matriculaHecha.Fecha_inicio = DateTime.Now.AddDays(1);

                //realizamos conversion de intensidad de string a entero :P
                if (matricula.Nivel_intensidad == "BAJO") { intensidad = 1; }
                else if (matricula.Nivel_intensidad == "MEDIO") { intensidad = 2; }
                else if (matricula.Nivel_intensidad == "ALTO") { intensidad = 3; }
                else if (matricula.Nivel_intensidad == "INTENSIVO") { intensidad = 4; }

                //la fecha final será obtenida por la funcion llamada en esta linea
                matriculaHecha.Fecha_final = Convert.ToDateTime(Obtenerfecha(curso.Horas, intensidad));
                matriculaHecha.Estado = "ACT";
                matriculaHecha.Horas_sin_res = Convert.ToInt32(curso.Horas * 0.25);
                procesoCompletado = logica.InsertarC_estudiante(matriculaHecha);
                if (procesoCompletado)
                {
                    ClientScript.RegisterStartupScript(this.GetType(),
                                    "alert", "alert('Se ha Completado la matricula');", true);
                    btnDeudas.Enabled = false;
                    btnMatricular.Enabled = false;
                    Intensidad.SelectedIndex = 0;
                    Intensidad.Enabled = false;
                    Programa.SelectedIndex = 0;
                    Programa.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}');", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, false);
            }

            CargarEstudiante((int)Session["id_estudiante"]);
            CargarCursos();
            CargarClases();
        }

        public void ActualizarMatricula(int id)
        {
            BlMatriculas logica = new BlMatriculas(clsConfiguracion.getConnectionString);

            try
            {
                logica.ActualizarMatricula(id);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
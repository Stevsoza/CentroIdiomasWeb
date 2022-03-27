using Capa_3_AccesoDatos;
using Capa_4_Entidades;
using System;
using System.Collections.Generic;
using System.Data;


namespace Capa_2_logica
{
    public class BlCursos
    {
        private string _cadenaConexion;
        private string _mensaje;

        public BlCursos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }

        public DataSet ListarCursosPrograma(string condicion = "", string orden = "")
        {
            DataSet DS;
            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                DS = datos.ListarCursosPrograma(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }


        public DataSet ListarCursosHistoria(string condicion = "", string orden = "")
        {
            DataSet DS;
            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                DS = datos.ListarCursosHistoria(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        public DataSet ObtenerCurso(int id)
        {
            DataSet ds = null;
            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                ds = datos.ObtenerCurso(id);
            }
            catch (Exception)
            {
                throw;
            }

            return ds;
        }

        public Entidad_curso ObtenerEntidadCurso(int id)
        {
            Entidad_curso curso = null;
            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                curso = datos.ObtenerEntidadCurso(id);
            }
            catch (Exception)
            {
                throw;
            }
            return curso;
        }



        public List<Entidad_feriados> ObtenerFeriados(int anio)
        {
            List<Entidad_feriados> feriados = null;

            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                feriados = datos.ObtenerFeriados(anio);
            }
            catch (Exception)
            {
                throw;
            }
            return feriados;

        }

        public bool BuscarRequisito(string curso)
        {
            bool seNecesita;

            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                seNecesita = datos.BuscarRequisito(curso);
            }
            catch (Exception)
            {
                throw;
            }
            return seNecesita;
        }

        public bool InsertarC_estudiante(Entidad_curso_estudiante matricular)
        {
            bool matriculado;
            DaCursos datos = new DaCursos(_cadenaConexion);

            try
            {
                matriculado = datos.InsertarC_estudiante(matricular);
            }
            catch (Exception)
            {
                throw;
            }

            return matriculado;
        }

        public bool BuscarCurso(string Nombre_curso, int id)
        {
            bool hayCursoIgual;
            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                hayCursoIgual = datos.BuscarCurso(Nombre_curso, id);
            }
            catch (Exception)
            {
                throw;
            }
            return hayCursoIgual;
        }

        public string buscarIdiomaCurso(int id)
        {
            string idioma;
            DaCursos datos = new DaCursos(_cadenaConexion);

            try
            {
                idioma = datos.buscarIdiomaCurso(id);
            }
            catch (Exception)
            {
                throw;
            }


            return idioma;
        }

        public Entidad_curso_estudiante ObtenerC_estudiante(int id)
        {
            Entidad_curso_estudiante curso_est = null;
            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                curso_est = datos.ObtenerC_estudiante(id);
            }
            catch (Exception)
            {
                throw;
            }
            return curso_est;
        }

        public bool existeClaseCurso(int id, int estudiante)
        {
            bool existe;
            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                existe = datos.existeClaseCurso(id, estudiante);
            }
            catch (Exception)
            {
                throw;
            }

            return existe;
        }

        public int eliminarClasesVencidas(int id)
        {
            int clasesVencidas;

            DaCursos datos = new DaCursos(_cadenaConexion);
            try
            {
                clasesVencidas = datos.eliminarClasesVencidas(id);
            }
            catch (Exception)
            {
                throw;
            }
            return clasesVencidas;
        }
    }

}

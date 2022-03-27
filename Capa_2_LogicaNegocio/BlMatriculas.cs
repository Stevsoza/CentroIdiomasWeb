using Capa_3_AccesoDatos;
using Capa_4_Entidades;
using System;
using System.Data;

namespace Capa_2_logica
{
    public class BlMatriculas
    {
        private string _cadenaConexion;
        private string _mensaje;

        public BlMatriculas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }


        public bool InsertarEnMatricula(Entidad_matricula matricula)
        {
            bool matriculado;
            DaMatriculas datos = new DaMatriculas(_cadenaConexion);

            try
            {
                matriculado = datos.InsertarEnMatricula(matricula);
            }
            catch (Exception)
            {
                throw;
            }

            return matriculado;
        }

        public DataSet CargarMatriculas(int id)
        {
            DataSet DatosSet;
            DaMatriculas datos = new DaMatriculas(_cadenaConexion);
            try
            {
                DatosSet = datos.CargarMatriculas(id);
            }
            catch (Exception)
            {
                throw;
            }
            return DatosSet;
        }

        public void ActualizarMatricula(int id)
        {
            DaMatriculas datos = new DaMatriculas(_cadenaConexion);
            try
            {
                datos.ActualizarMatricula(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Entidad_matricula ObtenerEntidadMatricula(int id)
        {
            Entidad_matricula matricula = null;
            DaMatriculas datos = new DaMatriculas(_cadenaConexion);
            try
            {
                matricula = datos.ObtenerEntidadMatricula(id);
            }
            catch (Exception)
            {

            }
            return matricula;
        }

        public int EliminarMatricular(int matricula)
        {
            int resultado;
            DaMatriculas datos = new DaMatriculas(_cadenaConexion);
            try
            {
                resultado = datos.EliminarMatricular(matricula);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

    }
}

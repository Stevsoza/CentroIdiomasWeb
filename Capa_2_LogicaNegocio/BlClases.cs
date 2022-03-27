using Capa_3_AccesoDatos;
using Capa_4_Entidades;
using System;
using System.Data;

namespace Capa_2_logica
{
    public class BlClases
    {
        private string _cadenaConexion;
        private string _mensaje;

        public BlClases(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }

        public int crearClase(Entidad_clase clase)
        {
            int afectada;
            DaClases datos = new DaClases(_cadenaConexion);
            try
            {
                afectada = datos.crearClase(clase);
            }
            catch (Exception)
            {
                throw;
            }
            return afectada;
        }

        public DataSet CargarClases(int idEstudiante)
        {
            DataSet DsClasses;
            DaClases datos = new DaClases(_cadenaConexion);
            try
            {
                DsClasses = datos.CargarClases(idEstudiante);
            }
            catch (Exception)
            {
                throw;
            }
            return DsClasses;
        }

        public Entidad_clase ObtenerClase(int id)
        {
            Entidad_clase clase = null;
            DaClases datos = new DaClases(_cadenaConexion);
            try
            {
                clase = datos.ObtenerClase(id);
            }
            catch (Exception)
            {
                throw;
            }

            return clase;
        }

        public int EliminarClase(int id)
        {
            int resultado;
            DaClases datos = new DaClases(_cadenaConexion);
            try
            {
                resultado = datos.EliminarClase(id);
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }

    }
}

using Capa_3_AccesoDatos;
using System;
using System.Data;

namespace Capa_2_logica
{
    public class BlProfesores
    {
        private string _cadenaConexion;
        private string _mensaje;

        public BlProfesores(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }

        public DataSet profesoresDisponibles(DateTime horaInicio, DateTime horaFinal, string idioma)
        {
            DataSet profesoresDispo = null;
            DaProfesores Datos = new DaProfesores(_cadenaConexion);
            try
            {
                profesoresDispo = Datos.profesoresDisponibles(horaInicio, horaFinal, idioma);

            }
            catch (Exception)
            {

            }
            return profesoresDispo;
        }
    }
}

using Capa_3_AccesoDatos;
using Capa_4_Entidades;
using System;
using System.Data;
using System.Collections.Generic;

namespace Capa_2_logica
{
    public class BlEstudiante
    {
        private string _cadenaConexion;
        private string _mensaje;

        public BlEstudiante(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }


        public void ActualizarEstudiante(Entidad_estudiante estudiante)
        {
            DaEstudiante datos = new DaEstudiante(_cadenaConexion);
            try
            {
                datos.ActualizarEstudiante(estudiante);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public Entidad_estudiante ObtenerEstudiante(string usuario, string contrasena)
        {
            Entidad_estudiante estudiante;
            DaEstudiante datos = new DaEstudiante(_cadenaConexion);
            try
            {
                estudiante = datos.ObtenerEstudiante(usuario, contrasena);
            }
            catch (Exception)
            {
                throw;
            }
            return estudiante;
        }

        public Entidad_estudiante ObtenerEstudiante(int id)
        {
            Entidad_estudiante estudiante;
            DaEstudiante accesoDatos = new DaEstudiante(_cadenaConexion);
            try
            {
                estudiante = accesoDatos.ObtenerDatos(id);
            }
            catch (Exception)
            {
                throw;
            }
            return estudiante;
        }

        public int InsertarEst(Entidad_estudiante estudiante)
        {
            DaEstudiante datos = new DaEstudiante(_cadenaConexion);
            int resultado = -1;
            try
            {
                resultado = datos.Insertar(estudiante);
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }

        public int BuscarUsuario(string usuario)
        {
            int resultado = 0;
            DaEstudiante datos = new DaEstudiante(_cadenaConexion);

            try
            {
                resultado = datos.BuscarUsuario(usuario);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

    }
}

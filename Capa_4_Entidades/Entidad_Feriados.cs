using System;

namespace Capa_4_Entidades
{
    public class Entidad_feriados
    {

        private DateTime fecha;
        private string descripcion;
        private int anio;

        public Entidad_feriados()
        {
            Fecha = DateTime.MinValue;
            Descripcion = string.Empty;
            Anio = 0;
        }

        public Entidad_feriados(DateTime fecha, string descripcion, int anio)
        {
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.Anio = anio;
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Anio { get => anio; set => anio = value; }
    }
}

using System;

namespace Capa_4_Entidades
{
    public class Entidad_matricula
    {
        private int id_matricula;
        private int id_estudiante;
        private int id_curso;
        private string idioma;
        private DateTime fecha;
        private string nivel_intensidad;
        private decimal costo;
        private byte cancelado;

        public Entidad_matricula()
        {
            Id_matricula = 0;
            Id_estudiante = 0;
            Id_curso = 0;
            Idioma = string.Empty;
            Fecha = DateTime.MinValue;
            Nivel_intensidad = string.Empty;
            Costo = 0;
            Cancelado = 0;
        }

        public Entidad_matricula(int id_matricula, int id_estudiante, int id_curso, string idioma, DateTime fecha, string nivel_intensidad, decimal costo, byte cancelado)
        {
            this.Id_matricula = id_matricula;
            this.Id_estudiante = id_estudiante;
            this.Id_curso = id_curso;
            this.Idioma = idioma;
            this.Fecha = fecha;
            this.Nivel_intensidad = nivel_intensidad;
            this.Costo = costo;
            this.Cancelado = cancelado;
        }

        public int Id_matricula { get => id_matricula; set => id_matricula = value; }
        public int Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public int Id_curso { get => id_curso; set => id_curso = value; }
        public string Idioma { get => idioma; set => idioma = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Nivel_intensidad { get => nivel_intensidad; set => nivel_intensidad = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public byte Cancelado { get => cancelado; set => cancelado = value; }
    }
}

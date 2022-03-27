using System;

namespace Capa_4_Entidades
{
    public class Entidad_clase
    {
        private int id_clase;
        private int id_estudiante;
        private int id_curso;
        private int id_profesor;
        private DateTime inicioClase;
        private DateTime finClase;

        public Entidad_clase()
        {
            Id_clase = 0;
            Id_estudiante = 0;
            Id_curso = 0;
            Id_profesor = 0;
            InicioClase = DateTime.MinValue;
            FinClase = DateTime.MinValue;
        }

        public Entidad_clase(int id_clase, int id_estudiante, int id_curso, int id_profesor, DateTime inicioClase, DateTime finClase)
        {
            this.Id_clase = id_clase;
            this.Id_estudiante = id_estudiante;
            this.Id_curso = id_curso;
            this.Id_profesor = id_profesor;
            this.InicioClase = inicioClase;
            this.FinClase = finClase;
        }

        public int Id_clase { get => id_clase; set => id_clase = value; }
        public int Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public int Id_curso { get => id_curso; set => id_curso = value; }
        public int Id_profesor { get => id_profesor; set => id_profesor = value; }
        public DateTime InicioClase { get => inicioClase; set => inicioClase = value; }
        public DateTime FinClase { get => finClase; set => finClase = value; }
    }
}

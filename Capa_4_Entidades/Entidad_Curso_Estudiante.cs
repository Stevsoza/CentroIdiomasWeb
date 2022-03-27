using System;

namespace Capa_4_Entidades
{
    public class Entidad_curso_estudiante : Entidad_curso
    {
        private int id_estudiante;
        private DateTime fecha_inicio;
        private DateTime fecha_final;
        private string estado;
        private int horas_sin_res;

        public Entidad_curso_estudiante()
        {
            Id_estudiante = 0;
            Fecha_inicio = DateTime.MinValue;
            Fecha_final = DateTime.MinValue;
            Estado = string.Empty;
            Horas_sin_res = 0;
        }


        public Entidad_curso_estudiante(int id_estudiante, DateTime fecha_inicio, DateTime fecha_final, string estado, int horas_sin_res)
        {
            this.Id_estudiante = id_estudiante;
            this.Fecha_inicio = fecha_inicio;
            this.Fecha_final = fecha_final;
            this.Estado = estado;
            this.Horas_sin_res = horas_sin_res;
        }

        public int Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        public DateTime Fecha_final { get => fecha_final; set => fecha_final = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Horas_sin_res { get => horas_sin_res; set => horas_sin_res = value; }
    }
}

namespace Capa_4_Entidades
{
    public class Entidad_curso
    {
        private int id_curso;
        private int id_programa;
        private string nombreCurso;
        private string requisito;
        private int horas;
        private decimal costo;

        public Entidad_curso()
        {
            Id_curso = 0;
            Id_programa = 0;
            NombreCurso = string.Empty;
            Requisito = string.Empty;
            Horas = 0;
            Costo = 0;
        }

        public Entidad_curso(int id_curso, int id_programa, string nombreCurso, string requisito, int horas, decimal costo)
        {
            this.Id_curso = id_curso;
            this.Id_programa = id_programa;
            this.NombreCurso = nombreCurso;
            this.Requisito = requisito;
            this.Horas = horas;
            this.Costo = costo;
        }

        public int Id_curso { get => id_curso; set => id_curso = value; }
        public int Id_programa { get => id_programa; set => id_programa = value; }
        public string NombreCurso { get => nombreCurso; set => nombreCurso = value; }
        public string Requisito { get => requisito; set => requisito = value; }
        public int Horas { get => horas; set => horas = value; }
        public decimal Costo { get => costo; set => costo = value; }
    }
}

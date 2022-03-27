namespace Capa_4_Entidades
{
    public class Entidad_estudiante : Entidad_usuario
    {
        private int id_estudiante;
        private int cursos_matriculados;
        private byte deuda;
        private bool existe;

        public Entidad_estudiante()
        {
            id_estudiante = 0;
            cursos_matriculados = 0;
            deuda = 0;
            existe = false;
        }

        public Entidad_estudiante(int id_estudiante, int cursos_matriculados, byte deuda, bool existe)
        {
            this.Id_estudiante = id_estudiante;
            this.Cursos_matriculados = cursos_matriculados;
            this.Deuda = deuda;
            this.Existe = existe;
        }

        public int Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public int Cursos_matriculados { get => cursos_matriculados; set => cursos_matriculados = value; }
        public byte Deuda { get => deuda; set => deuda = value; }
        public bool Existe { get => existe; set => existe = value; }
    }
}

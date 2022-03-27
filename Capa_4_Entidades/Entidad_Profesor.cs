using System;

namespace Capa_4_Entidades
{
    public class Entidad_profesor : Entidad_usuario
    {
        private int profesor;
        private string idioma;
        private DateTime hora_entrada;
        private DateTime hora_salida;

        public Entidad_profesor()
        {
            Profesor = 0;
            Idioma = string.Empty;
            Hora_entrada = DateTime.MinValue;
            Hora_salida = DateTime.MinValue;
        }


        public Entidad_profesor(int profesor, string idioma, DateTime hora_entrada, DateTime hora_salida)
        {
            this.Profesor = profesor;
            this.Idioma = idioma;
            this.Hora_entrada = hora_entrada;
            this.Hora_salida = hora_salida;
        }

        public int Profesor { get => profesor; set => profesor = value; }
        public string Idioma { get => idioma; set => idioma = value; }
        public DateTime Hora_entrada { get => hora_entrada; set => hora_entrada = value; }
        public DateTime Hora_salida { get => hora_salida; set => hora_salida = value; }
    }
}

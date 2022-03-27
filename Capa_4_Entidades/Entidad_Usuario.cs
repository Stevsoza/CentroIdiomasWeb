namespace Capa_4_Entidades
{
    public abstract class Entidad_usuario
    {
        private string usuario;
        private string password;
        private string nombre;
        private string pr_apellido;
        private string se_apellido;
        private int edad;
        private string telefono;
        private string email;

        public Entidad_usuario()
        {
            Usuario = string.Empty;
            Password = string.Empty;
            Nombre = string.Empty;
            Pr_apellido = string.Empty;
            Se_apellido = string.Empty;
            Edad = 0;
            Telefono = string.Empty;
            email = string.Empty;
        }


        public Entidad_usuario(string usuario, string password, string nombre, string pr_apellido, string se_apellido, int edad, string telefono, string email)
        {
            this.Usuario = usuario;
            this.Password = password;
            this.Nombre = nombre;
            this.Pr_apellido = pr_apellido;
            this.Se_apellido = se_apellido;
            this.Edad = edad;
            this.Telefono = telefono;
            this.Email = email;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Pr_apellido { get => pr_apellido; set => pr_apellido = value; }
        public string Se_apellido { get => se_apellido; set => se_apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
    }
}

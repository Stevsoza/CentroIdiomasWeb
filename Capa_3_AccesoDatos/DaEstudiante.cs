using Capa_4_Entidades;
using System;
using System.Data.SqlClient;


namespace Capa_3_AccesoDatos
{
    public class DaEstudiante
    {
        //atributos _____________________
        private string _cadenaConexion;
        private string _mensaje;

        public DaEstudiante(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //propiedades
        public string Mensaje { get => _mensaje; }

        //Métodos funcionales
        public int Insertar(Entidad_estudiante estudiante)
        {
            int id = 0;
            //establecer la conexión
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            //Establecer el objeto Command para crea los comandos
            SqlCommand comando = new SqlCommand();
            //Asignar la conexion al Command
            comando.Connection = conexion;
            //crear la sentencia 
            string sentencia = "INSERT INTO ESTUDIANTES (NOMBRE, P_APELLIDO, S_APELLIDO, EDAD, TELEFONO, EMAIL)" +
                " VALUES (@NOMBRE, @P_APELLIDO, @S_APELLIDO, @EDAD ,@TELEFONO, @EMAIL) SELECT @@IDENTITY" +
                " INSERT INTO LOGINS (ID_ESTUDIANTE,USUARIO, CONTRASENA) VALUES (@@IDENTITY,@USUARIO, @CONTRASENA)";
            //se envian los datos que se van a guardar en las variables
            comando.Parameters.AddWithValue("@USUARIO", estudiante.Usuario);
            comando.Parameters.AddWithValue("@CONTRASENA", estudiante.Password);
            comando.Parameters.AddWithValue("@NOMBRE", estudiante.Nombre);
            comando.Parameters.AddWithValue("@P_APELLIDO", estudiante.Pr_apellido);
            comando.Parameters.AddWithValue("@S_APELLIDO", estudiante.Se_apellido);
            comando.Parameters.AddWithValue("@TELEFONO", estudiante.Telefono);
            comando.Parameters.AddWithValue("@EDAD", estudiante.Edad);
            comando.Parameters.AddWithValue("@EMAIL", estudiante.Email);


            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return id;
        }

        public void ActualizarEstudiante(Entidad_estudiante estudiante)
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = string.Format("UPDATE ESTUDIANTES" +
                " SET DEUDA = {0}" +
                " WHERE ID_ESTUDIANTE = {1}", estudiante.Deuda, estudiante.Id_estudiante);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                comando.Dispose();
                conexion.Dispose();

            }
        }


        public Entidad_estudiante ObtenerEstudiante(string usuario, string contrasena)
        {
            Entidad_estudiante estudiante = new Entidad_estudiante();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT LOGINS.ID_ESTUDIANTE, NOMBRE, P_APELLIDO, S_APELLIDO, EDAD, TELEFONO, EMAIL, DEUDA, CURSOS_MATRICULADOS FROM LOGINS INNER JOIN ESTUDIANTES " +
            "ON LOGINS.ID_ESTUDIANTE = ESTUDIANTES.ID_ESTUDIANTE " +
            "WHERE USUARIO = '{0}' AND CONTRASENA = '{1}'", usuario, contrasena);

            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();//se debe colocar el data read para poder leer los datos
                    estudiante.Id_estudiante = dataReader.GetInt32(0);
                    estudiante.Nombre = dataReader.GetString(1);
                    estudiante.Pr_apellido = dataReader.GetString(2);
                    estudiante.Se_apellido = dataReader.GetString(3);
                    estudiante.Edad = dataReader.GetInt32(4);
                    estudiante.Telefono = dataReader.GetString(5);
                    estudiante.Email = dataReader.GetString(6);
                    if (dataReader.GetBoolean(7))
                    {
                        estudiante.Deuda = 1;
                    }
                    else
                    {
                        estudiante.Deuda = 0;
                    }
                    estudiante.Cursos_matriculados = dataReader.GetInt32(8);
                    estudiante.Existe = true;

                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return estudiante;
        }

        public Entidad_estudiante ObtenerDatos(int id)
        {
            Entidad_estudiante estudiante = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT LOGINS.ID_ESTUDIANTE, NOMBRE, P_APELLIDO, S_APELLIDO, EDAD, TELEFONO, EMAIL, DEUDA,CURSOS_MATRICULADOS FROM LOGINS INNER JOIN ESTUDIANTES " +
            "ON LOGINS.ID_ESTUDIANTE = ESTUDIANTES.ID_ESTUDIANTE " +
            "WHERE LOGINS.ID_ESTUDIANTE = '{0}'", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    estudiante = new Entidad_estudiante();
                    dataReader.Read();//se debe colocar el data read para poder leer los datos
                    estudiante.Id_estudiante = dataReader.GetInt32(0);
                    estudiante.Nombre = dataReader.GetString(1);
                    estudiante.Pr_apellido = dataReader.GetString(2);
                    estudiante.Se_apellido = dataReader.GetString(3);
                    estudiante.Edad = dataReader.GetInt32(4);
                    estudiante.Telefono = dataReader.GetString(5);
                    estudiante.Email = dataReader.GetString(6);
                    if (dataReader.GetBoolean(7))
                    {
                        estudiante.Deuda = 1;
                    }
                    else
                    {
                        estudiante.Deuda = 0;
                    }
                    estudiante.Cursos_matriculados = dataReader.GetInt32(8);
                    estudiante.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception) { throw; }
            return estudiante;
        }

        public int BuscarUsuario(string usuario)
        {
            int resultado = 0;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            comando.Connection = conexion;
            string sentencia = string.Format("SELECT LOGINS.USUARIO FROM LOGINS INNER JOIN ESTUDIANTES " +
            "ON LOGINS.ID_ESTUDIANTE = ESTUDIANTES.ID_ESTUDIANTE " +
            "WHERE LOGINS.USUARIO = '{0}'", usuario);
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    resultado = 0;
                }
                else
                {
                    resultado = 1;
                }

                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return resultado;
        }
    }
}

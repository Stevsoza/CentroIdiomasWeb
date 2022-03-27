using Capa_4_Entidades;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Capa_3_AccesoDatos
{
    public class DaMatriculas
    {
        private string _cadenaConexion;
        private string _mensaje;

        public DaMatriculas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }

        public bool InsertarEnMatricula(Entidad_matricula matricula)
        {
            bool matriculado = false;
            int id = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            string sentencia = "INSERT INTO MATRICULA(ID_ESTUDIANTE, ID_CURSO, FECHA, NIVEL_INTENSIDAD, COSTO" +
                ", CANCELADO) VALUES(@ID_ESTUDIANTE, @ID_CURSO, @FECHA, @NIVEL_INTENSIDAD, @COSTO, @CANCELADO)";

            comando.Parameters.AddWithValue("@ID_ESTUDIANTE", matricula.Id_estudiante);
            comando.Parameters.AddWithValue("@ID_CURSO", matricula.Id_curso);
            comando.Parameters.AddWithValue("@FECHA", matricula.Fecha);
            comando.Parameters.AddWithValue("@NIVEL_INTENSIDAD", matricula.Nivel_intensidad);
            comando.Parameters.AddWithValue("@COSTO", matricula.Costo);
            comando.Parameters.AddWithValue("@CANCELADO", matricula.Cancelado);


            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();

                if (id < 0)
                {
                    matriculado = false;
                }
                else if (id > 0)
                {
                    matriculado = true;
                }
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

            return matriculado;
        }

        public DataSet CargarMatriculas(int id)
        {

            DataSet DatoSet = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = string.Format("SELECT ID_MATRICULA ,ID_ESTUDIANTE, ID_CURSO, IDIOMA, FECHA, NIVEL_INTENSIDAD, COSTO, CANCELADO FROM MATRICULA" +
                " WHERE CANCELADO = 0 AND ID_ESTUDIANTE = {0}", id);

            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DatoSet, "MATRICULA");
            }
            catch (Exception)
            {
                throw;
            }


            return DatoSet;
        }

        public void ActualizarMatricula(int id)
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = string.Format("UPDATE MATRICULA" +
                " SET CANCELADO = 1" +
                " WHERE ID_MATRICULA = {0}", id);

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

        }

        public Entidad_matricula ObtenerEntidadMatricula(int id)
        {
            Entidad_matricula matricula = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            string sentencia = "SELECT ID_MATRICULA, ID_ESTUDIANTE, ID_CURSO, IDIOMA, FECHA, NIVEL_INTENSIDAD, " +
                "COSTO, CANCELADO FROM MATRICULA WHERE ID_MATRICULA = @MATRICULA";
            comando.Parameters.AddWithValue("@MATRICULA", id);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    matricula = new Entidad_matricula();
                    reader.Read();
                    matricula.Id_matricula = reader.GetInt32(0);
                    matricula.Id_estudiante = reader.GetInt32(1);
                    matricula.Id_curso = reader.GetInt32(2);
                    matricula.Idioma = reader.GetString(3);
                    matricula.Fecha = reader.GetDateTime(4);
                    matricula.Nivel_intensidad = reader.GetString(5);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return matricula;
        }

        public int EliminarMatricular(int id)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM MATRICULA WHERE ID_MATRICULA = @ID_MATRICULA";


            comando.Parameters.AddWithValue("@ID_MATRICULA", id);
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                resultado = comando.ExecuteNonQuery();
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

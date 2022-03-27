using Capa_4_Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_3_AccesoDatos
{
    public class DaClases
    {
        private string _cadenaConexion;
        private string _mensaje;


        public DaClases(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }

        public int crearClase(Entidad_clase clase)
        {
            int afectada = 0;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "INSERT INTO CLASES (ID_ESTUDIANTE, ID_CURSO, ID_PROFESOR, INICIO, FINAL) VALUES" +
                " (@id_estudiante, @id_curso, @id_profesor, @inicio, @final) select @@identity";

            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@id_estudiante", clase.Id_estudiante);
            comando.Parameters.AddWithValue("@id_curso", clase.Id_curso);
            comando.Parameters.AddWithValue("@id_profesor", clase.Id_profesor);
            comando.Parameters.AddWithValue("@inicio", clase.InicioClase);
            comando.Parameters.AddWithValue("@final", clase.FinClase);
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                afectada = Convert.ToInt32(comando.ExecuteScalar());
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

            return afectada;
        }

        public DataSet CargarClases(int idEstudiante)
        {
            DataSet DsClases = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adpater = new SqlDataAdapter();
            string sentencia =
                "SELECT ID_CLASE, CS.ID_CURSO, ID_PROFESOR, NOMBRE_CURSO ,INICIO, FINAL FROM CLASES CS " +
                "INNER JOIN CURSOS C " +
                "ON CS.ID_CURSO = C.ID_CURSO " +
                "WHERE ID_ESTUDIANTE = @ID_ESTUDIANTE AND CS.BORRADO_E = 0";

            /*comando.Connection = conexion;
            comando.CommandText = sentencia;
            comando.Parameters.AddWithValue("@ID_ESTUDIANTE", idEstudiante);*/
            try
            {
                conexion.Open();
                adpater.SelectCommand = new SqlCommand(sentencia, conexion);
                adpater.SelectCommand.Parameters.AddWithValue("@ID_ESTUDIANTE", idEstudiante);
                adpater.Fill(DsClases, "CLASES");
                conexion.Close();
                if (DsClases.Tables.Count <= 0)
                {
                    DsClases = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                adpater.SelectCommand.Dispose();
            }

            return DsClases;
        }

        public Entidad_clase ObtenerClase(int id)
        {
            Entidad_clase clase = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            string sentencia =
                "SELECT * FROM CLASES " +
                "WHERE ID_CLASE = @ID_CLASE AND BORRADO_E = 0";

            comando.Connection = conexion;
            comando.CommandText = sentencia;
            comando.Parameters.AddWithValue("@ID_CLASE", id);

            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    clase = new Entidad_clase();
                    reader.Read();
                    clase.Id_clase = reader.GetInt32(0);
                    clase.Id_estudiante = reader.GetInt32(1);
                    clase.Id_profesor = reader.GetInt32(2);
                    clase.Id_curso = reader.GetInt32(3);
                    clase.InicioClase = reader.GetDateTime(4);
                    clase.FinClase = reader.GetDateTime(5);
                }
                conexion.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return clase;
        }

        public int EliminarClase(int id)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia =
                "UPDATE CLASES " +
                "SET BORRADO_E = 1 " +
                "WHERE ID_CLASE = @ID_CLASE";
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            comando.Parameters.AddWithValue("@ID_CLASE", id);
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

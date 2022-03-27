using Capa_4_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Capa_3_AccesoDatos
{
    public class DaCursos
    {
        private string _cadenaConexion;
        private string _mensaje;

        public DaCursos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }

        public DataSet ListarCursosPrograma(string condicion = "", string orden = "")
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;



            string sentencia = "SELECT ID_CURSO, NOMBRE_CURSO, HORAS FROM CURSOS INNER JOIN PROGRAMA" +
                " ON CURSOS.ID_PROGRAMA = PROGRAMA.ID_PROGRAMA";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where IDIOMA = '{1}'", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden))
            {
                sentencia = string.Format("{0} Order by {1}", sentencia, orden);
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(datos, "CURSOS");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }

        public DataSet ListarCursosHistoria(string condicion = "", string orden = "")
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "SELECT ID_CURSO, NOMBRE_CURSO, FECHA_INICIO, FECHA_FINAL, HORAS_SINC_RES" +
                " FROM CURSOS_ESTUDIANTE";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where ID_ESTUDIANTE = '{1}'", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden))
            {
                sentencia = string.Format("{0} Order by {1}", sentencia, orden);
            }

            try
            {
                conexion.Open();
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(datos, "CURSOS_ESTUDIANTE");
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
            }
            return datos;
        }

        public DataSet ObtenerCurso(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = string.Format("SELECT ID_CURSO, ID_PROGRAMA, NOMBRE_CURSO, REQUISITO, HORAS, COSTO FROM CURSOS WHERE ID_CURSO = {0}", id);

            try
            {
                conexion.Open();
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(ds, "CURSOS");
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }


        public Entidad_curso ObtenerEntidadCurso(int id)
        {
            Entidad_curso curso = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            string sentencia = string.Format("SELECT * FROM CURSOS WHERE ID_CURSO = {0}", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    curso = new Entidad_curso();
                    reader.Read();
                    curso.Id_curso = reader.GetInt32(0);
                    curso.Id_programa = reader.GetInt32(1);
                    curso.NombreCurso = reader.GetString(2);
                    curso.Requisito = reader.GetString(3);
                    curso.Horas = reader.GetInt32(4);
                    curso.Costo = reader.GetDecimal(5);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return curso;
        }



        public List<Entidad_feriados> ObtenerFeriados(int anio)
        {
            DataSet DS = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<Entidad_feriados> feriados;

            string sentencia = string.Format("SELECT FECHA, DESCRIPCION, ANIO FROM FERIADOS WHERE ANIO = {0}", anio);


            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DS, "FERIADOS");
                feriados = (from DataRow fila in DS.Tables["FERIADOS"].Rows
                            select new Entidad_feriados()
                            {
                                Fecha = Convert.ToDateTime(fila[0]),
                                Descripcion = fila[1].ToString(),
                                Anio = Convert.ToInt32(fila[2]),
                            }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return feriados;
        }

        public bool BuscarRequisito(string curso)
        {
            bool seNecesita;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            string sentencia = string.Format("SELECT * FROM CURSOS_ESTUDIANTE WHERE NOMBRE_CURSO = '{0}' AND ESTADO = 'APR'", curso);

            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    seNecesita = false;
                }
                else
                {
                    seNecesita = true;
                }

                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return seNecesita;
        }

        public bool InsertarC_estudiante(Entidad_curso_estudiante matricular)
        {
            bool matriculado = false;
            int id = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            string sentencia = "INSERT INTO CURSOS_ESTUDIANTE(ID_CURSO, ID_ESTUDIANTE, NOMBRE_CURSO, FECHA_INICIO, FECHA_FINAL, ESTADO, HORAS_SINC_RES)" +
                " VALUES(@ID_CURSO, @ID_ESTUDIANTE, @NOMBRE_CURSO, @FECHA_INICIO, @FECHA_FINAL, @ESTADO, @HORAS_SINC_RES)";

            comando.Parameters.AddWithValue("@ID_CURSO", matricular.Id_curso);
            comando.Parameters.AddWithValue("@ID_ESTUDIANTE", matricular.Id_estudiante);
            comando.Parameters.AddWithValue("@NOMBRE_CURSO", matricular.NombreCurso);
            comando.Parameters.AddWithValue("@FECHA_INICIO", matricular.Fecha_inicio);
            comando.Parameters.AddWithValue("@FECHA_FINAL", matricular.Fecha_final);
            comando.Parameters.AddWithValue("@ESTADO", matricular.Estado);
            comando.Parameters.AddWithValue("@HORAS_SINC_RES", matricular.Horas_sin_res);

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
                else if (id >= 0)
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

        public bool BuscarCurso(string Nombre_curso, int id)
        {
            bool hayCursoIgual = false;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            string sentencia = "SELECT ID_CURSO FROM CURSOS_ESTUDIANTE WHERE NOMBRE_CURSO = @NOMBRE_CURSO" +
                " AND ID_ESTUDIANTE = @ID_ESTUDIANTE";

            comando.Parameters.AddWithValue("@NOMBRE_CURSO", Nombre_curso);
            comando.Parameters.AddWithValue("@ID_ESTUDIANTE", id);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    hayCursoIgual = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return hayCursoIgual;
        }

        public string buscarIdiomaCurso(int id)
        {
            //vamos a buscar con procedimiento almacenado el idioma del curso
            string idioma;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            //especificamos el procedimiento almacenado pasandolo al commandText
            comando.CommandText = "CURSO_IDIOMA";
            //definimos el tipo de conexion en este caso va a ser un procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@id_curso", id);
            comando.Parameters.Add("@idioma", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                idioma = comando.Parameters["@idioma"].Value.ToString();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return idioma;
        }

        public Entidad_curso_estudiante ObtenerC_estudiante(int id)
        {
            Entidad_curso_estudiante curso_est = new Entidad_curso_estudiante();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            string sentencia = string.Format("SELECT * FROM CURSOS_ESTUDIANTE WHERE ID_CURSO = {0}", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    curso_est.Id_curso = reader.GetInt32(0);
                    curso_est.Id_estudiante = reader.GetInt32(1);
                    curso_est.NombreCurso = reader.GetString(2);
                    curso_est.Fecha_inicio = reader.GetDateTime(3);
                    curso_est.Fecha_final = reader.GetDateTime(4);
                    curso_est.Estado = reader.GetString(5);
                    curso_est.Horas_sin_res = reader.GetInt32(6);

                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return curso_est;
        }

        public bool existeClaseCurso(int id, int estudiante)
        {
            bool existe;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            string sentencia = string.Format("SELECT * FROM CURSOS_ESTUDIANTE CE" +
                " INNER JOIN CLASES CL" +
                " ON CE.ID_ESTUDIANTE = CL.ID_ESTUDIANTE" +
                " WHERE CL.ID_CURSO = @ID_CURSO AND CL.ID_ESTUDIANTE = @ID_ESTUDIANTE AND CL.BORRADO_E = 0");

            comando.Connection = conexion;
            comando.CommandText = sentencia;
            comando.Parameters.AddWithValue("@ID_CURSO", id);
            comando.Parameters.AddWithValue("@ID_ESTUDIANTE", estudiante);
            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    existe = true;
                }
                else
                {
                    existe = false;
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
            return existe;
        }

        public int eliminarClasesVencidas(int id)
        {
            int clasesVencidas;
            DateTime fechaHoy = DateTime.Now;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "UPDATE CLASES " +
                               "SET BORRADO_E = 1 " +
                               "WHERE FINAL < @FECHA AND ID_ESTUDIANTE = @ID_ESTUDIANTE AND BORRADO_E = 0";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@FECHA", fechaHoy);
            comando.Parameters.AddWithValue("@ID_ESTUDIANTE", id);

            try
            {
                conexion.Open();
                clasesVencidas = comando.ExecuteNonQuery();
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
            return clasesVencidas;
        }
    }

}

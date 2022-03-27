using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_3_AccesoDatos
{
    public class DaProfesores
    {
        private string _cadenaConexion;
        private string _mensaje;

        public DaProfesores(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public string Mensaje { get => _mensaje; }


        public DataSet profesoresDisponibles(DateTime horaInicio, DateTime horaFinal, string idioma)
        {
            DataSet profdispo = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sentencia =
                "SELECT P.ID_PROFESOR, NOMBRE, P_APELLIDO, TELEFONO, EMAIL" +
                " FROM PROFESORES P LEFT JOIN CLASES C" +
                " ON P.ID_PROFESOR = C.ID_PROFESOR" +
                " WHERE NOT EXISTS (SELECT * FROM CLASES" +
                " WHERE (C.INICIO BETWEEN(@INICIO) AND (@FINAL)" +
                " OR C.FINAL BETWEEN (@INICIO) AND (@FINAL)) AND BORRADO_E = 0)" +
                " AND (CONVERT(TIME, @INICIO) BETWEEN HORA_ENTRADA AND HORA_SALIDA)" +
                " AND (CONVERT(TIME, @FINAL) BETWEEN HORA_ENTRADA AND HORA_SALIDA) AND IDIOMA = @IDIOMA" +
                " OR C.ID_PROFESOR IS NULL AND IDIOMA = @IDIOMA " +
                " AND (CONVERT(TIME, @INICIO) BETWEEN HORA_ENTRADA AND HORA_SALIDA)" +
                " AND (CONVERT(TIME, @FINAL) BETWEEN HORA_ENTRADA AND HORA_SALIDA)";

            /*comando.Parameters.AddWithValue("@INICIO", horaInicio);
            comando.Parameters.AddWithValue("@FINAL", horaFinal);*/
            try
            {
                conexion.Open();
                adapter.SelectCommand = new SqlCommand(sentencia, conexion);
                adapter.SelectCommand.Parameters.AddWithValue("@INICIO", horaInicio);
                adapter.SelectCommand.Parameters.AddWithValue("@FINAL", horaFinal);
                adapter.SelectCommand.Parameters.AddWithValue("@IDIOMA", idioma);
                adapter.Fill(profdispo, "PROFESORES");


                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return profdispo;
        }
    }
}

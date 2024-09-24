using System.Data.SqlClient;
using Dapper;

namespace Preguntados.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=PC-GAMER\SQLEXPRESS;Database=PreguntadOrt;Trusted_Connection=True;";

        public static List<Categoria> ObtenerCategorias()
        {
            string query = "SELECT * FROM Categorias";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Categoria>(query).ToList();
            }
        }

        public static List<Dificultad> ObtenerDificultades()
        {
            string query = "SELECT * FROM Dificultades";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Dificultad>(query).ToList();
            }
        }

        public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
        {
            string query = "SELECT * FROM Preguntas WHERE 1=1";
            if (dificultad != -1) query += " AND IdDificultad = @dificultad";
            if (categoria != -1) query += " AND IdCategoria = @categoria";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pregunta>(query, new { dificultad, categoria }).ToList();
            }
        }

        public static List<Respuesta> ObtenerRespuestas(int idPregunta)
        {
            string query = "SELECT * FROM Respuestas WHERE IdPregunta = @idPregunta";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Respuesta>(query, new { idPregunta }).ToList();
            }
        }
    }
}

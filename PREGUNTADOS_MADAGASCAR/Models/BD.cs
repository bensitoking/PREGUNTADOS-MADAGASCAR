using System.Data.SqlClient;
using Dapper;

public class BD
{
    private static string _connectionString = @"Server=PC-GAMER\SQLEXPRESS; DataBase=PreguntadOrt; Trusted_Connection=True;";

    public static List<Categoria> ObtenerCategorias()
    {
        List<Categoria> ListCategorias = new List<Categoria>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Categorias";
            ListCategorias = db.Query<Categoria>(sql).ToList();
        }
        return ListCategorias;
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        List<Dificultad> ListDificultades = new List<Dificultad>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Dificultades";
            ListDificultades = db.Query<Dificultad>(sql).ToList();
        }
        return ListDificultades;
    }

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        Console.WriteLine(dificultad);
        Console.WriteLine(categoria);
        List<Pregunta> ListPreguntas = new List<Pregunta>();
        string sql;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            if (dificultad == -1 && categoria == -1)
            {
                sql = "SELECT Preguntas., Categorias. FROM Preguntas INNER JOIN Categorias ON Preguntas.IdCategoria = Categorias.IdCategoria";
                ListPreguntas = db.Query<Pregunta>(sql).ToList();
            }
            else if (dificultad == -1)
            {
                sql = "SELECT * FROM Preguntas WHERE IdCategoria = @pCategoria";
                ListPreguntas = db.Query<Pregunta>(sql, new { @pCategoria = categoria }).ToList();
            }
            else if (categoria == -1)
            {
                sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad";
                ListPreguntas = db.Query<Pregunta>(sql, new { @pDificultad = dificultad }).ToList();
            }
            else
            {
                sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad AND IdCategoria = @pCategoria";
                ListPreguntas = db.Query<Pregunta>(sql, new { @pDificultad = dificultad, @pCategoria = categoria }).ToList();
            }

        }
        return ListPreguntas;
    }

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas)
    {
        List<Respuesta> ListRespuestas = new List<Respuesta>();
        string sql = "SELECT * FROM Respuestas INNER JOIN Preguntas ON Preguntas.IdPregunta = Respuestas.IdPregunta WHERE Respuestas.IdPregunta = @pPregunta";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {   
            foreach (Pregunta preg in preguntas)
            {
                List<Respuesta> RespuestaPreguntas = db.Query<Respuesta>(sql, new { @pPregunta = preg.Id }).ToList();
                ListRespuestas.AddRange(RespuestaPreguntas);
                Console.WriteLine(RespuestaPreguntas);
            }
        }
        return ListRespuestas;
    }

}
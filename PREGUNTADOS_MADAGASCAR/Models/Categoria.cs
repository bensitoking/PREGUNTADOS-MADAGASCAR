public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Categoria(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
    public Categoria()
    {
        
    }
}
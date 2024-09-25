public class Categoria
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; }

    public Categoria(int idCategoria, string nombre)
    {
        IdCategoria = idCategoria;
        Nombre = nombre;
    }
    public Categoria()
    {
        
    }
}
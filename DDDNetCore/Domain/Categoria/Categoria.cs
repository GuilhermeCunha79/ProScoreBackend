using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Categoria;

public class Categoria: Entity<Identifier>
{
    public TipoCategoria TipoCategoria { get; }

    public Categoria(string categoria)
    {
        Enum.TryParse(categoria, out TipoCategoria cat);
        TipoCategoria = cat;
    }
}
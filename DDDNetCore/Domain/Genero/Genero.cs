using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Genero;

public class Genero: Entity<Identifier>
{
    public TipoGenero TipoGenero { get; }

    public Genero(string genero)
    {
        Enum.TryParse(genero, out TipoGenero cat);
        TipoGenero = cat;
    }
}
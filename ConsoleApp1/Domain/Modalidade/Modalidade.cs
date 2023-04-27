using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Modalidade;

public class Modalidade: Entity<Identifier>
{
    public TipoModalidade TipoModalidade { get; }

    public Modalidade(string modalidade)
    {
        Enum.TryParse(modalidade, out TipoModalidade cat);
        TipoModalidade = cat;
    }
}
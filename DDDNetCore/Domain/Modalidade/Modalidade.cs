using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Modalidade;

public class Modalidade: Entity<Identifier>
{
    public TipoModalidade TipoModalidade { get; }
    public ICollection<Equipa.Equipa> Equipas { get; set; }
    public Modalidade()
    {
        
    }
    public Modalidade(string modalidade)
    {
        TipoModalidade = new TipoModalidade(modalidade);
    }
}
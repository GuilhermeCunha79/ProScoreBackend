using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Genero;

public class Genero: Entity<Identifier>
{
    public TipoGenero TipoGenero { get; set; }
    public ICollection<Pessoa.Pessoa> Pessoa { get; set; }
    public ICollection<Equipa.Equipa> Equipa { get; set; }
    public Genero()
    {
        
    }
    public Genero(string genero)
    {
        TipoGenero = new TipoGenero(genero);
    }
}
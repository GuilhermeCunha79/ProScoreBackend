using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Divisao;

public class Divisao:Entity<Identifier>
{
    
    public ICollection<Equipa.Equipa> Equipa { get; set; }
    
    public NomeDivisao NomeDivisao { get; set; }

    public Divisao()
    {
        
    }

    public Divisao(string nome)
    {
        NomeDivisao = new NomeDivisao(nome);
    }
    
}
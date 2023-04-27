using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Associacao : Entity<Identifier>
{
    public NomeAssociacao AssociacaoDesportiva { get; set; }
    
    public bool Active { get; set; }

    public Associacao(string associacaoDesportiva)
    {
        Id = new Identifier(Guid.NewGuid());
        AssociacaoDesportiva = new NomeAssociacao(associacaoDesportiva);
        Active = true;
    }

    public override string ToString()
    {
        return AssociacaoDesportiva.ToString();
    }
}
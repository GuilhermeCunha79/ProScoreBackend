using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;

public class Associacao : Entity<Identifier>,IAggregateRoot
{
    public NomeAssociacao NomeAssociacao { get; set; }
    
    //public NomeCurto NomeCurto { get; set; }

    public ICollection<Clube.Clube> Clubes { get; set; }

    public bool Active { get; set; }

    public Associacao()
    {
        
    }
    public Associacao(string associacaoDesportiva)
    {
        NomeAssociacao = new NomeAssociacao(associacaoDesportiva);
       // NomeCurto = new NomeCurto(nomeCurto);
        Active = true;
    }

    public override string ToString()
    {
        return NomeAssociacao.ToString();
    }
}
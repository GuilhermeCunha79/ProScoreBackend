using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;

public class Associacao : Entity<Identifier>,IAggregateRoot
{
    public NomeAssociacao NomeAssociacao { get; set; }
    
    public NomeCurto NomeCurto { get; set; }
    
    public Acronimo Acronimo{ get; set; }
    
    public ICollection<InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador> InscricaoDefinitivaAssociacaoJogador { get; set; }
    public ICollection<InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa> InscricaoDefinitivaAssociacaoEquipa { get; set; }

    public ICollection<Clube.Clube> Clubes { get; set; }
    public ICollection<Utilizador.Utilizador> Utilizadores { get; set; }

    public bool Active { get; set; }

    public Associacao()
    {
        
    }
    public Associacao(string associacaoDesportiva,string nomeCurto,string acronimo)
    {
        Id = new Identifier(Guid.NewGuid());
        NomeAssociacao = new NomeAssociacao(associacaoDesportiva);
        NomeCurto = new NomeCurto(nomeCurto);
        Acronimo = new Acronimo(acronimo);
        Active = true;
    }

    public override string ToString()
    {
        return NomeAssociacao.ToString();
    }
}
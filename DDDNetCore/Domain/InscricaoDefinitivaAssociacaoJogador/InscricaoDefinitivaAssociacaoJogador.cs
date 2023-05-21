using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;

public class InscricaoDefinitivaAssociacaoJogador:Entity<Identifier>
{
    public CodOperacao CodOperacao { get; set; }
    public NomeAssociacao NomeAssociacao { get; set; }
    public Licenca Licenca { get; set; }
    
    public ProcessoInscricao.ProcessoInscricao ProcessoInscricao { get; set; }
    
    public Jogador.Jogador Jogador { get; set; }
    public Associacao.Associacao Associacao { get; set; }

    public InscricaoDefinitivaAssociacaoJogador()
    {
        
    }
    
    
    public InscricaoDefinitivaAssociacaoJogador(string nomeAssociacao)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao();
        NomeAssociacao = new NomeAssociacao(nomeAssociacao);
        Licenca = new Licenca();
    }
    
    //Revalidação
    public InscricaoDefinitivaAssociacaoJogador(string nomeAssociacao,string licenca)
    {
        CodOperacao = new CodOperacao();
        NomeAssociacao = new NomeAssociacao(nomeAssociacao);
        Licenca = new Licenca(licenca);
    }
}
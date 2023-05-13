using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.ProcessoInscricao;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;

public class InscricaoDefinitivaAssociacaoJogador
{
    public CodOperacao CodOperacao { get; set; }
    public NomeAssociacao NomeAssociacao { get; set; }
    public Licenca Licenca { get; set; }
    
    public ProcessoInscricao.ProcessoInscricao ProcessoInscricao { get; set; }
    
    public Jogador.Jogador Jogador { get; set; }

    public InscricaoDefinitivaAssociacaoJogador()
    {
        
    }
    

    
    //Revalidaçao
    public InscricaoDefinitivaAssociacaoJogador(string nomeAssociacao)
    {
        CodOperacao = new CodOperacao();
        NomeAssociacao = new NomeAssociacao(nomeAssociacao);
        Licenca = new Licenca();
    }
}
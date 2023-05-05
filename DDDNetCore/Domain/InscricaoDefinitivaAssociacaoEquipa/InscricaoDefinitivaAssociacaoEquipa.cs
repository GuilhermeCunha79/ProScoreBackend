using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.ProcessoInscricao;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;

public class InscricaoDefinitivaAssociacaoEquipa
{
    public CodOperacao CodOperacao { get; set; }
    public NomeAssociacao NomeAssociacao { get; set; }
    public IdentificadorEquipa IdentificadorEquipa { get; set; }
    public ProcessoInscricao.ProcessoInscricao ProcessoInscricao { get; set; }

    public Equipa.Equipa Equipa { get; set; }

    public InscricaoDefinitivaAssociacaoEquipa()
    {

    }

    public InscricaoDefinitivaAssociacaoEquipa(string nomeAssociacao)
    {
        CodOperacao = new CodOperacao();
        NomeAssociacao = new NomeAssociacao(nomeAssociacao);
        IdentificadorEquipa = new IdentificadorEquipa();
    }

    //Revalidaçao
    public InscricaoDefinitivaAssociacaoEquipa(string nomeAssociacao, string licenca)
    {
        CodOperacao = new CodOperacao();
        NomeAssociacao = new NomeAssociacao(nomeAssociacao);
        IdentificadorEquipa = new IdentificadorEquipa(licenca);
    }
}
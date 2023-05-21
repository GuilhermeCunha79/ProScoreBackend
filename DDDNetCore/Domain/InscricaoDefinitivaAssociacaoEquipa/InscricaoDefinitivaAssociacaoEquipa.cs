using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;

public class InscricaoDefinitivaAssociacaoEquipa:Entity<Identifier>
{
    public CodOperacao CodOperacao { get; set; }
    public NomeAssociacao NomeAssociacao { get; set; }
    public IdentificadorEquipa IdentificadorEquipa { get; set; }
    public ProcessoInscricao.ProcessoInscricao ProcessoInscricao { get; set; }

    public Associacao.Associacao Associacao { get; set; }

    public Equipa.Equipa Equipa { get; set; }

    public bool Active { get; set; }

    public InscricaoDefinitivaAssociacaoEquipa()
    {

    }
    

    //Revalidaçao
    public InscricaoDefinitivaAssociacaoEquipa(string codOperacao,string nomeAssociacao,int idEquipa)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao(codOperacao);
        NomeAssociacao = new NomeAssociacao(nomeAssociacao);
        IdentificadorEquipa = new IdentificadorEquipa(idEquipa);
        Active = true;
    }
}
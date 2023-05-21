using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.ProcessoInscricao;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;

public class InscricaoDefinitivaAssociacaoJogadorDTO
{
    public Guid Id { get; set; }
    public CodOperacao CodOperacao { get; set; }
    public string NomeAssociacao { get; set; }
    public Licenca Licenca { get; set; }
    
    public InscricaoDefinitivaAssociacaoJogadorDTO(Guid id,string nomeAssociacao)
    {
        Id = id;
        CodOperacao = new CodOperacao();
        NomeAssociacao = nomeAssociacao;
        Licenca = new Licenca();
    }

    public InscricaoDefinitivaAssociacaoJogadorDTO(Guid id,string nomeAssociacao,string licenca)
    {
        Id = id;
        CodOperacao = new CodOperacao();
        NomeAssociacao = nomeAssociacao;
        Licenca = new Licenca(licenca);
    }
}
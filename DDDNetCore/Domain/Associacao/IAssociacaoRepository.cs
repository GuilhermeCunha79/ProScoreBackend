using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;


    public interface IAssociacaoRepository : IRepository<Associacao, Identifier>
    {
        Task<Associacao> GetByNomeAssociacao(string licenca);
        Task<Clube.Clube> GetNomeAssociacaoByCodClube(string licenca);
        Task<Associacao> GetNomeAssociacaoByLicenca(string licenca);

    }
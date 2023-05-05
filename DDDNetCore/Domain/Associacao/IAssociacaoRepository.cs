using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;


    public interface IAssociacaoRepository : IRepository<Associacao, Identifier>
    {
        Task<Associacao> GetByNomeAssociacao(string licenca);
    }
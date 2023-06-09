using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;


    public interface IDocIdentificacaoRepository : IRepository<DocIdentificacao, Identifier>
    {
        Task<DocIdentificacao> GetByNrIdAsync(string idEquipa);
    }

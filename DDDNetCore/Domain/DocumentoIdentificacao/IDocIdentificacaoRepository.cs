using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Infraestructure.DocumentoIdentificacao;


    public interface IDocIdentificacaoRepository : IRepository<DocIdentificacao, Identifier>
    {
        Task<DocIdentificacao> GetByNrIdAsync(string idEquipa);
    }

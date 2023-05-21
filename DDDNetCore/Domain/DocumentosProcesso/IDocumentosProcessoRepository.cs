using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentosProcesso;


public interface IDocumentosProcessoRepository : IRepository<DocumentosProcesso, Identifier>
{
    Task<DocumentosProcesso> GetByIdAsync(string idEquipa);
}

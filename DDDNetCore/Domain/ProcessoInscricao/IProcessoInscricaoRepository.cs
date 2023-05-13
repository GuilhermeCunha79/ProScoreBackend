using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public interface IProcessoInscricaoRepository : IRepository<ProcessoInscricao, Identifier>
{
    Task<ProcessoInscricao> GetByCodOperacaoAsync(string licenca);
}
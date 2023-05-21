using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public interface IProcessoInscricaoRepository : IRepository<ProcessoInscricao, Identifier>
{
    Task<ProcessoInscricao> GetByCodOperacaoAsync(string licenca);
    
    Task<InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador> GetByInfoCodOperacaoAsync(string licenca);
    
    Task<List<ProcessoInscricao>> GetProcessosAssociacaoByNomeAssociacaoAsync(string licenca);
}
using ConsoleApp1.Domain.VisualizacaoJogador;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public interface IProcessoInscricaoService
{

    Task<List<ProcessoInscricaoDTO>> GetAllAsync();
    Task<List<ProcessoJogadorVisualizacaoDTO>> GetAllAsync1();
    Task<ProcessoInscricaoDTO> GetByIdAsync(Identifier id);
    Task<ProcessoInscricaoDTO> GetByCodOperacao(string licenca);
    
    Task<List<ProcessoInscricaoDTO>> GetProcessosAssociacaoByNomeAssociacaoAsync(string licenca);
    
    Task<ProcessoInscricaoDTO> AddAsync(ProcessoInscricaoDTO obj);

    Task<ProcessoInscricaoDTO> UpdateAsync(ProcessoInscricaoDTO dto);

    Task<ProcessoInscricaoDTO> UpdateByCodOperacaoAsync(ProcessoInscricaoDTO dto);
    Task<ProcessoInscricaoDTO> InactivateAsync(Identifier id);
    
    Task<ProcessoInscricaoDTO> ActivateAsync(string id);

    Task<ProcessoInscricaoDTO> DeleteAsync(Identifier id);

}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;

public interface IAssociacaoService
{
    Task<List<AssociacaoDTO>> GetAllAsync();

    Task<AssociacaoDTO> GetByIdAsync(Identifier id);
    Task<AssociacaoDTO> GetByNomeAssociacao(string licenca);
    
    Task<AssociacaoDTO> GetNomeAssociacaoByCodClube(string licenca);
    Task<AssociacaoDTO> GetNomeAssociacaoByLicenca(string licenca);

    
    Task<AssociacaoDTO> AddAsync(AssociacaoDTO obj);

    Task<AssociacaoDTO> UpdateAsync(AssociacaoDTO dto);

    Task<AssociacaoDTO> UpdateByNomeAssAsync(AssociacaoDTO dto);
    Task<AssociacaoDTO> InactivateAsync(Identifier id);
    
    Task<AssociacaoDTO> ActivateAsync(string id);

    Task<AssociacaoDTO> DeleteAsync(Identifier id);
}
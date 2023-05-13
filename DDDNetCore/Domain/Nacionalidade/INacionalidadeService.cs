using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Nacionalidade;


public interface INacionalidadeService
{

    Task<List<NacionalidadeDTO>> GetAllAsync();

    Task<NacionalidadeDTO> GetByIdAsync(Identifier id);
    Task<NacionalidadeDTO> GetByNomePais(string licenca);
    
    Task<NacionalidadeDTO> AddAsync(NacionalidadeDTO obj);

    Task<NacionalidadeDTO> UpdateAsync(NacionalidadeDTO dto);

    Task<NacionalidadeDTO> UpdateByCodOperacaoAsync(NacionalidadeDTO dto);
    Task<NacionalidadeDTO> InactivateAsync(Identifier id);
    
    Task<NacionalidadeDTO> ActivateAsync(string id);

    Task<NacionalidadeDTO> DeleteAsync(Identifier id);

}
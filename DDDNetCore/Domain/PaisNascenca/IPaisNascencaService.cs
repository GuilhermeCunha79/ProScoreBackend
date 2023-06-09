using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.PaisNascenca;

public interface IPaisNascencaService
{

    Task<List<PaisNascencaDTO>> GetAllAsync();

    Task<PaisNascencaDTO> GetByIdAsync(Identifier id);
    Task<PaisNascencaDTO> GetByNomePais(string licenca);
    
    Task<PaisNascencaDTO> AddAsync(PaisNascencaDTO obj);

    Task<PaisNascencaDTO> UpdateAsync(PaisNascencaDTO dto);

    Task<PaisNascencaDTO> UpdateByCodOperacaoAsync(PaisNascencaDTO dto);
    Task<PaisNascencaDTO> InactivateAsync(Identifier id);
    
    Task<PaisNascencaDTO> ActivateAsync(string id);

    Task<PaisNascencaDTO> DeleteAsync(Identifier id);

}
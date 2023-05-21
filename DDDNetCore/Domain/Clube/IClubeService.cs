using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;


public interface IClubeService
{

    Task<List<ClubeDTO>> GetAllAsync();

    Task<ClubeDTO> GetByIdAsync(Identifier id);
    Task<ClubeDTO> GetByCodClube(string licenca);
    
    Task<ClubeDTO> AddAsync(ClubeDTO obj);

    Task<ClubeDTO> UpdateAsync(ClubeDTO dto);

    Task<ClubeDTO> UpdateByCodClubeAsync(ClubeDTO dto);
    Task<ClubeDTO> InactivateAsync(Identifier id);
    
    Task<ClubeDTO> ActivateAsync(string id);

    Task<ClubeDTO> DeleteAsync(Identifier id);

}
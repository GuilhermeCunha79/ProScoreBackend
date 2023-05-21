using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;


public interface IInscricaoDefinitivaAssociacaoEquipaService
{

    Task<List<InscricaoDefinitivaAssociacaoEquipaDTO>> GetAllAsync();

    Task<InscricaoDefinitivaAssociacaoEquipaDTO> GetByIdAsync(Identifier id);
    Task<InscricaoDefinitivaAssociacaoEquipaDTO> GetByCodClube(string licenca);
    
    Task<InscricaoDefinitivaAssociacaoEquipaDTO> AddAsync(InscricaoDefinitivaAssociacaoEquipaDTO obj);

    Task<InscricaoDefinitivaAssociacaoEquipaDTO> UpdateAsync(InscricaoDefinitivaAssociacaoEquipaDTO dto);

    Task<InscricaoDefinitivaAssociacaoEquipaDTO> UpdateByCodClubeAsync(InscricaoDefinitivaAssociacaoEquipaDTO dto);
    Task<InscricaoDefinitivaAssociacaoEquipaDTO> InactivateAsync(Identifier id);
    
    Task<InscricaoDefinitivaAssociacaoEquipaDTO> ActivateAsync(string id);

    Task<InscricaoDefinitivaAssociacaoEquipaDTO> DeleteAsync(Identifier id);

}
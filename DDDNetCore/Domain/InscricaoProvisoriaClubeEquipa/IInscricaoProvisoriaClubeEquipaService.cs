using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;


public interface IInscricaoProvisoriaClubeEquipaService
{

    Task<List<InscricaoProvisoriaClubeEquipaDTO>> GetAllAsync();

    Task<InscricaoProvisoriaClubeEquipaDTO> GetByIdAsync(Identifier id);
    Task<InscricaoProvisoriaClubeEquipaDTO> GetByIdEquipa(string licenca);
    
    Task<InscricaoProvisoriaClubeEquipaDTO> AddAsync(InscricaoProvisoriaClubeEquipaDTO obj);

    Task<InscricaoProvisoriaClubeEquipaDTO> UpdateAsync(InscricaoProvisoriaClubeEquipaDTO dto);

    Task<InscricaoProvisoriaClubeEquipaDTO> UpdateByIdEquipaAsync(InscricaoProvisoriaClubeEquipaDTO dto);
    Task<InscricaoProvisoriaClubeEquipaDTO> InactivateAsync(Identifier id);
    
    Task<InscricaoProvisoriaClubeEquipaDTO> ActivateAsync(string id);

    Task<InscricaoProvisoriaClubeEquipaDTO> DeleteAsync(Identifier id);

}
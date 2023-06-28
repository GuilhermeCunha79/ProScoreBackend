using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Equipa;

public interface IEquipaService
{
    Task<List<EquipaDTO>> GetAllAsync();

    Task<EquipaDTO> GetByIdAsync(Identifier id);
    Task<EquipaDTO> GetByIdentificadorEquipa(string licenca);

    Task<EquipaDTO> AddAsync(EquipaDTO obj);
    Task<List<EquipaDTO>> GetByCodClubeAsync(string licenca);
    Task<EquipaDTO> UpdateAsync(EquipaDTO dto);

    Task<EquipaDTO> UpdateByIdentificadorEquipaAsync(EquipaDTO dto);
    Task<EquipaDTO> InactivateAsync(Identifier id);

    Task<EquipaDTO> ActivateAsync(string id);

    Task<EquipaDTO> DeleteAsync(Identifier id);

    Task<EquipaDTO> GetByCatModAsync(string codClube,string categoria, string modalidade,
        string genero);
}
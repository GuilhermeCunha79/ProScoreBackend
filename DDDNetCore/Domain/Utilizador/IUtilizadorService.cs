using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Utilizador;

public interface IUtilizadorService
{

    Task<List<UtilizadorDTO>> GetAllAsync();
    Task<UtilizadorDTO> GetByIdAsync(Identifier id);
    Task<UtilizadorDTO> GetByEmail(string licenca);
    Task<UtilizadorDTO> AddAsync(UtilizadorDTO obj);
    Task<UtilizadorDTO> UpdateAsync(UtilizadorDTO dto);
    Task<UtilizadorDTO> UpdateByEmailAsync(UtilizadorDTO dto);
    Task<UtilizadorDTO> InactivateAsync(Identifier id);
    Task<UtilizadorDTO> ActivateAsync(string id);
    Task<UtilizadorDTO> DeleteAsync(Identifier id);

}
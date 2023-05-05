using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Jogador;

public interface IJogadorService
{

    Task<List<JogadorDTO>> GetAllAsync();

    Task<JogadorDTO> GetByIdAsync(Identifier id);
    Task<JogadorDTO> GetByLicencaJogador(string licenca);
    
    Task<JogadorDTO> AddAsync(JogadorDTO obj);

    Task<JogadorDTO> UpdateAsync(JogadorDTO dto);

    Task<JogadorDTO> UpdateByJogadorLicencaAsync(JogadorDTO dto);
    Task<JogadorDTO> InactivateAsync(Identifier id);
    
    Task<JogadorDTO> ActivateAsync(string id);

    Task<JogadorDTO> DeleteAsync(Identifier id);

}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;


public interface IInscricaoDefinitivaAssociacaoJogadorService
{

    Task<List<InscricaoDefinitivaAssociacaoJogadorDTO>> GetAllAsync();

    Task<InscricaoDefinitivaAssociacaoJogadorDTO> GetByIdAsync(Identifier id);
    Task<InscricaoDefinitivaAssociacaoJogadorDTO> GetByLicencaJogador(string licenca);
    
    Task<InscricaoDefinitivaAssociacaoJogadorDTO> AddAsync(InscricaoDefinitivaAssociacaoJogadorDTO obj);
    
    Task<InscricaoDefinitivaAssociacaoJogadorDTO> RevalidacaoAsync(InscricaoDefinitivaAssociacaoJogadorDTO obj);

    Task<InscricaoDefinitivaAssociacaoJogadorDTO> UpdateAsync(InscricaoDefinitivaAssociacaoJogadorDTO dto);

    Task<InscricaoDefinitivaAssociacaoJogadorDTO> UpdateByLicencaJogadorAsync(InscricaoDefinitivaAssociacaoJogadorDTO dto);
    Task<InscricaoDefinitivaAssociacaoJogadorDTO> InactivateAsync(Identifier id);
    
    Task<InscricaoDefinitivaAssociacaoJogadorDTO> ActivateAsync(string id);

    Task<InscricaoDefinitivaAssociacaoJogadorDTO> DeleteAsync(Identifier id);

}
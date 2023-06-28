using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;


public interface IInscricaoProvisoriaClubeJogadorService
{
    Task<InscricaoProvisoriaClubeJogadorDTO> GetByCodOperacao(string licenca);
    Task<InscricaoProvisoriaClubeJogadorDTO> UpdateByCodOperacaoAsync(InscricaoProvisoriaClubeJogadorDTO dto);
    Task<List<InscricaoProvisoriaClubeJogadorDTO>> GetAllAsync();

    Task<InscricaoProvisoriaClubeJogadorDTO> GetByIdAsync(Identifier id);
    Task<InscricaoProvisoriaClubeJogadorDTO> GetByLicencaJogador(string licenca);
    
    Task<InscricaoProvisoriaClubeJogadorDTO> AddAsync(InscricaoProvisoriaClubeJogadorDTO obj);

    Task<InscricaoProvisoriaClubeJogadorDTO> UpdateAsync(InscricaoProvisoriaClubeJogadorDTO dto);

    Task<InscricaoProvisoriaClubeJogadorDTO> UpdateByLicencaJogadorAsync(InscricaoProvisoriaClubeJogadorDTO dto);
    Task<InscricaoProvisoriaClubeJogadorDTO> InactivateAsync(Identifier id);
    
    Task<InscricaoProvisoriaClubeJogadorDTO> ActivateAsync(string id);

    Task<InscricaoProvisoriaClubeJogadorDTO> DeleteAsync(Identifier id);

}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public interface IPessoaService
{

    Task<List<PessoaDTO>> GetAllAsync();
    Task<PessoaDTO> GetByNrId(string licenca);
    Task<PessoaDTO> GetByIdAsync(Identifier id);
    Task<PessoaDTO> GetByIdPessoa(string licenca);
    
    Task<PessoaDTO> AddAsync(PessoaDTO obj);

    Task<PessoaDTO> UpdateAsync(PessoaDTO dto);

    Task<PessoaDTO> UpdateByIdPessoaAsync(PessoaDTO dto);
    Task<PessoaDTO> InactivateAsync(Identifier id);
    
    Task<PessoaDTO> ActivateAsync(string id);

    Task<PessoaDTO> DeleteAsync(Identifier id);

}
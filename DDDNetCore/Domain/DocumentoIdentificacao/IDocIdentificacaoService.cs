using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public interface IDocIdentificacaoService
{

    Task<List<DocIdentificacaoDTO>> GetAllAsync();

    Task<DocIdentificacaoDTO> GetByIdAsync(Identifier id);
    Task<DocIdentificacaoDTO> GetByNrId(string licenca);
    
    Task<DocIdentificacaoDTO> AddAsync(DocIdentificacaoDTO obj);

    Task<DocIdentificacaoDTO> UpdateAsync(DocIdentificacaoDTO dto);

    Task<DocIdentificacaoDTO> UpdateByNrIdAsync(DocIdentificacaoDTO dto);
    Task<DocIdentificacaoDTO> InactivateAsync(Identifier id);
    
    Task<DocIdentificacaoDTO> ActivateAsync(string id);

    Task<DocIdentificacaoDTO> DeleteAsync(Identifier id);

}
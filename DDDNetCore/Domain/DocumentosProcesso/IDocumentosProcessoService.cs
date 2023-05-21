using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentosProcesso;

public interface IDocumentosProcessoService
{
    Task<List<DocumentosProcessoDTO>> GetAllAsync();

    Task<DocumentosProcessoDTO> GetByIdAsync(Identifier id);

    
    Task<DocumentosProcessoDTO> AddAsync(DocumentosProcessoDTO obj);

    Task<DocumentosProcessoDTO> UpdateAsync(DocumentosProcessoDTO dto);

    Task<DocumentosProcessoDTO> UpdateByNrIdAsync(DocumentosProcessoDTO dto);
    Task<DocumentosProcessoDTO> InactivateAsync(Identifier id);
    
    Task<DocumentosProcessoDTO> ActivateAsync(string id);

    Task<DocumentosProcessoDTO> DeleteAsync(Identifier id);
}
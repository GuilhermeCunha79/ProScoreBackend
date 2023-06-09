using ConsoleApp1.Infraestructure.DocumentoIdentificacao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentosProcesso;





public class DocumentosProcessoService : IDocumentosProcessoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDocumentosProcessoRepository _repo;

    public DocumentosProcessoService(IUnitOfWork unitOfWork, IDocumentosProcessoRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<DocumentosProcessoDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<DocumentosProcessoDTO> listDto = list.ConvertAll(jogador =>
            new DocumentosProcessoDTO(jogador.Id.AsGuid(), jogador.CapturaBoletim.BoletimCaptura, jogador.CapturaDocIdentificacao.DocIdentificacaoCaptura,
                jogador.CodOperacao.CodOpe.ToString()));

        return listDto;
    }

    public async Task<DocumentosProcessoDTO> GetByIdAsync(Identifier id)
    {
        var jogador = await _repo.GetByIdAsync(id);

        if (jogador == null)
            return null;

        return new DocumentosProcessoDTO(jogador.Id.AsGuid(), jogador.CapturaBoletim.BoletimCaptura, jogador.CapturaDocIdentificacao.DocIdentificacaoCaptura,
            jogador.CodOperacao.CodOpe.ToString());
    }


    private string CheckStatus(bool status)
    {
        if (status)
        {
            return "Active";
        }
        else
        {
            return "Inactive";
        }
    }




    public async Task<DocumentosProcessoDTO> AddAsync(DocumentosProcessoDTO dto)
    {
        var jogador = new DocumentosProcesso(dto.CaminhoBoletim,dto.CaminhoDocIdentificacao,dto.CodOperacao);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new DocumentosProcessoDTO(jogador.Id.AsGuid(), jogador.CapturaBoletim.BoletimCaptura, jogador.CapturaDocIdentificacao.DocIdentificacaoCaptura,
            jogador.CodOperacao.CodOpe.ToString());
    }


    public async Task<DocumentosProcessoDTO> UpdateAsync(DocumentosProcessoDTO dto)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields

     


        await _unitOfWork.CommitAsync();

        return new DocumentosProcessoDTO(jogador.Id.AsGuid(), jogador.CapturaBoletim.BoletimCaptura, jogador.CapturaDocIdentificacao.DocIdentificacaoCaptura,
            jogador.CodOperacao.CodOpe.ToString());
    }
    
    
    public async Task<DocumentosProcessoDTO> UpdateByNrIdAsync(DocumentosProcessoDTO dto)
    {
        
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields

        await _unitOfWork.CommitAsync();

        return new DocumentosProcessoDTO(jogador.Id.AsGuid(), jogador.CapturaBoletim.BoletimCaptura, jogador.CapturaDocIdentificacao.DocIdentificacaoCaptura,
            jogador.CodOperacao.CodOpe.ToString());
    }
    

    public Task<DocumentosProcessoDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<DocumentosProcessoDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<DocumentosProcessoDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
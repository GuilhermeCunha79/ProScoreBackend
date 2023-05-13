using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;


public class ProcessoInscricaoService : IProcessoInscricaoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProcessoInscricaoRepository _repo;

    public ProcessoInscricaoService(IUnitOfWork unitOfWork, IProcessoInscricaoRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<ProcessoInscricaoDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<ProcessoInscricaoDTO> listDto = list.ConvertAll(jogador =>
            new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.TipoProcesso.ProcessoTipo,
                jogador.EpocaDesportiva.EpocaDesp));

        return listDto;
    }

    public Task<ProcessoInscricaoDTO> GetByIdAsync(Identifier id)
    {
        throw new NotImplementedException();
    }


    public async Task<ProcessoInscricaoDTO> GetByCodOperacao(string licenca)
    {
        var jogador = await _repo.GetByCodOperacaoAsync(licenca);

        if (jogador == null)
            return null;

        return new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.TipoProcesso.ProcessoTipo,
            jogador.EpocaDesportiva.EpocaDesp);
    }



    public async Task<ProcessoInscricaoDTO> AddAsync(ProcessoInscricaoDTO dto)
    {
        var jogador = new ProcessoInscricao(dto.TipoProcesso, dto.EpocaDesportiva);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.TipoProcesso.ProcessoTipo,
            jogador.EpocaDesportiva.EpocaDesp);

    }

    public Task<ProcessoInscricaoDTO> UpdateAsync(ProcessoInscricaoDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessoInscricaoDTO> UpdateByCodOperacaoAsync(ProcessoInscricaoDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessoInscricaoDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessoInscricaoDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessoInscricaoDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
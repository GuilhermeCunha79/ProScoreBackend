using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;


public class ProcessoInscricaoService : IProcessoInscricaoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProcessoInscricaoRepository _repo;
    private readonly DDDSample1DbContext _context;

    public ProcessoInscricaoService(IUnitOfWork unitOfWork, IProcessoInscricaoRepository repo,DDDSample1DbContext _context1)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
        _context = _context1;
    }

    public async Task<List<ProcessoInscricaoDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<ProcessoInscricaoDTO> listDto = list.ConvertAll(jogador =>
         new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(),jogador.Estado.Status,jogador.DataRegisto.DataReg,jogador.DataSubscricao.DataSubs,jogador.TipoProcesso.ProcessoTipo, jogador.EpocaDesportiva.EpocaDesp));

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

        return new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(),jogador.Estado.Status,jogador.DataRegisto.DataReg,jogador.DataSubscricao.DataSubs,jogador.TipoProcesso.ProcessoTipo, jogador.EpocaDesportiva.EpocaDesp);
    }
    
    public async Task<List<ProcessoInscricaoDTO>> GetProcessosAssociacaoByNomeAssociacaoAsync(string nomeAss)
    {
        var list = await _repo.GetProcessosAssociacaoByNomeAssociacaoAsync(nomeAss);

        List<ProcessoInscricaoDTO> listDto = list.ConvertAll(jogador =>
             new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(),jogador.Estado.Status,jogador.DataRegisto.DataReg,jogador.DataSubscricao.DataSubs,jogador.TipoProcesso.ProcessoTipo, jogador.EpocaDesportiva.EpocaDesp));

        return listDto;
    }



    public async Task<ProcessoInscricaoDTO> AddAsync(ProcessoInscricaoDTO dto)
    {
        var jogador = new ProcessoInscricao(dto.TipoProcesso,dto.CodOperacao);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(),jogador.Estado.Status,jogador.DataRegisto.DataReg,jogador.DataSubscricao.DataSubs,jogador.TipoProcesso.ProcessoTipo, jogador.EpocaDesportiva.EpocaDesp);

    }

    public async Task<ProcessoInscricaoDTO> UpdateAsync(ProcessoInscricaoDTO dto)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields

        jogador.ChangeDataRegisto();
        jogador.ChangeEstadoAprovado();

        await _unitOfWork.CommitAsync();

        return new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(),jogador.Estado.Status,jogador.DataRegisto.DataReg,jogador.DataSubscricao.DataSubs,jogador.TipoProcesso.ProcessoTipo, jogador.EpocaDesportiva.EpocaDesp);
    }

    public async Task<ProcessoInscricaoDTO> UpdateByCodOperacaoAsync(ProcessoInscricaoDTO dto)
    {
        var processo = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (processo == null)
            return null;

        // change  fields

        processo.ChangeEstadoAprovado();
        processo.ChangeDataRegisto();

        await _unitOfWork.CommitAsync();

        return new ProcessoInscricaoDTO(processo.Id.AsGuid(), processo.CodOperacao.CodOpe.ToString(),processo.TipoProcesso.ProcessoTipo,
            processo.Estado.Status,processo.EpocaDesportiva.EpocaDesp,processo.DataRegisto.DataReg,processo.DataSubscricao.DataSubs);
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
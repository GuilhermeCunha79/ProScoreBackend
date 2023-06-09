using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Divisao;


public class DivisaoService : IDivisaoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDivisaoRepository _repo;

    public DivisaoService(IUnitOfWork unitOfWork, IDivisaoRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<DivisaoDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<DivisaoDTO> listDto = list.ConvertAll(jogador =>
            new DivisaoDTO(jogador.NomeDivisao.Divisao));

        return listDto;
    }
}
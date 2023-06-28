using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.PaisNascenca;



public class PaisNascencaService : IPaisNascencaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaisNascencaRepository _repo;

    public PaisNascencaService(IUnitOfWork unitOfWork, IPaisNascencaRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<PaisNascencaDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        var listDto = list.ConvertAll(jogador =>
            new PaisNascencaDTO(jogador.NascencaPais.PaisNascenca, jogador.NomePais.Nome,
                jogador.CodPaises.CodigoPais));

        return listDto;
    }

    public Task<PaisNascencaDTO> GetByNomePais(string licenca)
    {
        throw new NotImplementedException();
    }

    public Task<PaisNascencaDTO> AddAsync(PaisNascencaDTO obj)
    {
        throw new NotImplementedException();
    }

    public Task<PaisNascencaDTO> UpdateAsync(PaisNascencaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<PaisNascencaDTO> UpdateByCodOperacaoAsync(PaisNascencaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<PaisNascencaDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<PaisNascencaDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<PaisNascencaDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<PaisNascencaDTO> GetByIdAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
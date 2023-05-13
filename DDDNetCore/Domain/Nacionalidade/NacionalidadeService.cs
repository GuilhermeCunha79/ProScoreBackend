using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Nacionalidade;


public class NacionalidadeService : INacionalidadeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INacionalidadeRepository _repo;

    public NacionalidadeService(IUnitOfWork unitOfWork, INacionalidadeRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<NacionalidadeDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<NacionalidadeDTO> listDto = list.ConvertAll(jogador =>
             new NacionalidadeDTO(jogador.NacionalidadePais.NacionalidadePaiss,jogador.NomePais.Nome,jogador.CodPaises.CodigoPais));

        return listDto;
    }

    public async Task<NacionalidadeDTO> GetByIdAsync(Identifier id)
    {
        var jogador = await _repo.GetByIdAsync(id);

        if (jogador == null)
            return null;

        return new NacionalidadeDTO(jogador.NacionalidadePais.NacionalidadePaiss,jogador.NomePais.Nome,jogador.CodPaises.CodigoPais);
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


    public async Task<NacionalidadeDTO> GetByNomePais(string licenca)
    {
        var jogador = await _repo.GetByNomePaisAsync(licenca);

        if (jogador == null)
            return null;

        return new NacionalidadeDTO(jogador.NacionalidadePais.NacionalidadePaiss,jogador.NomePais.Nome,jogador.CodPaises.CodigoPais);
    }


    public async Task<NacionalidadeDTO> AddAsync(NacionalidadeDTO dto)
    {
        var jogador = new Nacionalidade(dto.NacionalidadePais,dto.CodPais,dto.NomePais);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new NacionalidadeDTO(jogador.NacionalidadePais.NacionalidadePaiss,jogador.NomePais.Nome,jogador.CodPaises.CodigoPais);
    }


    public Task<NacionalidadeDTO> UpdateAsync(NacionalidadeDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<NacionalidadeDTO> UpdateByCodOperacaoAsync(NacionalidadeDTO dto)
    {
        throw new NotImplementedException();
    }
    

    public Task<NacionalidadeDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<NacionalidadeDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<NacionalidadeDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
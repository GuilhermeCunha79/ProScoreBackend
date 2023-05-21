using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;

public class InscricaoDefinitivaAssociacaoJogadorService : IInscricaoDefinitivaAssociacaoJogadorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInscricaoDefinitivaAssociacaoJogadorRepository _repo;

    public InscricaoDefinitivaAssociacaoJogadorService(IUnitOfWork unitOfWork, IInscricaoDefinitivaAssociacaoJogadorRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<InscricaoDefinitivaAssociacaoJogadorDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<InscricaoDefinitivaAssociacaoJogadorDTO> listDto = list.ConvertAll(associacao =>
            new InscricaoDefinitivaAssociacaoJogadorDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.Licenca.Lic.ToString()));

        return listDto;
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

    public async Task<InscricaoDefinitivaAssociacaoJogadorDTO> GetByLicencaJogador(string licenca)
    {
        var associacao = await this._repo.GetByLicencaJogador(licenca);

        if (associacao == null)
            return null;

        return new InscricaoDefinitivaAssociacaoJogadorDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.Licenca.Lic.ToString());
    }


    public async Task<InscricaoDefinitivaAssociacaoJogadorDTO> GetByIdAsync(Identifier id)
    {
        var associacao = await _repo.GetByIdAsync(id);

        if (associacao == null)
            return null;

        return new InscricaoDefinitivaAssociacaoJogadorDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.Licenca.Lic.ToString());
    }
    

    public async Task<InscricaoDefinitivaAssociacaoJogadorDTO> AddAsync(InscricaoDefinitivaAssociacaoJogadorDTO dto)
    {
        var associacao = new InscricaoDefinitivaAssociacaoJogador(dto.NomeAssociacao);

        await _repo.AddAsync(associacao);

        await _unitOfWork.CommitAsync();

        return new InscricaoDefinitivaAssociacaoJogadorDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss);
    }
    
    public async Task<InscricaoDefinitivaAssociacaoJogadorDTO> RevalidacaoAsync(InscricaoDefinitivaAssociacaoJogadorDTO dto)
    {
        var associacao = new InscricaoDefinitivaAssociacaoJogador(dto.NomeAssociacao,dto.Licenca.ToString());

        await _repo.AddAsync(associacao);

        await _unitOfWork.CommitAsync();

        return new InscricaoDefinitivaAssociacaoJogadorDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.Licenca.Lic.ToString());
    }
    

    public Task<InscricaoDefinitivaAssociacaoJogadorDTO> UpdateAsync(InscricaoDefinitivaAssociacaoJogadorDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoDefinitivaAssociacaoJogadorDTO> UpdateByLicencaJogadorAsync(InscricaoDefinitivaAssociacaoJogadorDTO dto)
    {
        throw new NotImplementedException();
    }
    

    public Task<InscricaoDefinitivaAssociacaoJogadorDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoDefinitivaAssociacaoJogadorDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoDefinitivaAssociacaoJogadorDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
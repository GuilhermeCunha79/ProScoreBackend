using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;

public class InscricaoDefinitivaAssociacaoEquipaService : IInscricaoDefinitivaAssociacaoEquipaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInscricaoDefinitivaAssociacaoEquipaRepository _repo;

    public InscricaoDefinitivaAssociacaoEquipaService(IUnitOfWork unitOfWork,
        IInscricaoDefinitivaAssociacaoEquipaRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<InscricaoDefinitivaAssociacaoEquipaDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<InscricaoDefinitivaAssociacaoEquipaDTO> listDto = list.ConvertAll(associacao =>
            new InscricaoDefinitivaAssociacaoEquipaDTO(associacao.Id.AsGuid(), associacao.CodOperacao.CodOpe.ToString(),
                associacao.NomeAssociacao.NomeAss,
                associacao.IdentificadorEquipa.IdEquipa, CheckStatus(associacao.Active)));

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

    public async Task<InscricaoDefinitivaAssociacaoEquipaDTO> GetByCodClube(string licenca)
    {
        var associacao = await this._repo.GetByCodClube(licenca);

        if (associacao == null)
            return null;

        return new InscricaoDefinitivaAssociacaoEquipaDTO(associacao.Id.AsGuid(),
            associacao.CodOperacao.CodOpe.ToString(), associacao.NomeAssociacao.NomeAss,
            associacao.IdentificadorEquipa.IdEquipa, CheckStatus(associacao.Active));
    }


    public async Task<InscricaoDefinitivaAssociacaoEquipaDTO> GetByIdAsync(Identifier id)
    {
        var associacao = await _repo.GetByIdAsync(id);

        if (associacao == null)
            return null;

        return new InscricaoDefinitivaAssociacaoEquipaDTO(associacao.Id.AsGuid(),
            associacao.CodOperacao.CodOpe.ToString(), associacao.NomeAssociacao.NomeAss,
            associacao.IdentificadorEquipa.IdEquipa, CheckStatus(associacao.Active));
    }


    public async Task<InscricaoDefinitivaAssociacaoEquipaDTO> AddAsync(InscricaoDefinitivaAssociacaoEquipaDTO dto)
    {
        var associacao = new InscricaoDefinitivaAssociacaoEquipa(dto.CodOperacao,dto.NomeAssociacao, dto.IdentificadorEquipa);

        await _repo.AddAsync(associacao);

        await _unitOfWork.CommitAsync();

        return new InscricaoDefinitivaAssociacaoEquipaDTO(associacao.Id.AsGuid(),
            associacao.CodOperacao.CodOpe.ToString(), associacao.NomeAssociacao.NomeAss,
            associacao.IdentificadorEquipa.IdEquipa, CheckStatus(associacao.Active));
    }


    public Task<InscricaoDefinitivaAssociacaoEquipaDTO> UpdateAsync(InscricaoDefinitivaAssociacaoEquipaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoDefinitivaAssociacaoEquipaDTO> UpdateByCodClubeAsync(
        InscricaoDefinitivaAssociacaoEquipaDTO dto)
    {
        throw new NotImplementedException();
    }


    public Task<InscricaoDefinitivaAssociacaoEquipaDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoDefinitivaAssociacaoEquipaDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoDefinitivaAssociacaoEquipaDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class ClubeService : IClubeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClubeRepository _repo;

    public ClubeService(IUnitOfWork unitOfWork, IClubeRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<ClubeDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<ClubeDTO> listDto = list.ConvertAll(jogador =>
            new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
                jogador.CodigoClube.CodClube,
                jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
                jogador.NifClube.ClubeNif, CheckStatus(jogador.Active)));

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

    public async Task<ClubeDTO> GetByCodClube(string licenca)
    {
        var jogador = await this._repo.GetByCodClubeAsync(licenca);

        if (jogador == null)
        {
            return null;
        }

        return new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
            jogador.CodigoClube.CodClube,
            jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
            jogador.NifClube.ClubeNif, CheckStatus(jogador.Active));
    }

    public async Task<ClubeDTO> GetByIdAsync(Identifier id)
    {
        var jogador = await _repo.GetByIdAsync(id);

        if (jogador == null)
            return null;

        return new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
            jogador.CodigoClube.CodClube,
            jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
            jogador.NifClube.ClubeNif, CheckStatus(jogador.Active));
    }


    public async Task<ClubeDTO> AddAsync(ClubeDTO dto)
    {
        var jogador = new Clube(dto.NomeAssociacao, dto.NomeClube, dto.NifClube.ToString(), dto.Morada,
            dto.TelefoneClube);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
            jogador.CodigoClube.CodClube,
            jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
            jogador.NifClube.ClubeNif, CheckStatus(jogador.Active));
    }


    public async Task<ClubeDTO> ActivateAsync(string id)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(id));

        if (jogador == null)
            return null;

        jogador.MarkAsAtive();

        await _unitOfWork.CommitAsync();

        return new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
            jogador.CodigoClube.CodClube,
            jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
            jogador.NifClube.ClubeNif, CheckStatus(jogador.Active));
    }


    public async Task<ClubeDTO> UpdateAsync(ClubeDTO dto)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields
        jogador.ChangeNomeClube(dto.NomeClube);
        jogador.ChangeMorada(dto.Morada);
        jogador.ChangeCodigoClube(dto.CodigoClube);
        jogador.ChangeNomeAssociacao(dto.NomeAssociacao);
        jogador.ChangeTelefone(dto.TelefoneClube);
        jogador.ChangeNifClube(dto.NifClube.ToString());


        await _unitOfWork.CommitAsync();

        return new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
            jogador.CodigoClube.CodClube,
            jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
            jogador.NifClube.ClubeNif, CheckStatus(jogador.Active));
    }

    public async Task<ClubeDTO> UpdateByCodClubeAsync(ClubeDTO dto)
    {
        var jogador = await this._repo.GetByCodClubeAsync(dto.CodigoClube.ToString());

        if (jogador == null)
            return null;

        jogador.ChangeNomeClube(dto.NomeClube);
        jogador.ChangeMorada(dto.Morada);
        jogador.ChangeCodigoClube(dto.CodigoClube);
        jogador.ChangeNomeAssociacao(dto.NomeAssociacao);
        jogador.ChangeTelefone(dto.TelefoneClube);
        jogador.ChangeNifClube(dto.NifClube.ToString());
        await this._unitOfWork.CommitAsync();

        return new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
            jogador.CodigoClube.CodClube,
            jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
            jogador.NifClube.ClubeNif, CheckStatus(jogador.Active));
    }

    public async Task<ClubeDTO> InactivateAsync(Identifier id)
    {
        var jogador = await _repo.GetByIdAsync(id);

        if (jogador == null)
            return null;

        jogador.MarkAsInative();

        await _unitOfWork.CommitAsync();

        return new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
            jogador.CodigoClube.CodClube,
            jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
            jogador.NifClube.ClubeNif, CheckStatus(jogador.Active));
    }

    public async Task<ClubeDTO> DeleteAsync(Identifier id)
    {
        var jogador = await _repo.GetByIdAsync(id);

        if (jogador == null)
            return null;

        if (jogador.Active)
            throw new BusinessRuleValidationException("It is not possible to delete an player.");

        _repo.Remove(jogador);
        await _unitOfWork.CommitAsync();

        return new ClubeDTO(jogador.Id.AsGuid(), jogador.NomeAssociacao.NomeAss, jogador.NomeClube.NomeClub,
            jogador.CodigoClube.CodClube,
            jogador.Morada.Morad, jogador.TelefoneClube.TelefoneClub, jogador.NrEquipas.NumeroEquipas,
            jogador.NifClube.ClubeNif, CheckStatus(jogador.Active));
    }
}
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;

public class AssociacaoService : IAssociacaoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAssociacaoRepository _repo;

    public AssociacaoService(IUnitOfWork unitOfWork, IAssociacaoRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<AssociacaoDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<AssociacaoDTO> listDto = list.ConvertAll(associacao =>
            new AssociacaoDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.NomeCurto.NomeCurt,associacao.Acronimo.Acronimoo));

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

    public async Task<AssociacaoDTO> GetByNomeAssociacao(string licenca)
    {
        var associacao = await this._repo.GetByNomeAssociacao(licenca);

        if (associacao == null)
            return null;

        return new AssociacaoDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.NomeCurto.NomeCurt,associacao.Acronimo.Acronimoo);
    }
    
    public async Task<AssociacaoDTO> GetNomeAssociacaoByCodClube(string licenca)
    {
        var associacao1 = this._repo.GetNomeAssociacaoByCodClube(licenca).Result.NomeAssociacao.NomeAss;

        if (associacao1 == null)
            return null;
        var associacao =  _repo.GetByNomeAssociacao(associacao1).Result;
        return new AssociacaoDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.NomeCurto.NomeCurt,associacao.Acronimo.Acronimoo);
    }
    
    public async Task<AssociacaoDTO> GetNomeAssociacaoByLicenca(string licenca)
    {
        var associacao1 = this._repo.GetNomeAssociacaoByLicenca(licenca).Result.NomeAssociacao.NomeAss;

        if (associacao1 == null)
            return null;
        var associacao =  _repo.GetByNomeAssociacao(associacao1).Result;
        return new AssociacaoDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.NomeCurto.NomeCurt,associacao.Acronimo.Acronimoo);
    }


    public async Task<AssociacaoDTO> GetByIdAsync(Identifier id)
    {
        var associacao = await _repo.GetByIdAsync(id);

        if (associacao == null)
            return null;

        return new AssociacaoDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.NomeCurto.NomeCurt,associacao.Acronimo.Acronimoo);
    }

    public Task<JogadorDTO> GetByLicencaJogador(string licenca)
    {
        throw new NotImplementedException();
    }

    public async Task<AssociacaoDTO> AddAsync(AssociacaoDTO dto)
    {
        var associacao = new Associacao(dto.NomeAssociacao,dto.NomeCurto,dto.Acronimo);

        await _repo.AddAsync(associacao);

        await _unitOfWork.CommitAsync();

        return new AssociacaoDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,associacao.NomeCurto.NomeCurt,associacao.Acronimo.Acronimoo);
    }
    

    public Task<AssociacaoDTO> UpdateAsync(AssociacaoDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<AssociacaoDTO> UpdateByNomeAssAsync(AssociacaoDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<AssociacaoDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<AssociacaoDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<AssociacaoDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;


public class InscricaoProvisoriaClubeEquipaService : IInscricaoProvisoriaClubeEquipaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInscricaoProvisoriaClubeEquipaRepository _repo;

    public InscricaoProvisoriaClubeEquipaService(IUnitOfWork unitOfWork, IInscricaoProvisoriaClubeEquipaRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<InscricaoProvisoriaClubeEquipaDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<InscricaoProvisoriaClubeEquipaDTO> listDto = list.ConvertAll(associacao =>
            new InscricaoProvisoriaClubeEquipaDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,associacao.IdentificadorEquipa.IdEquipa,associacao.CodigoClube.CodClube));

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

    public async Task<InscricaoProvisoriaClubeEquipaDTO> GetByIdEquipa(string licenca)
    {
        var associacao = await this._repo.GetByIdentificadorEquipa(licenca);

        if (associacao == null)
            return null;

        return  new InscricaoProvisoriaClubeEquipaDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,associacao.IdentificadorEquipa.IdEquipa,associacao.CodigoClube.CodClube);
    }


    public async Task<InscricaoProvisoriaClubeEquipaDTO> GetByIdAsync(Identifier id)
    {
        var associacao = await _repo.GetByIdAsync(id);

        if (associacao == null)
            return null;

        return new InscricaoProvisoriaClubeEquipaDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,associacao.IdentificadorEquipa.IdEquipa,associacao.CodigoClube.CodClube);
    }
    

    public async Task<InscricaoProvisoriaClubeEquipaDTO> AddAsync(InscricaoProvisoriaClubeEquipaDTO dto)
    {
        var associacao = new InscricaoProvisoriaClubeEquipa(dto.CodigoClube,dto.IdentificadorEquipa);

        await _repo.AddAsync(associacao);

        await _unitOfWork.CommitAsync();

        return new InscricaoProvisoriaClubeEquipaDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,associacao.IdentificadorEquipa.IdEquipa,associacao.CodigoClube.CodClube);
    }
    
    

    public Task<InscricaoProvisoriaClubeEquipaDTO> UpdateAsync(InscricaoProvisoriaClubeEquipaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoProvisoriaClubeEquipaDTO> UpdateByIdEquipaAsync(InscricaoProvisoriaClubeEquipaDTO dto)
    {
        throw new NotImplementedException();
    }
    

    public Task<InscricaoProvisoriaClubeEquipaDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoProvisoriaClubeEquipaDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoProvisoriaClubeEquipaDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
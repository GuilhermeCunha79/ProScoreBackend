using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;


public class InscricaoProvisoriaClubeJogadorService : IInscricaoProvisoriaClubeJogadorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInscricaoProvisoriaClubeJogadorRepository _repo;

    public InscricaoProvisoriaClubeJogadorService(IUnitOfWork unitOfWork, IInscricaoProvisoriaClubeJogadorRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<InscricaoProvisoriaClubeJogadorDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<InscricaoProvisoriaClubeJogadorDTO> listDto = list.ConvertAll(associacao =>
            new InscricaoProvisoriaClubeJogadorDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,associacao.CodigoClube.CodClube,associacao.Licenca.Lic,CheckStatus(associacao.Active)));

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

    public async Task<InscricaoProvisoriaClubeJogadorDTO> GetByLicencaJogador(string licenca)
    {
        var associacao = await this._repo.GetByLicencaJogador(licenca);

        if (associacao == null)
            return null;

        return  new InscricaoProvisoriaClubeJogadorDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,associacao.CodigoClube.CodClube,associacao.Licenca.Lic,CheckStatus(associacao.Active));
    }
    
    public async Task<InscricaoProvisoriaClubeJogadorDTO> GetByCodOperacao(string licenca)
    {
        var associacao = await this._repo.GetByCodOperacao(licenca);

        if (associacao == null)
            return null;

        return  new InscricaoProvisoriaClubeJogadorDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,associacao.CodigoClube.CodClube,associacao.Licenca.Lic,CheckStatus(associacao.Active));
    }


    public async Task<InscricaoProvisoriaClubeJogadorDTO> GetByIdAsync(Identifier id)
    {
        var associacao = await _repo.GetByIdAsync(id);

        if (associacao == null)
            return null;

        return new InscricaoProvisoriaClubeJogadorDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,
            associacao.CodigoClube.CodClube, associacao.CodigoClube.CodClube,CheckStatus(associacao.Active));
    }
    



    public async Task<InscricaoProvisoriaClubeJogadorDTO> AddAsync(InscricaoProvisoriaClubeJogadorDTO dto)
    {
        var associacao= new InscricaoProvisoriaClubeJogador(dto.CodOperacao,dto.CodigoClube,dto.Licenca.ToString());
     

        await _repo.AddAsync(associacao);

        await _unitOfWork.CommitAsync();

        return new InscricaoProvisoriaClubeJogadorDTO(associacao.Id.AsGuid(),associacao.CodOperacao.CodOpe,associacao.CodigoClube.CodClube,associacao.Licenca.Lic,CheckStatus(associacao.Active));
    }
    
    
    

    public async Task<InscricaoProvisoriaClubeJogadorDTO> UpdateAsync(InscricaoProvisoriaClubeJogadorDTO dto)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields
            //delivery.ChangeDeliveryMass(new DeliveryMass(dto.Mass));
        //delivery.ChangeDeliveryTime(new DeliveryTime(dto.PlacingTime, dto.WithdrawalTime));
        //delivery.ChangeStoreId(new WarehouseId(dto.StoreId));

        await _unitOfWork.CommitAsync();

        return new InscricaoProvisoriaClubeJogadorDTO(jogador.Id.AsGuid(),jogador.CodOperacao.CodOpe,jogador.CodigoClube.CodClube,jogador.Licenca.Lic,CheckStatus(jogador.Active));
    }

    public Task<InscricaoProvisoriaClubeJogadorDTO> UpdateByLicencaJogadorAsync(InscricaoProvisoriaClubeJogadorDTO dto)
    {
        throw new NotImplementedException();
    }
    
    public async Task<InscricaoProvisoriaClubeJogadorDTO> UpdateByCodOperacaoAsync(InscricaoProvisoriaClubeJogadorDTO dto)
    {
        var jogador = await _repo.GetByCodOperacao(dto.CodOperacao.ToString());

        if (jogador == null)
            return null;

        // change  fields

        jogador.ChangeEstadoAprovado();

        await _unitOfWork.CommitAsync();

        return new InscricaoProvisoriaClubeJogadorDTO(jogador.Id.AsGuid(),jogador.CodOperacao.CodOpe,jogador.CodigoClube.CodClube,jogador.Licenca.Lic,CheckStatus(jogador.Active));
    }
    

    public Task<InscricaoProvisoriaClubeJogadorDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoProvisoriaClubeJogadorDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<InscricaoProvisoriaClubeJogadorDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
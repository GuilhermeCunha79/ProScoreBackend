using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Jogador;

public class JogadorService:IJogadorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJogadorRepository _repo;

    public JogadorService(IUnitOfWork unitOfWork, IJogadorRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<JogadorDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<JogadorDTO> listDto = list.ConvertAll(jogador =>
            new JogadorDTO(jogador.Id.AsGuid(), jogador.EstatutoFpF.Estatuto, jogador.IdentificadorPessoa.IdPessoa,
                jogador.IdentificadorEquipa.IdEquipa, CheckStatus(jogador.Active)));

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
    
    public async Task<JogadorDTO> GetByDeliveryIdAsync(string licenca)
    {
        var jogador = await this._repo.GetByLicencaAsync(licenca);

        if (jogador == null)
            return null;

        return new JogadorDTO(jogador.Id.AsGuid(), jogador.EstatutoFpF.Estatuto, jogador.IdentificadorPessoa.IdPessoa,
            jogador.IdentificadorEquipa.IdEquipa, CheckStatus(jogador.Active));
    }
    

    public async Task<JogadorDTO> GetByIdAsync(Identifier id)
    {
        var jogador = await _repo.GetByIdAsync(id);

        if (jogador == null)
            return null;

        return new JogadorDTO(jogador.Id.AsGuid(), jogador.EstatutoFpF.Estatuto, jogador.IdentificadorPessoa.IdPessoa,
            jogador.IdentificadorEquipa.IdEquipa, CheckStatus(jogador.Active));
    }

    public Task<JogadorDTO> GetByLicencaJogador(string licenca)
    {
        throw new NotImplementedException();
    }

    public async Task<JogadorDTO> AddAsync(JogadorDTO dto)
    {
        var jogador = new Jogador(dto.EstatutoFPF, dto.IdentificadorPessoa, dto.IdentificadorEquipa.ToString());

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new JogadorDTO(jogador.Id.AsGuid(), jogador.EstatutoFpF.Estatuto, jogador.IdentificadorPessoa.IdPessoa,
            jogador.IdentificadorEquipa.IdEquipa, CheckStatus(jogador.Active));
    }

    public Task<JogadorDTO> UpdateAsync(JogadorDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<JogadorDTO> UpdateByJogadorLicencaAsync(JogadorDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<JogadorDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<JogadorDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<JogadorDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    /* public async Task<JogadorDTO> UpdateAsync(JogadorDTO dto)
    {
        var delivery = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (delivery == null)
            return null;

        // change all fields

        delivery.ChangeDeliveryDate(new DeliveryDate(dto.Day, dto.Month, dto.Year));
        delivery.ChangeDeliveryMass(new DeliveryMass(dto.Mass));
        delivery.ChangeDeliveryTime(new DeliveryTime(dto.PlacingTime, dto.WithdrawalTime));
        delivery.ChangeStoreId(new WarehouseId(dto.StoreId));

        await _unitOfWork.CommitAsync();

        return new JogadorDTO(jogador.Id.AsGuid(), jogador.EstatutoFpF.Estatuto, jogador.Licenca.Lic, jogador.IdentificadorPessoa.IdPessoa,
            jogador.IdentificadorEquipa.IdEquipa, CheckStatus(jogador.Active));
    }
    
    public async Task<DeliveryDTO> UpdateByDeliveryIdAsync(DeliveryDTO dto)
    {
        var delivery = await this._repo.GetByDeliveryIdAsync(dto.DeliveryIdentifier);

        if (delivery == null)
            return null;

        delivery.ChangeDeliveryDate(new DeliveryDate(dto.Day, dto.Month, dto.Year));
        delivery.ChangeDeliveryMass(new DeliveryMass(dto.Mass));
        delivery.ChangeDeliveryTime(new DeliveryTime(dto.PlacingTime, dto.WithdrawalTime));
        delivery.ChangeStoreId(new WarehouseId(dto.StoreId));

        await this._unitOfWork.CommitAsync();

        return new JogadorDTO(jogador.Id.AsGuid(), jogador.EstatutoFpF.Estatuto, jogador.Licenca.Lic, jogador.IdentificadorPessoa.IdPessoa,
            jogador.IdentificadorEquipa.IdEquipa, CheckStatus(jogador.Active));
    }

    public async Task<DeliveryDTO> InactivateAsync(Identifier id)
    {
        var delivery = await _repo.GetByIdAsync(id);

        if (delivery == null)
            return null;

        delivery.MarkAsInative();

        await _unitOfWork.CommitAsync();

        return new JogadorDTO(jogador.Id.AsGuid(), jogador.EstatutoFpF.Estatuto, jogador.Licenca.Lic, jogador.IdentificadorPessoa.IdPessoa,
            jogador.IdentificadorEquipa.IdEquipa, CheckStatus(jogador.Active));
    }

    public async Task<DeliveryDTO> DeleteAsync(Identifier id)
    {
        var delivery = await _repo.GetByIdAsync(id);

        if (delivery == null)
            return null;

        if (delivery.Active)
            throw new BusinessRuleValidationException("It is not possible to delete an active delivery plan.");

        _repo.Remove(delivery);
        await _unitOfWork.CommitAsync();

        return new JogadorDTO(jogador.Id.AsGuid(), jogador.EstatutoFpF.Estatuto, jogador.Licenca.Lic, jogador.IdentificadorPessoa.IdPessoa,
            jogador.IdentificadorEquipa.IdEquipa, CheckStatus(jogador.Active));*/
    }
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Equipa;

public class EquipaService:IEquipaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEquipaRepository _repo;

    public EquipaService(IUnitOfWork unitOfWork, IEquipaRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<EquipaDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<EquipaDTO> listDto = list.ConvertAll(jogador =>
            new EquipaDTO(jogador.Id.AsGuid(),jogador.IdentificadorEquipa.IdEquipa,jogador.Divisao.Div,jogador.CodigoClube.CodClube,jogador.TipoCategoria.Categoria,jogador.TipoGenero.Genero,jogador.TipoModalidade.Modalidade));

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
    
    public async Task<EquipaDTO> GetByIdentificadorEquipa(string licenca)
    {
        var jogador = await this._repo.GetByIdentificadorEquipaAsync(licenca);

        if (jogador == null)
        {
            return null;
        }

        return new EquipaDTO(jogador.Id.AsGuid(),jogador.IdentificadorEquipa.IdEquipa,jogador.Divisao.Div,jogador.CodigoClube.CodClube,jogador.Categoria.TipoCategoria.Categoria,jogador.Genero.TipoGenero.Genero,jogador.Modalidade.TipoModalidade.Modalidade);
    }
    
    public async Task<EquipaDTO> GetByIdAsync(Identifier id)
    {
        var jogador = await _repo.GetByIdAsync(id);

        if (jogador == null)
            return null;

        return new EquipaDTO(jogador.Id.AsGuid(),jogador.IdentificadorEquipa.IdEquipa,jogador.Divisao.Div,jogador.CodigoClube.CodClube,jogador.Categoria.TipoCategoria.Categoria,jogador.Genero.TipoGenero.Genero,jogador.Modalidade.TipoModalidade.Modalidade);
    }

    public Task<EquipaDTO> GetByLicencaJogador(string licenca)
    {
        throw new NotImplementedException();
    }

    public async Task<EquipaDTO> AddAsync(EquipaDTO dto)
    {
        var jogador = new Equipa(dto.Divisao, dto.CodigoClube,dto.Categoria,dto.Modalidade,dto.Genero);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new EquipaDTO(jogador.Id.AsGuid(),jogador.IdentificadorEquipa.IdEquipa,jogador.Divisao.Div,jogador.CodigoClube.CodClube,jogador.Categoria.TipoCategoria.Categoria,jogador.Genero.TipoGenero.Genero,jogador.Modalidade.TipoModalidade.Modalidade);
    }

    public Task<EquipaDTO> UpdateAsync(EquipaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<EquipaDTO> UpdateByIdentificadorEquipaAsync(EquipaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<EquipaDTO> UpdateByJogadorLicencaAsync(EquipaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<EquipaDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<EquipaDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<EquipaDTO> DeleteAsync(Identifier id)
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
using System.Reflection;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Utilizador;


public class UtilizadorService : IUtilizadorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUtilizadorRepository _repo;

    public UtilizadorService(IUnitOfWork unitOfWork, IUtilizadorRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<UtilizadorDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<UtilizadorDTO> listDto = list.ConvertAll(jogador =>
         new UtilizadorDTO(jogador.Id.AsGuid(), jogador.EmailUtilizador.Email, jogador.Role.RoleId,
            jogador.Password.Pass,
            jogador.NomeAssociacao.NomeAss,jogador.CodigoClube.CodClube));

        return listDto;
    }

    public Task<UtilizadorDTO> GetByIdAsync(Identifier id)
    {
        throw new NotImplementedException();
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



    public async Task<UtilizadorDTO> GetByEmail(string licenca)
    {

        var jogador = await _repo.GetByEmailAsync(licenca);

        if (jogador == null)
            return null;

        
        return new UtilizadorDTO(jogador.Id.AsGuid(), jogador.EmailUtilizador.Email, jogador.Role.RoleId,
            jogador.Password.Pass,
            jogador.NomeAssociacao.NomeAss,jogador.CodigoClube.CodClube);
    }



    public async Task<UtilizadorDTO> AddAsync(UtilizadorDTO dto)
    {

        var jogador=new Utilizador(dto.EmailUtilizador, dto.Role, dto.Password, dto.NomeAssociacao,dto.CodigoClube.ToString());

 
        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

         return new UtilizadorDTO(jogador.Id.AsGuid(), jogador.EmailUtilizador.Email, jogador.Role.RoleId,
            jogador.Password.Pass,
            jogador.NomeAssociacao.NomeAss,jogador.CodigoClube.CodClube);
    }


    public Task<UtilizadorDTO> UpdateAsync(UtilizadorDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<UtilizadorDTO> UpdateByEmailAsync(UtilizadorDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<UtilizadorDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<UtilizadorDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<UtilizadorDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Jogador;

public interface IJogadorRepository : IRepository<Jogador, Identifier>
{
    Task<Jogador> GetByLicencaAsync(string licenca);
    Task<Jogador> GetLicencaByIdPessoaAsync(string licenca);

}
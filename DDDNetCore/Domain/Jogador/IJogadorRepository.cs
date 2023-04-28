using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public interface IJogadorRepository : IRepository<Jogador, Identifier>
{
    Task<Jogador> GetByLicencaAsync(string licenca);
}
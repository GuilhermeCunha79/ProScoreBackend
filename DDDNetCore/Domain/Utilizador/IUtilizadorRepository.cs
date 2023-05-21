using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Utilizador;


public interface IUtilizadorRepository : IRepository<Utilizador, Identifier>
{
    Task<Utilizador> GetByEmailAsync(string licenca);
}
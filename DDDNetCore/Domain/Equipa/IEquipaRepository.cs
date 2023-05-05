using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Equipa;

public interface IEquipaRepository : IRepository<Equipa, Identifier>
{
    Task<Equipa> GetByIdentificadorEquipaAsync(string idEquipa);
}
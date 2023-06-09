using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.PaisNascenca;


public interface IPaisNascencaRepository : IRepository<PaisNascenca, Identifier>
{
    Task<PaisNascenca> GetPaisesAsync();
    
}

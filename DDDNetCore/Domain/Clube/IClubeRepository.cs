using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;


public interface IClubeRepository : IRepository<Clube, Identifier>
{
    Task<Clube> GetByCodClubeAsync(string idEquipa);
    Task<Clube> GetByNomeAsync(string idEquipa);
}
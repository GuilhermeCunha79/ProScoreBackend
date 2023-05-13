using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Nacionalidade;


public interface INacionalidadeRepository : IRepository<Nacionalidade, Identifier>
{
    Task<Nacionalidade> GetByNomePaisAsync(string idEquipa);
    
    Task<NacionalidadePais> GetByNomePaisAsync1(string idEquipa);
}

using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;


public interface IInscricaoDefinitivaAssociacaoEquipaRepository : IRepository<InscricaoDefinitivaAssociacaoEquipa, Identifier>
{
    Task<InscricaoDefinitivaAssociacaoEquipa> GetByCodClube(string licenca);
}
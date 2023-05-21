using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;


public interface IInscricaoProvisoriaClubeEquipaRepository : IRepository<InscricaoProvisoriaClubeEquipa, Identifier>
{
    Task<InscricaoProvisoriaClubeEquipa> GetByIdentificadorEquipa(string licenca);
}
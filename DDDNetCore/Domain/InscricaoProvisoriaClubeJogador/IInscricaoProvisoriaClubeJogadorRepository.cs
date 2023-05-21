using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;


public interface IInscricaoProvisoriaClubeJogadorRepository : IRepository<InscricaoProvisoriaClubeJogador, Identifier>
{
    Task<InscricaoProvisoriaClubeJogador> GetByLicencaJogador(string licenca);
}
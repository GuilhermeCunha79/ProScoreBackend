using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;


public interface IInscricaoDefinitivaAssociacaoJogadorRepository : IRepository<InscricaoDefinitivaAssociacaoJogador, Identifier>
{
    Task<InscricaoDefinitivaAssociacaoJogador> GetByLicencaJogador(string licenca);
}
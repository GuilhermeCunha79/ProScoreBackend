using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.InscricaoDefinitivaAssociacaoJogador;


public class InscricaoDefinitivaAssociacaoJogadorRepository :
    BaseRepository<Domain.InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador, Identifier>,
    IInscricaoDefinitivaAssociacaoJogadorRepository
{
    private readonly DDDSample1DbContext _context;

    public InscricaoDefinitivaAssociacaoJogadorRepository(DDDSample1DbContext context) : base(context.InscricaoDefinitivaAssociacaoJogador)
    {
        _context = context;
    }

    public async Task<Domain.InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador> GetByLicencaJogador(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT [j].[CodOperacao],  [j].[NomeAssociacao], [j].[Licenca]
                FROM [InscricaoDefinitivaAssociacaoJogador] AS [j]
                WHERE [j].[Licenca] = @licencaInt";


        return await _context.InscricaoDefinitivaAssociacaoJogador.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();


    }
}
using ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.InscricaoProvisoriaClubeJogador;


public class InscricaoProvisoriaClubeJogadorRepository :
    BaseRepository<Domain.InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador, Identifier>,
    IInscricaoProvisoriaClubeJogadorRepository
{
    private readonly DDDSample1DbContext _context;

    public InscricaoProvisoriaClubeJogadorRepository(DDDSample1DbContext context) : base(context.InscricaoProvisoriaClubeJogador)
    {
        _context = context;
    }

    public async Task<Domain.InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador> GetByLicencaJogador(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT [j].[CodOperacao],  [j].[CodigoClube], [j].[Licenca],[j].[Id]
                FROM [InscricaoProvisoriaClubeJogador] AS [j]
                WHERE [j].[Licenca] = @licencaInt";


        return await _context.InscricaoProvisoriaClubeJogador.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();


    }
}
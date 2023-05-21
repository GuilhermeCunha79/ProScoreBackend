using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.Clube;


public class ClubeRepository : BaseRepository<Domain.Clube.Clube, Identifier>, IClubeRepository
{
    private readonly DDDSample1DbContext _context;

    public ClubeRepository(DDDSample1DbContext context) : base(context.Clubes)
    {
        _context = context;
    }

    public async Task<Domain.Clube.Clube> GetByCodClubeAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT [j].[Licenca],  [j].[IdentificadorPessoa], [j].[EstatutoFpF], [j].[IdentificadorEquipa], [j].[Active], [j].[Id]
                FROM [Jogador] AS [j]
                WHERE [j].[Licenca] = @licencaInt";


        return await _context.Clubes.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();


    }
}

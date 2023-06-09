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
            @"SELECT [j].[CodigoClube],  [j].[NomeClube], [j].[NomeAssociacao], [j].[Morada], [j].[TelefoneClube],[j].[NrEquipas],[j].[NifClube],[j].[Active], [j].[Id]
                FROM [Clube] AS [j]
                WHERE [j].[CodigoClube] = @licencaInt";


        return await _context.Clubes.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();

    }
    

    public async Task<Domain.Clube.Clube> GetByNomeAsync(string licenca)
    {


        var query =
            @"SELECT [j].[CodigoClube],  [j].[NomeClube], [j].[NomeAssociacao], [j].[Morada], [j].[TelefoneClube],[j].[NrEquipas],[j].[NifClube],[j].[Active], [j].[Id]
                FROM [Clube] AS [j]
                WHERE [j].[NomeClube] = @licencaInt";


        return await _context.Clubes.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();

    }
}

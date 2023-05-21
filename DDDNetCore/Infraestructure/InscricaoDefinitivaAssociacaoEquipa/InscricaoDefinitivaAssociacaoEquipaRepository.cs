using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.InscricaoDefinitivaAssociacaoEquipa;


public class InscricaoDefinitivaAssociacaoEquipaRepository :
    BaseRepository<Domain.InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa, Identifier>,
    IInscricaoDefinitivaAssociacaoEquipaRepository
{
    private readonly DDDSample1DbContext _context;

    public InscricaoDefinitivaAssociacaoEquipaRepository(DDDSample1DbContext context) : base(context.InscricaoDefinitivaAssociacaoEquipas)
    {
        _context = context;
    }

    public async Task<Domain.InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa> GetByCodClube(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT [j].[CodOperacao],  [j].[NomeAssociacao], [j].[IdentificadorEquipa], [j].[Active], [j].[Id]
                FROM [InscricaoDefinitivaAssociacaoEquipa] AS [j]
                WHERE [j].[CodOperacao] = @licencaInt  AND [j].[Active] = 1";


        return await _context.InscricaoDefinitivaAssociacaoEquipas.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();


    }
}
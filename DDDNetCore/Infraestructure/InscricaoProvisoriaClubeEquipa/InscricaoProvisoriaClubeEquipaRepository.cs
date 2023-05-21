using ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.InscricaoProvisoriaClubeEquipa;


public class InscricaoProvisoriaClubeEquipaRepository :
    BaseRepository<Domain.InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa, Identifier>,
    IInscricaoProvisoriaClubeEquipaRepository
{
    private readonly DDDSample1DbContext _context;

    public InscricaoProvisoriaClubeEquipaRepository(DDDSample1DbContext context) : base(context.InscricaoProvisoriaClubeEquipa)
    {
        _context = context;
    }

    public async Task<Domain.InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa> GetByIdentificadorEquipa(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT [j].[CodOperacao],  [j].[CodigoClube], [j].[IdentificadorEquipa],[j].[Id]
                FROM [InscricaoProvisoriaClubeEquipa] AS [j]
                WHERE [j].[IdentificadorEquipa] = @licencaInt";


        return await _context.InscricaoProvisoriaClubeEquipa.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();


    }
}
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.Equipa;

public class EquipaRepository : BaseRepository<Domain.Equipa.Equipa, Identifier>, IEquipaRepository
{
    private readonly DDDSample1DbContext _context;

    public EquipaRepository(DDDSample1DbContext context) : base(context.Equipas)
    {
        _context = context;
    }

    public async Task<Domain.Equipa.Equipa> GetByIdentificadorEquipaAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT TOP(1) [j].[IdentificadorEquipa], [j].[NomeDivisao], [j].[CodigoClube],[j].[TipoCategoria],[j].[TipoModalidade], [j].[TipoGenero], [j].[Active],[j].[Id]
                FROM [Equipa] AS [j]
                WHERE [j].[IdentificadorEquipa] = @licencaInt  AND [j].[Active] = 1";


        return await _context.Equipas.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();
    }


    public async Task<Domain.Equipa.Equipa> GetByCatModAsync(string codClube,string categoria, string modalidade,
        string genero)
    {
        var query =
            @"SELECT TOP(1) [j].[IdentificadorEquipa], [j].[NomeDivisao], [j].[CodigoClube],[j].[TipoCategoria],[j].[TipoModalidade], [j].[TipoGenero], [j].[Active],[j].[Id]
                FROM [Equipa] AS [j]
                WHERE [j].[TipoCategoria] = @licencaInt  AND [j].[CodigoClube] = @licencaInt4  AND [j].[TipoModalidade] = @licencaInt2  AND  [j].[TipoGenero] = @licencaInt3 AND [j].[Active] = 1";


        return await _context.Equipas.FromSqlRaw(query,new SqlParameter("licencaInt4", codClube), new SqlParameter("licencaInt", categoria), new SqlParameter("licencaInt2", modalidade),
                new SqlParameter("licencaInt3", genero))
            .FirstOrDefaultAsync();
    }
}
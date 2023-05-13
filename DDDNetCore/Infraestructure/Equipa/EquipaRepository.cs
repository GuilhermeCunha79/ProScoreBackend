using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Domain.Equipa;

public class EquipaRepository : BaseRepository<Equipa, Identifier>, IEquipaRepository
{
    private readonly DDDSample1DbContext _context;

    public EquipaRepository(DDDSample1DbContext context) : base(context.Equipas)
    {
        _context = context;
    }

    public async Task<Equipa> GetByIdentificadorEquipaAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt)) {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }
        
        var query = @"SELECT TOP(1) [j].[IdentificadorEquipa], [j].[Divisao], [j].[CodigoClube],[j].[TipoCategoria],[j].[TipoModalidade], [j].[TipoGenero], [j].[Active],[j].[Id]
                FROM [Equipa] AS [j]
                WHERE [j].[IdentificadorEquipa] = @licencaInt  AND [j].[Active] = 1";
        
        
        return await _context.Equipas.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();
    }

    public Task<List<JogadorDTO>> GetByIdsAsync(List<Licenca> ids)
    {
        throw new System.NotImplementedException();
    }

    public Task<JogadorDTO> AddAsync(JogadorDTO obj)
    {
        throw new System.NotImplementedException();
    }
}
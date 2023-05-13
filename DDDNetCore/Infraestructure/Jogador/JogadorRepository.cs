using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.Jogador;

public class JogadorRepository : BaseRepository<Domain.Jogador.Jogador, Identifier>, IJogadorRepository
{
    private readonly DDDSample1DbContext _context;
        
    public JogadorRepository(DDDSample1DbContext context) : base(context.Jogadores)
    {
        _context = context;
    }

    public async Task<Domain.Jogador.Jogador> GetByLicencaAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt)) {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }
        
        var query = @"SELECT [j].[Licenca],  [j].[IdentificadorPessoa], [j].[EstatutoFpF], [j].[IdentificadorEquipa], [j].[Active], [j].[Id]
                FROM [Jogador] AS [j]
                WHERE [j].[Licenca] = @licencaInt  AND [j].[Active] = 1";
        
        
        return await _context.Jogadores.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
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
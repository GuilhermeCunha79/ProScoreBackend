using ConsoleApp1.Domain.Utilizador;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.Utilizador;


public class UtilizadorRepository : BaseRepository<Domain.Utilizador.Utilizador, Identifier>, IUtilizadorRepository
{
    private readonly DDDSample1DbContext _context;

    public UtilizadorRepository(DDDSample1DbContext context) : base(context.Utilizadores)
    {
        _context = context;
    }

    public async Task<Domain.Utilizador.Utilizador> GetByEmailAsync(string licenca)
    {


        var query =
            @"SELECT [j].[EmailUtilizador], [j].[Role], [j].[Password], [j].[NomeAssociacao], [j].[CodigoClube], [j].[Active], [j].[Id]
                FROM [Utilizador] AS [j]
                WHERE [j].[EmailUtilizador] = @licencaInt  AND [j].[Active] = 1";


        return await _context.Utilizadores.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();


    }
}
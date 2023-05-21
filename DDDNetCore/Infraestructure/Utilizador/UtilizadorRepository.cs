using ConsoleApp1.Domain.Genero;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Domain.Utilizador;


public class UtilizadorRepository : BaseRepository<Utilizador, Identifier>, IUtilizadorRepository
{
    private readonly DDDSample1DbContext _context;

    public UtilizadorRepository(DDDSample1DbContext context) : base(context.Utilizadores)
    {
        _context = context;
    }

    public async Task<Utilizador> GetByEmailAsync(string licenca)
    {


        var query =
            @"SELECT *
                FROM [Utilizador] AS [j]
                WHERE [j].[EmailUtilizador] = @licencaInt  AND [j].[Active] = 1";


        return await _context.Utilizadores.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();


    }
}
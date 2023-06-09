using ConsoleApp1.Domain.PaisNascenca;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.PaisNascenca;

public class PaisNascencaRepository: BaseRepository<Domain.PaisNascenca.PaisNascenca, Identifier>,
    IPaisNascencaRepository
{
    private readonly DDDSample1DbContext _context;

    public PaisNascencaRepository(DDDSample1DbContext context) : base(context.PaisNascenca)
    {
        _context = context;
    }
    public async Task<Domain.PaisNascenca.PaisNascenca> GetPaisesAsync()
    {


        var query =
                @"SELECT [j].[NascencaPais],[j].[NomePais],[j].[CodPaises],[j].[Id]
                FROM [PaisNascenca] AS [j]";


            return await _context.PaisNascenca.FromSqlRaw(query)
                .FirstOrDefaultAsync();
        
    }
}
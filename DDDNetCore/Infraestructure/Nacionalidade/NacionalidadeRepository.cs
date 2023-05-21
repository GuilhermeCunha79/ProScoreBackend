using ConsoleApp1.Domain.Nacionalidade;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.Nacionalidade;

public class NacionalidadeRepository : BaseRepository<Domain.Nacionalidade.Nacionalidade, Identifier>,
    INacionalidadeRepository
{
    private readonly DDDSample1DbContext _context;

    public NacionalidadeRepository(DDDSample1DbContext context) : base(context.Nacionalidades)
    {
        _context = context;
    }

    public async Task<Domain.Nacionalidade.Nacionalidade> GetByNomePaisAsync(string licenca)
    {
        

        var query =
            @"SELECT [j].[NacionalidadePais],[j].[NomePais],[j].[CodPaises],[j].[Id]
                FROM [Nacionalidade] AS [j]
                WHERE [j].[CodPaises] =@licencaInt";


        return await _context.Nacionalidades.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();
    }
    
    public async Task<NacionalidadePais> GetByNomePaisAsync1(string licenca)
    {
        

        var query =
            @"SELECT [j].[NacionalidadePais],[j].[NomePais],[j].[CodPaises],[j].[Id]
                FROM [Nacionalidade] AS [j]
                WHERE [j].[CodPaises] =@licencaInt";


        var result= await _context.Nacionalidades.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();

        return result.NacionalidadePais;
    }
}
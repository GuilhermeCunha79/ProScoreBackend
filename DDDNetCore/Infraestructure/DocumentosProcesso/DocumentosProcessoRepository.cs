using ConsoleApp1.Domain.DocumentosProcesso;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.DocumentosProcesso;

public class DocumentosProcessoRepository : BaseRepository<Domain.DocumentosProcesso.DocumentosProcesso, Identifier>, IDocumentosProcessoRepository
{
    private readonly DDDSample1DbContext _context;

    public DocumentosProcessoRepository(DDDSample1DbContext context) : base(context.DocumentosProcessos)
    {
        _context = context;
    }

    public async Task<Domain.DocumentosProcesso.DocumentosProcesso> GetByIdAsync(string licenca)
    {

        var query =
            @"SELECT TOP(1) [j].[CapturaBoletim], [j].[CapturaDocIdentificacao], [j].[CodOperacao]
                FROM [DocumentosProcesso] AS [j]
                WHERE [j].[Id] = @licencaInt ";


        return await _context.DocumentosProcessos.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();
    }
}
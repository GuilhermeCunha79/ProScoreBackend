using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.DocumentoIdentificacao;

public class DocIdentificacaoRepository : BaseRepository<DocIdentificacao, Identifier>, IDocIdentificacaoRepository
{
    private readonly DDDSample1DbContext _context;

    public DocIdentificacaoRepository(DDDSample1DbContext context) : base(context.DocId)
    {
        _context = context;
    }

    public async Task<DocIdentificacao> GetByNrIdAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt)) {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }
        
        var query = @"SELECT TOP(1) [j].[NrIdentificacao], [j].[LetrasDoc], [j].[CheckDigit],[j].[ValidadeDoc],[j].[NrUtente], [j].[Nif], [j].[Active],[j].[Id]
                FROM [DocumentoIdentificacao] AS [j]
                WHERE [j].[NrIdentificacao] = @licencaInt  AND [j].[Active] = 1";
        
        
        return await _context.DocId.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();
    }

}
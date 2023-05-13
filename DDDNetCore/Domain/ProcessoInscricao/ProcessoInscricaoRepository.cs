using ConsoleApp1.Infraestructure;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Domain.ProcessoInscricao;


public class ProcessoInscricaoRepository : BaseRepository<ProcessoInscricao, Identifier>, IProcessoInscricaoRepository
{
    private readonly DDDSample1DbContext _context;

    public ProcessoInscricaoRepository(DDDSample1DbContext context) : base(context.Processos)
    {
        _context = context;
    }

    public async Task<ProcessoInscricao> GetByCodOperacaoAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT TOP(1) [j].[CodOperacao], [j].[TipoProcesso], [j].[Estado],[j].[EpocaDesportiva],[j].[DataRegisto], [j].[DataSubscricao],[j].[Id]
                FROM [ProcessoInscricao] AS [j]
                WHERE [j].[IdentificadorEquipa] = @licencaInt  AND [j].[Active] = 1";


        return await _context.Processos.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();
    }
}
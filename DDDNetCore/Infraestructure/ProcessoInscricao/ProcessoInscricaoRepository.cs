using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.ProcessoInscricao;

public class ProcessoInscricaoRepository :
    BaseRepository<Domain.ProcessoInscricao.ProcessoInscricao, Identifier>,
    IProcessoInscricaoRepository
{
    private readonly DDDSample1DbContext _context;

    public ProcessoInscricaoRepository(DDDSample1DbContext context) : base(context.Processos)
    {
        _context = context;
    }

    public async Task<Domain.ProcessoInscricao.ProcessoInscricao> GetByCodOperacaoAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT [j].[CodOperacao],  [j].[TipoProcesso], [j].[Estado],[j].[EpocaDesportiva],[j].[DataRegisto],[j].[DataSubscricao],[j].[Id]
                FROM [ProcessoInscricao] AS [j]
                WHERE [j].[CodOperacao] = @licencaInt";


        return await _context.Processos.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();
    }


    public async Task<Domain.InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador>
        GetByInfoCodOperacaoAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"select * from InscricaoProvisoriaClubeJogador
                    WHERE @licencaInt = (SELECT j.CodOperacao
                     FROM [ProcessoInscricao] AS [j]
                     WHERE [j].[Estado] = 'AGUARDAR_APROVACAO_ASSOCIACAO'
            )";


        return await _context.InscricaoProvisoriaClubeJogador
            .FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();
    }

    public async Task<List<Domain.ProcessoInscricao.ProcessoInscricao>> GetProcessosAssociacaoByNomeAssociacaoAsync(
        string nomeAss)
    {
        var query = @"SELECT pi.* FROM ProcessoInscricao pi
                            INNER JOIN InscricaoProvisoriaClubeJogador ipcj ON pi.codOperacao = ipcj.codOperacao
                            INNER JOIN Clube c ON ipcj.CodigoClube = c.CodigoClube
                      WHERE c.NomeAssociacao = @nomeAss AND pi.Estado = 'AGUARDAR_APROVACAO_ASSOCIACAO';
        ";

        return await _context.Processos
            .FromSqlRaw(query, new SqlParameter("nomeAss", nomeAss))
            .ToListAsync();
    }

    public async Task<List<Domain.ProcessoInscricao.ProcessoInscricao>>
        GetProcessosPendentesAsync()
    {
        var query =
            @"SELECT [j].[CodOperacao],  [j].[TipoProcesso], [j].[Estado],[j].[EpocaDesportiva],[j].[DataRegisto],[j].[DataSubscricao],[j].[Id]
                FROM [ProcessoInscricao] AS [j]
                WHERE [j].[Estado] = 'AGUARDAR_APROVACAO_ASSOCIACAO'";


        return await _context.Processos.FromSqlRaw(query)
            .ToListAsync();
    }
}
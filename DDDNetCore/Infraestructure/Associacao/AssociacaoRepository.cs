using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.Associacao;


public class AssociacaoRepository : BaseRepository<Domain.Associacao.Associacao, Identifier>, IAssociacaoRepository
{
    private readonly DDDSample1DbContext _context;

    public AssociacaoRepository(DDDSample1DbContext context) : base(context.Associacoes)
    {
        _context = context;
    }

    public async Task<Domain.Associacao.Associacao> GetByNomeAssociacao(string licenca)
    {

        var query =
            @"SELECT [j].[NomeAssociacao],  [j].[NomeCurto], [j].[Acronimo],[j].[Active], [j].[Id]
                FROM [Associacao] AS [j]
                WHERE [j].[NomeAssociacao] = @licencaInt";


        return await _context.Associacoes.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();


    }

    public async Task<Domain.Clube.Clube> GetNomeAssociacaoByCodClube(string licenca)
    {
        var query =
            @"SELECT *
                FROM [Clube] AS [j]
                WHERE [j].[codigoClube] = @licencaInt";


        return await _context.Clubes.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();
    }
    
    public async Task<Domain.Associacao.Associacao> GetNomeAssociacaoByLicenca(string licenca)
    {
        var query =
            @"select [j].[NomeAssociacao], [j].[NomeCurto], [j].[Acronimo], [j].[Id], [j].[Active] from Associacao as [j]
WHERE NomeAssociacao= (select Clube.NomeAssociacao from Clube
                                    where CodigoClube= (select  CodigoClube from Equipa
                                                            where IdentificadorEquipa=@licencaInt))";


        return await _context.Associacoes.FromSqlRaw(query, new SqlParameter("licencaInt", licenca))
            .FirstOrDefaultAsync();
    }
    
    
}

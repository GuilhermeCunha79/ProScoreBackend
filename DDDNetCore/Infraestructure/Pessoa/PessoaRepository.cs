using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.Pessoa;

public class PessoaRepository : BaseRepository<Domain.Pessoa.Pessoa, Identifier>, IPessoaRepository
{
    private readonly DDDSample1DbContext _context;

    public PessoaRepository(DDDSample1DbContext context) : base(context.Pessoas)
    {
        _context = context;
    }

    public async Task<Domain.Pessoa.Pessoa> GetByIdPessoaAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT  [j].[IdentificadorPessoa], [j].[Nome], [j].[DataNascimento],[j].[Telefone],[j].[Email], [j].[ConcelhoResidência], [j].[TipoGenero],[j].[Active],[j].[NrIdentificacao],[j].[NascencaPais],[j].[NacionalidadePais],[j].[Id]
                FROM [Pessoa] AS [j]
                WHERE [j].[IdentificadorPessoa] = @licencaInt ";


        return await _context.Pessoas.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();
    }
    
    public async Task<Domain.Pessoa.Pessoa> GetByNrIdentificacaoAsync(string licenca)
    {
        if (!int.TryParse(licenca, out var licencaInt))
        {
            throw new ArgumentException("licenca parameter must be a valid integer");
        }

        var query =
            @"SELECT  [j].[IdentificadorPessoa], [j].[Nome], [j].[DataNascimento],[j].[Telefone],[j].[Email], [j].[ConcelhoResidência], [j].[TipoGenero],[j].[Active],[j].[NrIdentificacao],[j].[NascencaPais],[j].[NacionalidadePais],[j].[Id]
                FROM [Pessoa] AS [j]
                WHERE [j].[NrIdentificacao] = @licencaInt and [j].[Active]=1";


        return await _context.Pessoas.FromSqlRaw(query, new SqlParameter("licencaInt", licencaInt))
            .FirstOrDefaultAsync();
    }
}

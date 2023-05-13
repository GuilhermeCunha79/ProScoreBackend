using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public interface IPessoaRepository : IRepository<Pessoa, Identifier>
{
    Task<Pessoa> GetByIdPessoaAsync(string licenca);
}
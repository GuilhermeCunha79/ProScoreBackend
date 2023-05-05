using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public class IdentificadorPessoa
{
    public int IdPessoa { get; set; }

    public IdentificadorPessoa()
    {
        var options = SharedMethods.connection();
        using (var context = new DDDSample1DbContext(options))
        {
            var numeroDeTipos = context.ObterNumeroDePessoas() + 1;
            IdPessoa += numeroDeTipos;
        }
    }

    public IdentificadorPessoa(int idPessoa)
    {
        IdPessoa = idPessoa;
    }
}
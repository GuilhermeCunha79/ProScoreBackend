using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public class IdentificadorPessoa
{
    public int IdPessoa { get; set; }

    public IdentificadorPessoa(int idPessoa)
    {
        IdPessoa = idPessoa;
    }
}
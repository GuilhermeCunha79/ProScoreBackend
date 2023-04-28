using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class IdentificadorPessoa
{
    public string IdPessoa { get; set; }

    public IdentificadorPessoa(string idPessoa)
    {
        IdPessoa = idPessoa;
    }
}
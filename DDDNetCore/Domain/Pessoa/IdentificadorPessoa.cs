using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public class IdentificadorPessoa
{
    public int IdPessoa { get; set; }
    private static int totalEquipas = 0;
    public IdentificadorPessoa()
    {
        IdPessoa = totalEquipas++;
    }

    public IdentificadorPessoa(int idPessoa)
    {
        IdPessoa = idPessoa;
    }
}
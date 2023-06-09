namespace ConsoleApp1.Domain.Divisao;

public class DivisaoDTO
{
    public string NomeDivisao { get; set; }

    public DivisaoDTO(string nome)
    {
        NomeDivisao = nome;
    }
}
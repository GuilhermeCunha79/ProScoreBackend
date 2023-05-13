namespace ConsoleApp1.Domain.Nacionalidade;

public class NacionalidadeDTO
{
    public string NacionalidadePais { get; set; }
    public string NomePais { get; set; }
    public string CodPais { get; set; }

    public NacionalidadeDTO(string pais, string nome, string cod)
    {
        NacionalidadePais = pais;
        NomePais = nome;
        CodPais = cod;
    }
}
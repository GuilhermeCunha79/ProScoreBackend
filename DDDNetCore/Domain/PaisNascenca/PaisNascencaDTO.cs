namespace ConsoleApp1.Domain.PaisNascenca;

public class PaisNascencaDTO
{
    public string NascencaPais { get; set; }
    public string NomePais { get; set; }
    public string CodPaises { get; set; }

    public PaisNascencaDTO(string nascencaPais, string nomePais, string codPaises)
    {
        NascencaPais = nascencaPais;
        NomePais = nomePais;
        CodPaises = codPaises;
    }
}
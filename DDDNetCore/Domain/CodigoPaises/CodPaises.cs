namespace ConsoleApp1.Domain.CodigoPaises;

public class CodPaises
{
    public string CodPais { get; set; }

    public CodPaises(string pais)
    {
        CodPais = codigoPaises(pais);
    }

    public string codigoPaises(string pais)
    {
        return pais;
    }
}
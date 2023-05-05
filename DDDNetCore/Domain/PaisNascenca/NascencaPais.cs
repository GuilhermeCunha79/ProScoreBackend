using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.PaisNascenca;

public class NascencaPais: IValueObject
{
    public string PaisNascenca { get; set; }

    public NascencaPais()
    {
        
    }

    public NascencaPais(string pais)
    {
        PaisNascenca = pais;
    }
}
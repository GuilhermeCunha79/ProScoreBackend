using System.Globalization;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.CodigoPaises;

public class CodPaises:IValueObject
{

    public string CodigoPais { get; set; }

    public CodPaises()
    {
        
    }
    public CodPaises(string nome)
    {
        CodigoPais = nome;
    }

}
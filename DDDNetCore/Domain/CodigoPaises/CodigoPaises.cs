using System.Globalization;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.CodigoPaises;

public class CodigoPaises:Entity<Identifier>
{
    public CodPaises CodPais { get; set; }
    public ICollection<PaisCodigo.PaisCodigo >PaisCodigo { get; set; }

    public CodigoPaises()
    {
        
    }

    public CodigoPaises(string pais)
    {
        CodPais = new CodPaises(pais);
    }

    
}
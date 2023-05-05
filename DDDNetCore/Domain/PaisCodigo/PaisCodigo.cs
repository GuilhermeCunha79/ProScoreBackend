using ConsoleApp1.Domain.CodigoPaises;
using ConsoleApp1.Domain.Pais;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.PaisCodigo;

public class PaisCodigo:Entity<Identifier>
{

    public Pais.Pais Pais { get; set; }
    public NomePais NomePais { get; set; }
    public CodPaises CodPaises{ get; set; }

    public Nacionalidade.Nacionalidade Nacionalidade { get; set; }
    public PaisNascenca.PaisNascenca PaisNascenca { get; set; }
    public CodigoPaises.CodigoPaises CodigoPaises { get; set; }

    public PaisCodigo()
    {
        
    }
    public PaisCodigo(string pais, string cod)
    {
        NomePais = new NomePais(pais);
        CodPaises = new CodPaises(cod);
    }

}
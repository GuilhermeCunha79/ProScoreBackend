using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pais;

public class Pais: Entity<Identifier>
{

    public NomePais NomePais { get; set; }

    public ICollection<PaisCodigo.PaisCodigo >PaisCodigo { get; set; }

    public Pais()
    {
        
    }
    
    public Pais(string pais)
    {
        NomePais = new NomePais(pais);
    }

}
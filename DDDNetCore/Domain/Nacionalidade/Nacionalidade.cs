using ConsoleApp1.Domain.CodigoPaises;
using ConsoleApp1.Domain.Pais;

namespace ConsoleApp1.Domain.Nacionalidade;

public class Nacionalidade
{
    public NacionalidadePais NacionalidadePais { get; set; }
    
    public Pessoa.Pessoa Pessoa { get; set; }
    public PaisCodigo.PaisCodigo PaisCodigo { get; set; }
    public NomePais NomePais { get; set; }
    public CodPaises CodPaises{ get; set; }

    public Nacionalidade()
    {
        
    }
    public Nacionalidade(string nacao)
    {
        NacionalidadePais = new NacionalidadePais(nacao);
    }
    

   
}
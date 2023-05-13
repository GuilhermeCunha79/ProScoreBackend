using System.Globalization;
using ConsoleApp1.Domain.CodigoPaises;
using ConsoleApp1.Domain.Pais;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Nacionalidade;

public class Nacionalidade:Entity<Identifier>
{
    public NacionalidadePais NacionalidadePais { get; set; }
    
    public Pessoa.Pessoa Pessoa { get; set; }
    public PaisCodigo.PaisCodigo PaisCodigo { get; set; }
    public NomePais NomePais { get; set; }
    public CodPaises CodPaises{ get; set; }

    public Nacionalidade()
    {
        
    }
    public Nacionalidade(string nacao,string codPais,string nome)
    {
        NacionalidadePais = new NacionalidadePais(nacao.TrimStart().TrimEnd());
        NomePais = new NomePais(nome);
        CodPaises = new CodPaises(codPais);
    }
    
   
   
}
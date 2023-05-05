using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;

public class InscricaoProvisoriaClubeJogador : Entity<Identifier>
{
    public CodOperacao CodOperacao { get; set; }
    public CodigoClube CodigoClube { get; set; }
    public Licenca Licenca { get; set; }
    public ProcessoInscricao.ProcessoInscricao ProcessoInscricao { get; set; }
    public Jogador.Jogador Jogador { get; set; }
    public Clube.Clube Clube { get; set; }
    public InscricaoProvisoriaClubeJogador()
    {
        
    }    
    public InscricaoProvisoriaClubeJogador(string codClube)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao();
        Licenca = new Licenca();
        CodigoClube = new CodigoClube(codClube);
       
    }
    
    public InscricaoProvisoriaClubeJogador(string codClube,string licenca)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao();
        Licenca = new Licenca(licenca);
        CodigoClube = new CodigoClube(codClube);
      
    }
}
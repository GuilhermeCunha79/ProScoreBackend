using ConsoleApp1.Domain.Forms;
using ConsoleApp1.Shared;

namespace ConsoleApp1.InscricaoProvisoriaClubeJogador;

public class InscricaoProvisoriaClubeJogador : Entity<Identifier>
{
    public CodOperacao CodOperacao { get; set; }
    public CodigoClube CodigoClube { get; set; }
    public Licenca Licenca { get; set; }
    public DataSubscricao DataSubscricao { get; set; }

    public InscricaoProvisoriaClubeJogador(string codOperacao,string codClube)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao(codOperacao);
        Licenca = new Licenca();
        CodigoClube = new CodigoClube(codClube);
        DataSubscricao = new DataSubscricao();
    }
    
    public InscricaoProvisoriaClubeJogador(string codOperacao,string codClube,string licenca)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao(codOperacao);
        Licenca = new Licenca(licenca);
        CodigoClube = new CodigoClube(codClube);
        DataSubscricao = new DataSubscricao();
    }
}
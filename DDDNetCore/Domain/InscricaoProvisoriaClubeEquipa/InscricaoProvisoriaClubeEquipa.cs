using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;

public class InscricaoProvisoriaClubeEquipa : Entity<Identifier>
{
    public CodOperacao CodOperacao { get; set; }
    public CodigoClube CodigoClube { get; set; }
    public IdentificadorEquipa IdentificadorEquipa { get; set; }
    public Equipa.Equipa Equipa { get; set; }
    
    public Clube.Clube Clube { get; set; }
    public ProcessoInscricao.ProcessoInscricao ProcessoInscricao { get; set; }

    public InscricaoProvisoriaClubeEquipa()
    {
    }

   
    public InscricaoProvisoriaClubeEquipa(int codClube, int idEquipa)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao();
        IdentificadorEquipa = new IdentificadorEquipa(idEquipa);
        CodigoClube = new CodigoClube(codClube);

    }
}
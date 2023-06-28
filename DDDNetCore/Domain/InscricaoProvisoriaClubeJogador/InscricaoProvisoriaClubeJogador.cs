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

    public bool Active { get; set; }

    public InscricaoProvisoriaClubeJogador()
    {
        
    }    
    public InscricaoProvisoriaClubeJogador(int codClube){
    
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao();
        Licenca = new Licenca();
        CodigoClube = new CodigoClube(codClube);
        Active = false;
    }
    
    //REVALIDAÇAO
    
    public InscricaoProvisoriaClubeJogador(int codClube,string licenca){
    
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao();
        Licenca = new Licenca(licenca);
        CodigoClube = new CodigoClube(codClube);
        Active = true;
    }
    
    public InscricaoProvisoriaClubeJogador(int codOperacao,int codClube,string licenca){
    
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao(codOperacao.ToString());
        Licenca = new Licenca(licenca);
        CodigoClube = new CodigoClube(codClube);
        Active = true;
    }
    
    public void MarkAsInative()
    {
        if (!Active)
        {
            throw new BusinessRuleValidationException("O Documento de Identificação já está inativa!");
        }

        Active = false;
    }

    public void MarkAsAtive()
    {
        if (Active)
        {
            throw new BusinessRuleValidationException("O Documento de Identificação já está ativa!");
        }

        Active = true;
    }

    public void ChangeCodClube(int codClube)
    {
        CodigoClube = new CodigoClube(codClube);
    }
    
    public void ChangeEstadoAprovado()
    {
        Active = true;
    }
    
 
}
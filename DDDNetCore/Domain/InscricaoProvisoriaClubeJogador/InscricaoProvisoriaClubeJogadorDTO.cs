using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;
using ConsoleApp1.Domain.Jogador;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;

public class InscricaoProvisoriaClubeJogadorDTO
{
    public Guid Id { get; set; }
    public int CodOperacao { get; set; }
    public Licenca Licenca { get; set; }
    public int CodigoClube { get; set; }

    public string Status { get; set; }

    public InscricaoProvisoriaClubeJogadorDTO(Guid id, int codOperacao, int codigoClube,string status)
    {
        Id = id;
        CodOperacao = codOperacao;
        Licenca = new Licenca();
        CodigoClube = codigoClube;
        Status = status;
    }
    
    public InscricaoProvisoriaClubeJogadorDTO(Guid id, int codOperacao, int codigoClube,int licenca,string status)
    {
        Id = id;
        CodOperacao = codOperacao;
        Licenca = new Licenca(licenca.ToString());
        CodigoClube = codigoClube;
        Status = status;
    }
}
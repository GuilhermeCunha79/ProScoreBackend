using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;
using ConsoleApp1.Domain.Jogador;

namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;

public class InscricaoProvisoriaClubeJogadorDTO
{
    public Guid Id { get; set; }
    public int CodOperacao { get; set; }
    public int Licenca { get; set; }
    public int CodigoClube { get; set; }

    public string Status { get; set; }


    
    public InscricaoProvisoriaClubeJogadorDTO(Guid id, int codOperacao, int codigoClube,int licenca,string status)
    {
        Id = id;
        CodOperacao = codOperacao;
        Licenca =licenca;
        CodigoClube = codigoClube;
        Status = status;
    }
}
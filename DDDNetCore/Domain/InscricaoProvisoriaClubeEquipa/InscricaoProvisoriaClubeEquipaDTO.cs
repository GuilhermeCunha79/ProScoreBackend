namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;

public class InscricaoProvisoriaClubeEquipaDTO
{
    public Guid Id { get; set; }
    public int CodOperacao { get; set; }
    public int IdentificadorEquipa { get; set; }
    public int CodigoClube { get; set; }

    public InscricaoProvisoriaClubeEquipaDTO(Guid id, int codOperacao, int identificadorEquipa, int codClube)
    {
        Id = id;
        CodOperacao = codOperacao;
        IdentificadorEquipa = identificadorEquipa;
        CodigoClube = codClube;
    }
}
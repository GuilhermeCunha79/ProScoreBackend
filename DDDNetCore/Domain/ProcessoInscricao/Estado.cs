namespace ConsoleApp1.Domain.ProcessoInscricao;

public class Estado
{

    public string Status { get; set; }
    

    public Estado()
    {
        Status = "AGUARDAR_APROVACAO_ASSOCIACAO";
    }
    
    public Estado(string estado)
    {
        Status = estado;
    }
    /*APROVADO,
    REPROVADO,
    AGUARDAR_APROVACAO_ASSOCIACAO*/
}
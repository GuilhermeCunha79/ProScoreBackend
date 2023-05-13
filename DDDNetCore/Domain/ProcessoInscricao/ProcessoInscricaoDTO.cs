namespace ConsoleApp1.Domain.ProcessoInscricao;

public class ProcessoInscricaoDTO
{
    public Guid Id;

    public CodOperacao CodOperacao { get; set; }

    public string TipoProcesso { get; set; }
    public Estado Estado { get; set; }
    public string EpocaDesportiva { get; set; }
    public DataRegisto DataRegisto { get; set; }
    public DataSubscricao DataSubscricao { get; set; }

    public ProcessoInscricaoDTO(Guid id, string tipoProcesso, string epocaDesportiva)
    {
        Id = id;
        CodOperacao = new CodOperacao();
        TipoProcesso = tipoProcesso;
        Estado = new Estado();
        EpocaDesportiva = epocaDesportiva;
        DataRegisto = new DataRegisto();
        DataSubscricao = new DataSubscricao();
    }

   
}
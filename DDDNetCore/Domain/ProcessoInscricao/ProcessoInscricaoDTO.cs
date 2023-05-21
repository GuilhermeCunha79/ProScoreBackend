using Newtonsoft.Json;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class ProcessoInscricaoDTO
{
    public Guid Id;

    public string CodOperacao { get; set; }

    public string TipoProcesso { get; set; }
    public string Estado { get; set; }
    public string EpocaDesportiva { get; set; }
    public string DataRegisto { get; set; }
    public string DataSubscricao { get; set; }


    public ProcessoInscricaoDTO(Guid id,string codOperacao, string status, string dataRegisto, string dataSubs, string tipoProcesso, string epocaDesportiva)
    {
        Id = id;
        CodOperacao = codOperacao;
        TipoProcesso = tipoProcesso;
        Estado = status;
        EpocaDesportiva = epocaDesportiva;
        DataRegisto = dataRegisto;
        DataSubscricao = dataSubs;
    }

   
}
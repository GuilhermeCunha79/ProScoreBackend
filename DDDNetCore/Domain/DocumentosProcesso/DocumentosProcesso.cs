using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentosProcesso;

public class DocumentosProcesso : Entity<Identifier>
{

    public CapturaDocIdentificacao CapturaDocIdentificacao { get; set; }
    public CapturaBoletim CapturaBoletim { get; set; }
    

    public CodOperacao CodOperacao { get; set; }

    public ProcessoInscricao.ProcessoInscricao ProcessoInscricao { get; set; }


    public DocumentosProcesso()
    {
        
    }
    
    public DocumentosProcesso(string capturaBoletim, string capturaDocId, string codOperacao)
    {
        Id = new Identifier(Guid.NewGuid());
        CapturaBoletim = new CapturaBoletim(capturaBoletim);
        CapturaDocIdentificacao = new CapturaDocIdentificacao(capturaDocId);
        CodOperacao = new CodOperacao(codOperacao);
    }
    

}
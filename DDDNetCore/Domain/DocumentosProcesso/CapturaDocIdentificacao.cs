using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentosProcesso;

public class CapturaDocIdentificacao : IValueObject
{

    public string DocIdentificacaoCaptura { get; set; }

    
    public CapturaDocIdentificacao()
    {
        
    }
    public CapturaDocIdentificacao(string dados)
    {
        DocIdentificacaoCaptura = dados;
    }
}
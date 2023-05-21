using System.Net.Mime;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentosProcesso;

public class CapturaBoletim : IValueObject
{

    public string BoletimCaptura { get; set; }


    public CapturaBoletim()
    {
        
    }
    public CapturaBoletim(string dados)
    {
        BoletimCaptura = dados;
    }
}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class DataRegisto: IValueObject
{
    public string DataReg { get; set; }
    
    
    public DataRegisto()
    {
        DataReg = "A AGUARDAR APROVAÇÃO DA ASSOCIAÇÃO";
    }
    
    public DataRegisto(string data)
    {
        DataReg =data;
    }
}
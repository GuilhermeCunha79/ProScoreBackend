using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class DataRegisto: IValueObject
{
    public string DataReg { get; set; }
    
    DateTime today = DateTime.Today;

    public DataRegisto()
    {
        DataReg = today.ToShortDateString();
    }
}
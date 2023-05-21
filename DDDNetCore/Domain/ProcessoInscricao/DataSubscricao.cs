using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class DataSubscricao: IValueObject
{
    public string DataSubs { get; set; }
    
    DateTime today = DateTime.Today;

    public DataSubscricao()
    {
        DataSubs = today.ToShortDateString();
    }
    
    public DataSubscricao(string dataSubs)
    {
        DataSubs = dataSubs;
    }
}
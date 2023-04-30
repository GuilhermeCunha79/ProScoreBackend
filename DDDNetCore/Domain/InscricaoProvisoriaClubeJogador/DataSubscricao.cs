using ConsoleApp1.Shared;

namespace ConsoleApp1.InscricaoProvisoriaClubeJogador;

public class DataSubscricao: IValueObject
{
    public string DataSubs { get; set; }
    
    DateTime today = DateTime.Today;

    public DataSubscricao()
    {
        DataSubs = today.ToShortDateString();
    }
}
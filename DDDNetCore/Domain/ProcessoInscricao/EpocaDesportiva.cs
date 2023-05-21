using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class EpocaDesportiva: IValueObject
{

    public string EpocaDesp { get; set; }

    public EpocaDesportiva()
    {
        EpocaDesp = string.Concat(getYear(),"/",getYearPlusOne());
    }
    
    public string getYear()
    {
        return DateTime.Today.Year.ToString();
    }
    
    public string getYearPlusOne()
    {
        int year= DateTime.Today.Year+1;
        return year.ToString();
    }


    public override string ToString()
    {
        return EpocaDesp;
    }
}



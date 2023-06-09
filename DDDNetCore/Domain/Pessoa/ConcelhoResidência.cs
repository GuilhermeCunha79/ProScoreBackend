using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public class ConcelhoResidência: IValueObject
{
    public string Concelho { get; set; }


    public ConcelhoResidência()
    {
        Concelho = "";
    }
    public ConcelhoResidência(string? concelho)
    {
        Concelho = concelho ?? " ";
    }
}
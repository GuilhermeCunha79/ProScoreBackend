using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class ConcelhoResidência: IValueObject
{
    public string Concelho { get; set; }

 

    public ConcelhoResidência(string? concelho)
    {
        Concelho = concelho ?? " ";
    }
}
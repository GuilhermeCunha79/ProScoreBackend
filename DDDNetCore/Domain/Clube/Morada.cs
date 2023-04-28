using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Morada: IValueObject
{
    public string? Morad { get; set; }
    

    public Morada(string? morada)
    {
        Morad = validateMorada(morada) != null ? morada : " ";
    }

    public string validateMorada(string morada)
    {
        return SharedMethods.onlyLettersAndSpace(morada);
    }

}
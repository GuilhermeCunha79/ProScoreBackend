using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class Morada: IValueObject
{
    public string? Morad { get; set; }

    public Morada()
    {
        
    }
    public Morada(string? morada)
    {
        Morad = validateMorada(morada) != null ? morada : " ";
    }

    public string validateMorada(string morada)
    {
        return SharedMethods.onlyLettersAndSpace(morada);
    }

}
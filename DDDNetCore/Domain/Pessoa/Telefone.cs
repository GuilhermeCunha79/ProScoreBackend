using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public class Telefone: IValueObject
{
    public string Telemovel { get; set; }


    public Telefone()
    {
        Telemovel = "---------";
    }
public Telefone(string tele)
    {
        Telemovel = validateTelemovel(tele);
    }


    private string validateTelemovel(string telemovel)
    {
        if (SharedMethods.onlyNumbers(telemovel).ToString().Length != 0 &
            SharedMethods.onlyNumbers(telemovel).ToString().Length != 9)
        {
            throw new BusinessRuleValidationException("Verfique o preenchimento do campo referente ao 'Telefone'!");
        }
        return SharedMethods.onlyNumbers(telemovel).ToString();
    }

    public override string ToString()
    {
        return Telemovel;
    }
}
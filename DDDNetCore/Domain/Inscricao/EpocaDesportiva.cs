using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class EpocaDesportiva: IValueObject
{

    public string Epoca { get; set; }

    public EpocaDesportiva(string epoca)
    {
        Epoca = formatEpoca(epoca);
    }

    private string formatEpoca(string epoca)
    {
        if (epoca == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente à 'Época Desportiva'!");
        }

        return SharedMethods.onlyNumbersAndSeparator(epoca);
    }


    public override string ToString()
    {
        return SharedMethods.onlyNumbersAndSeparator(Epoca);
    }
}



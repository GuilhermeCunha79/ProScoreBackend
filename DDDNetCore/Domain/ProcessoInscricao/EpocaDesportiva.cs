using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class EpocaDesportiva: IValueObject
{

    public string EpocaDesp { get; set; }

    public EpocaDesportiva(string epoca)
    {
        EpocaDesp = formatEpoca(epoca);
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
        return EpocaDesp;
    }
}



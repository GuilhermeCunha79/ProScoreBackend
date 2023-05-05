using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public class CheckDigit : IValueObject
{
    public int CheckDig { get; set; }

    public CheckDigit()
    {
        
    }
    public CheckDigit(string check)
    {
        CheckDig = validateCheck(check);
    }
    
    private int validateCheck(string check)
    {
        int number = SharedMethods.onlyNumbers(check);
        if (check == null )
        {
            throw new BusinessRuleValidationException(
                "Preencha o campo referente ao 'Check Digit do nº de Identificação Civil'!");
        } if (number.ToString().Length > 1)
        {
            throw new BusinessRuleValidationException(
                "O campo do 'Check Digit do nº de Identificação Civil' só deve apresentar um caratér numérico!");
        }
        return number;
    }
}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public class Nif: IValueObject
{
    public string NumIdFis{ get; set; }
    

    public Nif(string? numIdFis)
    {
        NumIdFis = validateNumIdFis(numIdFis) != null ? numIdFis:"";
    }
    
    private string validateNumIdFis(string nrId)
    {
        int nr = SharedMethods.onlyNumbers(nrId);

        if (nr.ToString().Length != 9)
        {
            throw new BusinessRuleValidationException(
                "O 'Números de Identificação Fiscal' deve ter exatamente 9 digitos!");
        }

        return nr.ToString();
    }
}
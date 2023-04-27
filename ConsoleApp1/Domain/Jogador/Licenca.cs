using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Licenca
{
    public int Lic { get; set; }

    public Licenca(string licenca)
    {
        Lic = validateLicenca(licenca);
    }

    private int validateLicenca(string licenca)
    {
        if (licenca == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Número de Licença da FPF'!");
        }

        return SharedMethods.onlyNumbers(licenca);
    }

    public override string ToString()
    {
        return Lic.ToString();
    }
}
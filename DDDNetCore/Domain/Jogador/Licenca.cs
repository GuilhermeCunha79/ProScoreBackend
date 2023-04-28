using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Licenca
{
    public string Lic { get; set; }
    public int nr;
    

    public Licenca(string licenca)
    {
        Lic = validateLicenca(licenca);
    }

    public Licenca()
    {
        Lic = (nr++).ToString();
    }
    
    private string validateLicenca(string licenca)
    {
        if (licenca == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Número de Licença da FPF'!");
        }

        return SharedMethods.onlyNumbers(licenca).ToString();
    }

    public override string ToString()
    {
        return Lic;
    }
}
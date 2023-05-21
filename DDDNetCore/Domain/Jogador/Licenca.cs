using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Domain.Jogador;

public class Licenca: IValueObject
{
    public int Lic { get; set; }

    
    public Licenca()
    {
        
    }
    
    public Licenca(string lic)
    {
        Lic = validateLicenca(lic);
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
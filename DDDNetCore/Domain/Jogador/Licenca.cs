using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Jogador;

public class Licenca: IValueObject
{
    public int Lic { get; set; }

    public Licenca()
    {
        var options = SharedMethods.connection();
        using (var context = new DDDSample1DbContext(options))
        {
            var numeroDeTipos = context.ObterNumeroDeJogadores()+1;
            Lic += numeroDeTipos;
        }
    }

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
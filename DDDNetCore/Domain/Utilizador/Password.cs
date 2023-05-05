using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Utilizador;

public class Password:IValueObject
{

    public string Pass { get; set; }

    public Password(string pass)
    {
        Pass = validatePassword(pass);
    }

    public string validatePassword(string pass)
    {
        if (pass == null)
        {
            throw new BusinessRuleValidationException("Deve preencher o campo da 'Password'!");
        }

        return pass;
    }
}
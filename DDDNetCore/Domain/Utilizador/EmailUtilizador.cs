using System.Text.RegularExpressions;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Utilizador;

public class EmailUtilizador:IValueObject
{

    public string Email { get; set; }

    public EmailUtilizador()
    {
    }

    public EmailUtilizador(string email)
    {
        Email = validateEmail(email);
    }

    public string validateEmail(string email)
    {
        if (email == null)
        {
            throw new BusinessRuleValidationException("O campo referente ao 'Email' deve ser preenchido");
        }

        if (SharedMethods.IsValidEmail(email))
        {
            return email;
        }

        return null;
    }
    
   

}
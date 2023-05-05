using System.Net.Mail;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public class Email: IValueObject
{
    public string? Emaill { get; set; }

    public Email()
    {
        
    }
    public Email(string? email)
    {
        Emaill = validateEmail(email)!= null ? email:" ";
    }
    
    private string validateEmail(string? email)
    {
        try
        {
            var mailAdd = new MailAddress(email);
            return mailAdd.ToString().Trim();
        }
        catch
        {
            throw new BusinessRuleValidationException("Verfique o preenchimento do campo referente ao 'Email', caso se aplique ao modelo em questão!");
        }
    }

    public override string? ToString()
    {
        return Emaill;
    }
}
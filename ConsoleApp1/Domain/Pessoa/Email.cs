using System.Net.Mail;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Email: IValueObject
{
    public string Emaill { get; set; }

    public Email(string? email)
    {
        Emaill = validateEmail(email)!= null ? email:" ";
    }

    //VERIFICAR////////////////////////////////////////////////////////////
    private string validateEmail(string email)
    {
        string email1 = " ";
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

    public override string ToString()
    {
        return Emaill;
    }
}
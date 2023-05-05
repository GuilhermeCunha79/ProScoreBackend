using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class TelefoneClube:IValueObject
{
    public string TelefoneClub { get; set; }

    public TelefoneClube()
    {
        
    }
    public TelefoneClube(string? telefone)
    {
        if (telefone != null)
        {
            TelefoneClub = validateTelefone(telefone);
        }
        else
        {
            TelefoneClub = " ";
        }
    }

    public string validateTelefone(string telefone)
    {

        if (telefone.Length != 9)
        {
            throw new BusinessRuleValidationException("O 'Telefone do Clube' deve ter exatamente 9 digitos numéricos!");
        }
        return SharedMethods.onlyNumbers(telefone).ToString();
    }
    
    
}
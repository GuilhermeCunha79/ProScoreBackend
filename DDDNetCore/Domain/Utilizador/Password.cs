using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Utilizador;

public class Password : IValueObject
{
    public string Pass { get; set; }

    
    public Password()
    {
        
    }
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

        if (IsValidPassword(pass))
            return pass;
        
        return pass;
    }

    public bool IsValidPassword(string password)
    {
        // Define as regras de complexidade para validar a senha
        int requiredLength = 8;
        bool requireDigit = true;
        bool requireLowercase = true;
        bool requireUppercase = true;
        bool requireNonAlphanumeric = true;

        // Verifica se a senha atende às regras de complexidade
        bool isValid = password != null && password.Length >= requiredLength &&
                       (requireDigit && password.Any(c => char.IsDigit(c))) &&
                       (requireLowercase && password.Any(c => char.IsLower(c))) &&
                       (requireUppercase && password.Any(c => char.IsUpper(c))) &&
                       (requireNonAlphanumeric && password.Any(c => !char.IsLetterOrDigit(c)));

        return isValid;
    }
}
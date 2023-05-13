using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;

public class NomeCurto : IValueObject
{
    public string NomeCurt { get; set; }

    public NomeCurto()
    {
    }

    public NomeCurto(string nome)
    {
        NomeCurt = validateNomeAss(nome);
    }

    public string validateNomeAss(string nome)
    {
        if (nome == null)
        {
            throw new BusinessRuleValidationException("O 'Nome' da Associação deve ser preenchido!");
        }

        return SharedMethods.onlyLettersAndSpace(nome);
    }

    public override string ToString()
    {
        return NomeCurt;
    }
}
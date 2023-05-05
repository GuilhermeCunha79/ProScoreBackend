using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;

public class NomeAssociacao : IValueObject
{
    public string NomeAss { get; set; }

    public NomeAssociacao()
    {
        
    }
    public NomeAssociacao(string nome)
    {
        NomeAss = validateNomeAss(nome);
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
        return NomeAss;
    }
}
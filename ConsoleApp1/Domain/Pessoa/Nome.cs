using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Nome: IValueObject
{
    public string Nomee { get; set; }

    public Nome(string nome)
    {
        Nomee = validateNome(nome);
    }

    private string validateNome(string nome)
    {
        if (nome == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Nome'!");
        }

        return nome;
    }

    public override string ToString()
    {
        return Nomee;
    }
}
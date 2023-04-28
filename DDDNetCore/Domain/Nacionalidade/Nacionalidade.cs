using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Nacionalidade
{
    public string Nacao { get; set; }
    public int CodNacionalidade { get; set; }

    public Nacionalidade(string nacao, string codNacionalidade)
    {
        Nacao = validateNacao(nacao);
        CodNacionalidade = validateCodNacao(codNacionalidade);
    }

    private string validateNacao(string nacao)
    {
        if (nacao == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente à 'Nacionalidade'!");
        }

        return SharedMethods.onlyLettersAndSpace(nacao);
    }

    private int validateCodNacao(string codNacionalidade)
    {
        if (codNacionalidade == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Código da Nacionalidade'!");
        }

        return SharedMethods.onlyNumbers(codNacionalidade);
    }
}
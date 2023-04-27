using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Escalao
{
    public string Categoria { get; set; }

    public Escalao(string categoria)
    {
        Categoria = validateEscalao(categoria);
    }

    private string validateEscalao(string escalao)
    {
        if (escalao == null)
        {
            throw new BusinessRuleValidationException("Selecione a 'Categoria' à qual pertence!");
        }

        return escalao;
    }

    public override string ToString()
    {
        return Categoria;
    }
}
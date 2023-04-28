using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class CodigoClube: IValueObject
{
    public string CodClube { get; set; }

    public CodigoClube()
    {
        CodClube = new Identifier(Guid.NewGuid()).ToString();
    }
    
    public CodigoClube(string codigo)
    {
        CodClube = validateCod(codigo);
    }

    public string validateCod(string codigo)
    {
        if (codigo == null)
        {
            throw new BusinessRuleValidationException("O 'Código do Clube' deve estar especificado!");
        }

        int result;
        if (!int.TryParse(codigo, out result))
        {
            throw new BusinessRuleValidationException("O 'Código do Clube' deve apenas conter caracteres numéricos!");
        }

        return codigo;
    }
}
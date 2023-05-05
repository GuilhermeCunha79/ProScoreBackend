using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class CodigoClube: IValueObject
{
    public int CodClube { get; set; }

    public CodigoClube()
    {
        var options = SharedMethods.connection();
        using (var context = new DDDSample1DbContext(options))
        {
            var numeroDeTipos = context.ObterNumeroDeClubes()+1;
            CodClube += numeroDeTipos;
        }
    }
    
    public CodigoClube(string codigo)
    {
        CodClube = validateCod(codigo);
    }

    public int validateCod(string codigo)
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

        return SharedMethods.onlyNumbers(codigo);
    }
}
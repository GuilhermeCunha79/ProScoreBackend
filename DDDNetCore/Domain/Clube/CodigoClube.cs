using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class CodigoClube: IValueObject
{
    public int CodClube { get; set; }

   
    
    public CodigoClube(int codigo)
    {
        CodClube = codigo;
    }

  /*  public int validateCod(int codigo)
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
    }*/
}
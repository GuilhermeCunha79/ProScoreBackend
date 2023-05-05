using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Genero;

public class TipoGenero: IValueObject
{

    public string Genero { get; set; }

    public TipoGenero()
    {
        
    }

    public TipoGenero(string genero)
    {
        Genero = validateGenero(genero);
    }
    public string validateGenero(string genero)
    {
        string cat = genero.Trim();
        if (genero == null)
        {
            throw new BusinessRuleValidationException("A 'Categoria' da Equipa deve ser preenchida!");
        }

        if (cat.Equals("MASCULINO", StringComparison.OrdinalIgnoreCase))
        {
            return "Masculino";
        }

        return "Feminino";
    }
}
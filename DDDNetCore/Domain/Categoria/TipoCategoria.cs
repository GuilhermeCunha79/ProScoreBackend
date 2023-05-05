using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Categoria;

public class TipoCategoria : IValueObject
{
    public string Categoria { get; set; }
    public TipoCategoria()
    {
    }

    public TipoCategoria(string categoria)
    {
        Categoria = validateCategoria(categoria);
    }

    public string validateCategoria(string cate)
    {
        string cat = cate.Trim();
        if (cate == null)
        {
            throw new BusinessRuleValidationException("A 'Categoria' da Equipa deve ser preenchida!");
        }

        if (cat.Equals("PETIZ", StringComparison.OrdinalIgnoreCase))
        {
            return "Petiz";
        }

        if (cat.Equals("TRAQUINA", StringComparison.OrdinalIgnoreCase))
        {
            return "Traquina";
        }

        if (cat.Equals("BENJAMIM", StringComparison.OrdinalIgnoreCase))
        {
            return "Benjamim";
        }

        if (cat.Equals("JUNIORD", StringComparison.OrdinalIgnoreCase))
        {
            return "JuniorD";
        }

        if (cat.Equals("JUNIORC", StringComparison.OrdinalIgnoreCase))
        {
            return "JuniorC";
        }

        if (cat.Equals("JUNIORB", StringComparison.OrdinalIgnoreCase))
        {
            return "JuniorB";
        }

        if (cat.Equals("JUNIORA", StringComparison.OrdinalIgnoreCase))
        {
            return "JuniorA";
        }

        return null;
    }
}

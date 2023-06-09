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

        if (cat.Equals("JUNIORD", StringComparison.OrdinalIgnoreCase)| cat.Equals("JÚNIOR D", StringComparison.OrdinalIgnoreCase))
        {
            return "JuniorD";
        }

        if (cat.Equals("JUNIORC", StringComparison.OrdinalIgnoreCase)| cat.Equals("JÚNIOR C", StringComparison.OrdinalIgnoreCase))
        {
            return "JuniorC";
        }

        if (cat.Equals("JUNIORB", StringComparison.OrdinalIgnoreCase)| cat.Equals("JÚNIOR B", StringComparison.OrdinalIgnoreCase))
        {
            return "JuniorB";
        }

        if (cat.Equals("JUNIORA", StringComparison.OrdinalIgnoreCase) | cat.Equals("JÚNIOR A", StringComparison.OrdinalIgnoreCase))
        {
            return "JuniorA";
        }
        
        if (cat.Equals("SENIOR", StringComparison.OrdinalIgnoreCase) | cat.Equals("SÉNIOR", StringComparison.OrdinalIgnoreCase))
        {
            return "Sénior";
        }

        return null;
    }
}

using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Modalidade;

public class TipoModalidade : IValueObject
{
    public string Modalidade { get; set; }

    public TipoModalidade()
    {
    }

    public TipoModalidade(string modalidade)
    {
        Modalidade = validateModalidade(modalidade);
    }

    public string validateModalidade(string modalidade)
    {
        if (modalidade == null)
        {
            throw new BusinessRuleValidationException("A 'Modalidade necessita de ser preenchida!'");
        }

        string cat = modalidade.Trim();


        if (cat.Equals("FUTSAL", StringComparison.OrdinalIgnoreCase))
        {
            return "Futsal";
        }
        
        return "Futebol";
    }
}
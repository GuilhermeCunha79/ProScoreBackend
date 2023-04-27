using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Modalidade : IValueObject
{
    public string Modalidade1 { get; set; }

    public Modalidade(string modalidade1)
    {
        Modalidade1 = ValidateModalidade(modalidade1);
    }

    private string ValidateModalidade(string modalidadde)
    {
        if (modalidadde.ToUpper().Equals("FUTEBOL") || modalidadde.ToUpper().Equals("FUTSAL"))
        {
            return modalidadde;
        }

        throw new BusinessRuleValidationException("Selecione uma modalidade desportiva!");
    }

    public override string ToString()
    {
        return Modalidade1;
    }
}
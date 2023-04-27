using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class NrUtente: IValueObject
{
    public string NumUtente { get; set; }

    public NrUtente(string numUtente)
    {
        NumUtente = validateNumUtente(numUtente);
    }
    
    private string validateNumUtente(string nrId)
    {
        int nr = SharedMethods.onlyNumbers(nrId);
        if (nrId == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente aos 'Números de Utente'!");
        }

        if (nr.ToString().Length != 9)
        {
            throw new BusinessRuleValidationException(
                "O 'Números de Utente' deve ter exatamente 9 digitos!");
        }

        return nr.ToString();
    }
    
}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public class NrIdentificacao: IValueObject
{

    public int NumeroId { get; set; }

    public NrIdentificacao()
    {
        
    }
    public NrIdentificacao(string nrId)
    {
        NumeroId = validateNrIdentificacao(nrId);
    }


    private int validateNrIdentificacao(string nrId)
    {
        int nr = SharedMethods.onlyNumbers(nrId);
        if (nrId == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente aos 'Números do  Documento de Identificação'!");
        }

        if (nr.ToString().Length != 8)
        {
            throw new BusinessRuleValidationException(
                "O número do documento de identificação deve ter exatamente 8 digitos!");
        }

        return nr;
    }
}
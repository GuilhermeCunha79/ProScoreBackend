using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class CodOperacao
{
    public int CodOpe { get; set; }

    public CodOperacao(string codOp)
    {
        CodOpe = validateOperacao(codOp);
    }
    
    private int validateOperacao(string licenca)
    {
        if (licenca == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Número da Operação'!");
        }

        return SharedMethods.onlyNumbers(licenca);
    }

    public override string ToString()
    {
        return CodOpe.ToString();
    }
}
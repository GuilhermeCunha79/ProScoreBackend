using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class CodOperacao: IValueObject
{
    public string CodOpe { get; set; }

    public int nr { get; set; }

    public CodOperacao(string codOp)
    {
        CodOpe = validateOperacao(codOp);
    }
    
    public CodOperacao()
    {
        CodOpe = (nr++).ToString();
    }
    
    private string validateOperacao(string licenca)
    {
        if (licenca == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Número da Operação'!");
        }

        return SharedMethods.onlyNumbers(licenca).ToString();
    }

    public override string ToString()
    {
        return CodOpe;
    }
}
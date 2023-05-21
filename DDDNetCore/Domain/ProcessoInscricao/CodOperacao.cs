using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class CodOperacao: IValueObject
{
    public int CodOpe { get; set; }
   

    public CodOperacao(string codOp)
    {
        CodOpe = validateOperacao(codOp);
    }
    
    public CodOperacao()
    {
     
    }
    
    private int validateOperacao(string licenca)
    {
        if (licenca == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Código da Operação'!");
        }

        return SharedMethods.onlyNumbers(licenca);
    }

    public override string ToString()
    {
        return CodOpe.ToString();
    }
}
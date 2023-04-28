using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class ValidadeDoc: IValueObject
{
    public int Ano { get; set; }
    public int Mes { get; set; }
    public int Dia { get; set; }
    

    public ValidadeDoc()
    {
        Dia = 0;
        Mes = 0;
        Ano = 0;
    }
    
    public ValidadeDoc(string data)
    {
        Ano = GetYear(validateValidadeDoc(data));
        Mes = GetMonth(validateValidadeDoc(data));
        Dia = GetDay(validateValidadeDoc(data));
        
    }

    private string validateValidadeDoc(string data)
    {
        if (data == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo relativo à 'Validade do Documento de Identificação'!");
        }

        return data;
    }

    private int GetDay(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(0 , 2));
    }
   
    private int GetYear(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(date.Length - 4, 4));
    }
   
    private int GetMonth(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(date.Length - 7, 2));
    }

    public override string ToString()
    {
        return Dia + '/' + Mes.ToString() + '/' + Ano;
    }
}
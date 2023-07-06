using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public class ValidadeDoc: IValueObject
{
    public string Data { get; set; }
    

    public ValidadeDoc()
    {
        Data = "xxxxxxx";
    }
    
    public ValidadeDoc(string data)
    {
        Data=String.Concat(GetMonth(validateValidadeDoc(data)),'/',GetDay(validateValidadeDoc(data)),'/',GetYear(validateValidadeDoc(data)));
        
    }

    private string validateValidadeDoc(string data)
    {
        if (data == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo relativo à 'Validade do Documento de Identificação'!");
        }

        return data;
    }

    public static int GetDay(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(0 , 2));
    }
   
    public static int GetYear(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(date.Length - 4, 4));
    }
   
    public static int GetMonth(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(date.Length - 7, 2));
    }

    public override string ToString()
    {
        return Data;
    }
}
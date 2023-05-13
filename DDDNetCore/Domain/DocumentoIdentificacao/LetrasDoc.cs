using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public class LetrasDoc: IValueObject
{
    public string LetrasDocumento { get; set; }

    public LetrasDoc()
    {
        
    }

    public LetrasDoc(string letras)
    {
        LetrasDocumento = checkLetras(letras);
    }

    public string checkLetras(string letras)
    {

        if (letras == null)
        {
            throw new BusinessRuleValidationException("As letras do documento de identificação devem ser preenchidas!");
        }
        
        string let=SharedMethods.onlyLettersAndNumbers(letras).Substring(1,3);
        if (let.Length != 3)
        {
            throw new BusinessRuleValidationException("As letras do documento de identicação devem ser 3 letras!");
        }
        
        
        return let;
    }
}
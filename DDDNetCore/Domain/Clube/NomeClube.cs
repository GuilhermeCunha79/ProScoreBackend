using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Domain.Clube;
[Owned]
public class NomeClube: IValueObject
{

    public string NomeClub { get; set; }

    public NomeClube()
    {
        
    }

    public NomeClube(string nome)
    {
        NomeClub = validateNomeClube(nome);
    }
    
    private string validateNomeClube(string nome)
    {
        if (nome == null)
        {
            throw new BusinessRuleValidationException(
                "Preencha o campo referente ao 'Nome' do clube em que se inscreve!");
        }

        return SharedMethods.onlyLettersAndSpace(nome);
    }

    public override string ToString()
    {
        return NomeClub;
    }
}
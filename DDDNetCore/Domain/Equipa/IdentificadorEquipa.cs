using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Equipa;

public class IdentificadorEquipa: IValueObject
{
    public int IdEquipa { get; set; }

   
    public IdentificadorEquipa(int idEquipa)
    {
        IdEquipa = validateEquipa(idEquipa);
    }

    public int validateEquipa(int id)
    {
        if (id == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Identificador da Equipa'!");
        }

        return id;
    }


}
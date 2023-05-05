using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Equipa;

public class IdentificadorEquipa: IValueObject
{
    public int IdEquipa { get; set; }

    public IdentificadorEquipa()
    {
        var options = SharedMethods.connection();
        using (var context = new DDDSample1DbContext(options))
        {
            var numeroDeTipos = context.ObterNumeroDeEquipas()+1;
            IdEquipa += numeroDeTipos;
        }
    }
    public IdentificadorEquipa(string idEquipa)
    {
        IdEquipa = validateEquipa(idEquipa);
    }

    public int validateEquipa(string id)
    {
        if (id == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Identificador da Equipa'!");
        }

        return SharedMethods.onlyNumbers(id);
    }


}
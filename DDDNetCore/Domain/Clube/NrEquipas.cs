using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class NrEquipas: IValueObject
{
    public int NumeroEquipas { get; set; }

    public NrEquipas()
    {
        var options = SharedMethods.connection();
        using (var context = new DDDSample1DbContext(options))
        {
            var numeroDeTipos = context.ObterNumeroDeEquipas()+1;
            NumeroEquipas += numeroDeTipos;
        }
    }

    public override string ToString()
    {
        return NumeroEquipas.ToString();
    }
}
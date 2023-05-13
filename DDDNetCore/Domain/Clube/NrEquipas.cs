using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class NrEquipas: IValueObject
{
    public int NumeroEquipas { get; set; }

    public NrEquipas()
    {

            NumeroEquipas =1;
        
    }

    public override string ToString()
    {
        return NumeroEquipas.ToString();
    }
}
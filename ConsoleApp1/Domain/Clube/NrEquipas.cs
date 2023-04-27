using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class NrEquipas: IValueObject
{
    public int NumeroEquipas { get; set; }

    public int nr;

    public NrEquipas()
    {
        NumeroEquipas = nr++;
    }

    public override string ToString()
    {
        return NumeroEquipas.ToString();
    }
}
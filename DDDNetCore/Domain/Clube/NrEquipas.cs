using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class NrEquipas: IValueObject
{
    public string NumeroEquipas { get; set; }

    public int nr;

    public NrEquipas()
    {
        NumeroEquipas = (nr++).ToString();
    }

    public override string ToString()
    {
        return NumeroEquipas;
    }
}
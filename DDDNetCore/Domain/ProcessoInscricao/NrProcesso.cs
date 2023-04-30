using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class NrProcesso: IValueObject
{
    public string NrProc { get; set; }

    public int nr;

    public NrProcesso()
    {
        NrProc = (nr++).ToString();
    }

    public override string ToString()
    {
        return NrProc;
    }
}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class CodigoClube
{
    public Identifier CodClube { get; set; }

    public CodigoClube()
    {
        CodClube = new Identifier(Guid.NewGuid());
    }
}
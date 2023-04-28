using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Clube: Entity<Identifier>
{
    public NomeClube NomeClube { get; set; }
    public CodigoClube CodClube { get; set; }
    public Morada Morada { get; set; }
    public TelefoneClube TelefoneClube { get; set; }
    public NrEquipas NrEquipas { get; set; }
    public NifClube NifClube { get; set; }

    public Clube(string nomeClube, string nifClube, string? morada, string telefoneClube)
    {
        Id = new Identifier(Guid.NewGuid());
        CodClube = new CodigoClube();
        NomeClube = new NomeClube(nomeClube);
        Morada = new Morada(morada);
        NrEquipas = new NrEquipas();
        TelefoneClube = new TelefoneClube(telefoneClube);
        NifClube = new NifClube(nifClube);
    }

    
}
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class BoletimInscricaoPath:IValueObject
{
    public string BoletimPath { get; set; }

    public BoletimInscricaoPath(string path)
    {
        BoletimPath = path;
    }
}
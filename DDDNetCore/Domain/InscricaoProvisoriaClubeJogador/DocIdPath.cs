using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class DocIdPath:IValueObject
{
    public string DocPath { get; set; }

    public DocIdPath(string path)
    {
        DocPath = path;
    }
}
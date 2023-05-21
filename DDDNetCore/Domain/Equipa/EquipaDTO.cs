
using Newtonsoft.Json;

namespace ConsoleApp1.Domain.Equipa;

public class EquipaDTO
{
    public Guid Id { get; set; }
    public int IdentificadorEquipa { get; set; }
    public string Divisao { get; set; }
    public int CodigoClube { get; set; }
    public string Categoria { get; set; }
    public string Genero { get; set; }
    public string Modalidade { get; set; }
    public bool Status { get; set; }
    [JsonConstructor]
    public EquipaDTO(Guid idd,int id,string divisao, int codClube, string categoria, string genero, string modalidade)
    {
        Id = idd;
        IdentificadorEquipa = id;
        Divisao = divisao;
        CodigoClube = codClube;
        Categoria = categoria;
        Genero = genero;
        Modalidade = modalidade;
        Status = true;
    }

   
    
}
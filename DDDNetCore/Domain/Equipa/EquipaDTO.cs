namespace ConsoleApp1.Domain.Equipa;

public class EquipaDTO
{
    public Guid Id{ get; set; }
    public IdentificadorEquipa IdentificadorEquipa{ get; set; }
    public string Divisao{ get; set; }
    public string CodigoClube{ get; set; }
    public string Categoria{ get; set; }
    public string Genero{ get; set; }
    public string Modalidade{ get; set; }
    public bool Status{ get; set; }

    public EquipaDTO(Guid guid, IdentificadorEquipa idEquipa, string divisao, string codClube, string categoria,
        string genero,
        string modalidade)
    {
        Id = guid;
        IdentificadorEquipa = idEquipa;
        Divisao = divisao;
        CodigoClube = codClube;
        Categoria = categoria;
        Genero = genero;
        Modalidade = modalidade;
        Status = true;
    }
}
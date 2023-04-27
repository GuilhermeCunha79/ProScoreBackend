using ConsoleApp1.Domain.Genero;
using ConsoleApp1.Domain.Pais;
using ConsoleApp1.Shared;


namespace ConsoleApp1.Domain.Forms;

public class Pessoa : Entity<Identifier>
{

    public Identifier Id { get; set; }
    public Nome Nome { get; set; }
    public DataNascimento DataNascimento{ get; set; }
    public Telefone Telefone { get; set; }
    public Email Email { get; set; }
    public ConcelhoResidência ConcelhoResidência { get; set; }
    public TipoGenero Genero { get; set; }
    public NrIdentificacao NrIdentificacao { get; set; }
    public NomePais NomePais { get; set; }
    public NacionalidadePais NacionalidadePais{ get; set; }


    public Pessoa(string nome, string dataNascimento, string? telefone, string? email, string? concelhoResidencia,
        string genero, string docId, string paisNascenca, string nacionalidade)
    {
        Id = new Identifier(Guid.NewGuid());
        Nome = new Nome(nome);
        DataNascimento = new DataNascimento(dataNascimento);
        Telefone = new Telefone(telefone);
        Email = new Email(email);
        ConcelhoResidência = new ConcelhoResidência(concelhoResidencia);
        Genero = (TipoGenero)Enum.Parse(typeof(TipoGenero), genero);
        NrIdentificacao = new NrIdentificacao(docId);
        NomePais = new NomePais(paisNascenca);
        NacionalidadePais = new NacionalidadePais(nacionalidade);
    }
}
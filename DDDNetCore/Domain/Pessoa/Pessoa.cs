using System.Data;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.Genero;
using ConsoleApp1.Domain.Nacionalidade;
using ConsoleApp1.Domain.PaisNascenca;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public class Pessoa : Entity<Identifier>, IAggregateRoot
{
    public Nome Nome { get; set; }
    public DataNascimento DataNascimento { get; set; }
    public Telefone Telefone { get; set; }
    public Email Email { get; set; }
    public ConcelhoResidência ConcelhoResidência { get; set; }
    public TipoGenero TipoGenero { get; set; }
    public NrIdentificacao NrIdentificacao { get; set; }
    public NascencaPais NascencaPais { get; set; }
    public NacionalidadePais NacionalidadePais { get; set; }
    public Jogador.Jogador Jogador { get; set; }
    public Genero.Genero Genero { get; set; }
    public bool Active { get; set; }
    public IdentificadorPessoa IdentificadorPessoa { get; set; }

    public DocIdentificacao DocIdentificacao { get; set; }
    public Nacionalidade.Nacionalidade Nacionalidade { get; set; }
    public PaisNascenca.PaisNascenca PaisNascenca { get; set; }


    public Pessoa()
    {
    }

    public Pessoa(string nome,int idPessoa, string dataNascimento, string? telefone, string? email, string? concelhoResidencia,
        string genero, string docId, string paisNascenca, string nacionalidade)
    {
        Id = new Identifier(Guid.NewGuid());
        IdentificadorPessoa = new IdentificadorPessoa(idPessoa);
        Nome = new Nome(nome);
        DataNascimento = new DataNascimento(dataNascimento);
        Telefone = new Telefone(telefone);
        Email = new Email(email);
        ConcelhoResidência = new ConcelhoResidência(concelhoResidencia);
        TipoGenero = new TipoGenero(genero);
        NrIdentificacao = new NrIdentificacao(docId);
        NascencaPais = new NascencaPais(paisNascenca);
        NacionalidadePais = new NacionalidadePais(nacionalidade);
        Active = false;
    }

    public Pessoa(string nome,int idPessoa, string dataNascimento, string genero, string email, string docId, string paisNascenca,
        string nacionalidade)
    {
        Id = new Identifier(Guid.NewGuid());
        IdentificadorPessoa = new IdentificadorPessoa(idPessoa);
        Nome = new Nome(nome);
        DataNascimento = new DataNascimento(dataNascimento);
        TipoGenero = new TipoGenero(genero);
        Email = new Email(email);
        NrIdentificacao = new NrIdentificacao(docId);
        NascencaPais = new NascencaPais(paisNascenca);
        NacionalidadePais = new NacionalidadePais(nacionalidade);
        Active = false;
    }

    public void ChangeNome(string nome)
    {
        if (nome == null)
        {
            throw new NoNullAllowedException("O 'Nome' necessita de ser preenchido!");
        }

        Nome = new Nome(nome);
    }

    public void ChangeDataNascimento(string data)
    {
        if (data == null)
        {
            throw new NoNullAllowedException("A 'Data de Nascimento' necessita de ser preenchida!");
        }

        DataNascimento = new DataNascimento(data);
    }

    public void ChangeTelefone(string? telefone)
    {
        Telefone = new Telefone(telefone);
    }

    public void ChangeEmail(string? email)
    {
        Email = new Email(email);
    }

    public void ChangeConcelhoResidencia(string concelho)
    {
        ConcelhoResidência = new ConcelhoResidência(concelho);
    }

    public void MarkAsInative()
    {
        if (!Active)
        {
            throw new BusinessRuleValidationException("O 'Jogador' já está inativo!");
        }

        Active = false;
    }

    public void MarkAsAtive()
    {
        if (Active)
        {
            throw new BusinessRuleValidationException("O 'Jogador' já está ativo!");
        }

        Active = true;
    }
}
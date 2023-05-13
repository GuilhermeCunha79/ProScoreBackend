namespace ConsoleApp1.Domain.Pessoa;

public class PessoaDTO
{
    public Guid Id;
    public int IdentificadorPessoa;
    public string Nome;
    public string DataNascimento;
    public string TipoGenero;
    public string Email;
    public string NrIdentificacao;
    public string NascencaPais;
    public string NacionalidadePais;
    public bool Status;

    public PessoaDTO(Guid id, int identificadorPessoa, string nome, string dataNascimento,
        string tipoGenero,string email, string nrIdentificacao, string nascencaPais,string nacionalidadePais)
    {
        Id = id;
        IdentificadorPessoa = identificadorPessoa;
        Nome = nome;
        DataNascimento = dataNascimento;
        TipoGenero=tipoGenero;
        Email = email;
        NrIdentificacao = nrIdentificacao;
        NascencaPais = nascencaPais;
        NacionalidadePais = nacionalidadePais;
        Status = true;

    }

}
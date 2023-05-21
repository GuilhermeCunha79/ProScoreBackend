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
    public string Telefone;
    public string ConcelhoResidencia;
    public string NascencaPais;
    public string NacionalidadePais;
    public string Status;

    public PessoaDTO(Guid id, int identificadorPessoa, string nome, string dataNascimento,
        string tipoGenero,string email, string nrIdentificacao, string nascencaPais,string nacionalidadePais,string boool,string telefone,string concelho)
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
        Status = boool;
        Telefone = telefone;
        ConcelhoResidencia = concelho;

    }


}
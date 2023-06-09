namespace ConsoleApp1.Domain.VisualizacaoCriacaoPessoa;

public class PessoaVisualizacaoDTO
{
    public string Nome { get; set; }
    public string TipoDoc { get; set; }
    public string NrIdentificacao { get; set; }
    public string CodClube { get; set; }
    public string NomeClube{ get; set; }
    public string NomeAssociacao{ get; set; }
    public string Modalidade { get; set; }
    public string Divisao { get; set; }
    public string Categoria { get; set; }
    public string CheckDigit{ get; set; }
    public string ValidadeDocId { get; set; }
    public string Nif { get; set; }
    public string Sexo { get; set; }
    public string DataNascimento { get; set; }
    public string PaisNascenca { get; set; }
    public string Nacionalidade { get; set; }
    public string ConcelhoResidencia { get; set; }
    public string EstatutoFpF { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    
    public string NrUtente { get; set; }

    public PessoaVisualizacaoDTO(string nome, string tipoDoc, string nrIdentificacao,string checkDigit,string validadeDocId,string estatuto, string nif, string sexo,
        string dataNasc, string paisNascenca,
        string nacionalidade, string concelhoResidencia, string telefone, string email,string numUtente,
        string codClube,string nomeAssociacao,string nomeClube,string modalidade,string divisao,string categoria)
    {
        Nome = nome;
        TipoDoc = tipoDoc;
        NrIdentificacao = nrIdentificacao;
        CheckDigit = checkDigit;
        ValidadeDocId = validadeDocId;
        Nif = nif;
        EstatutoFpF = estatuto;
        Sexo = sexo;
        DataNascimento = dataNasc;
        PaisNascenca = paisNascenca;
        Nacionalidade = nacionalidade;
        ConcelhoResidencia = concelhoResidencia;
        NrUtente = numUtente;
        Telefone = telefone;
        Email = email;
        
        CodClube = codClube;
        NomeClube = nomeClube;
        NomeAssociacao =nomeAssociacao ;
        Modalidade =modalidade ;
        Divisao = divisao;
        Categoria = categoria;
    }
    
   
}
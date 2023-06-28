namespace ConsoleApp1.Domain.JogadorVisualizacao;

public class JogadorVisualizacaoDTO
{
    public string Nome { get; set; }
    public string Licenca { get; set; }
    public string NrId { get; set; }
    public string DataNasc { get; set; }
    public string Sexo { get; set; }
    public string Nacionalidade { get; set; }
    public string PaisNascenca { get; set; }
    public string Estatuto { get; set; }

    public JogadorVisualizacaoDTO(string nome,string licenca, string nrId, string dataNasc, string sexo, string nacionalidade,
        string paisNascenca, string estatuto)
    {
        Nome = nome;
        Licenca = licenca;
        NrId = nrId;
        DataNasc = dataNasc;
        Sexo = sexo;
        Nacionalidade = nacionalidade;
        PaisNascenca = paisNascenca;
        Estatuto = estatuto;
    }
    


}
namespace ConsoleApp1.Domain.VisualizacaoJogador;

public class ProcessoJogadorVisualizacaoDTO
{
    public string Nprocesso { get; set; }
    public string Nome { get; set; }
    public string Licenca { get; set; }
    public string NomeProcesso { get; set; }
    public string Clube { get; set; }
    public string TipoFutebol { get; set; }
    public string Categoria { get; set; }
    public string Divisao { get; set; }
    public string Classe { get; set; }
    public string DataSubs { get; set; }
    public string DataRegisto { get; set; }
    public string Estado { get; set; }

    public ProcessoJogadorVisualizacaoDTO(string nprocesso, string nome, string licenca, string nomeProcesso, string clube,
        string tipoFutebol,
        string categoria, string divisao, string classe, string dataSubs, string dataRegisto, string estado)
    {
        Nprocesso = nprocesso;
        Nome = nome;
        Licenca = licenca;
        NomeProcesso = nomeProcesso;
        Clube = clube;
        TipoFutebol = tipoFutebol;
        Categoria = categoria;
        Divisao = divisao;
        Classe = classe;
        DataSubs = dataSubs;
        DataRegisto = dataRegisto;
        Estado = estado;
    }
}
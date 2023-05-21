namespace ConsoleApp1.Domain.DocumentosProcesso;

public class DocumentosProcessoDTO
{

    public string CaminhoBoletim { get; set; }

    public string CaminhoDocidentificacao { get; set; }

    public Guid Id { get; set; }

    public string CodOperacao { get; set; }

    public DocumentosProcessoDTO(Guid id, string caminhoBoletim, string caminhoDocidentificacao, string codOperacao)
    {
        Id = id;
        CaminhoBoletim = caminhoBoletim;
        CaminhoDocidentificacao = caminhoDocidentificacao;
        CodOperacao = codOperacao;
    }
}
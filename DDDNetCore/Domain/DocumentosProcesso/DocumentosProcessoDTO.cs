namespace ConsoleApp1.Domain.DocumentosProcesso;

public class DocumentosProcessoDTO
{

    public string CaminhoBoletim { get; set; }

    public string CaminhoDocIdentificacao { get; set; }

    public Guid Id { get; set; }

    public string CodOperacao { get; set; }

    public DocumentosProcessoDTO(Guid id, string caminhoBoletim, string caminhoDocIdentificacao, string codOperacao)
    {
        Id = id;
        CaminhoBoletim = caminhoBoletim;
        CaminhoDocIdentificacao = caminhoDocIdentificacao;
        CodOperacao = codOperacao;
    }
}
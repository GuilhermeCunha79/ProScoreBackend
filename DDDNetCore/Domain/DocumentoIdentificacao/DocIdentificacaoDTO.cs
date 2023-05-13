namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public class DocIdentificacaoDTO
{
    public Guid Id;

    public string NrIdentificacao { get; set; }
    public string LetrasDoc { get; set; }
    public string CheckDigit { get; set; }
    public string ValidadeDoc { get; set; }
    public string Nif { get; set; }
    public string NrUtente { get; set; }
    public string Status { get; set; }

    public DocIdentificacaoDTO(Guid id, string nrId, string letras, string check, string validadeDoc, string nif,string nrUtente,string status)
    {
        Id = id;
        NrIdentificacao = nrId;
        LetrasDoc = letras;
        CheckDigit = check;
        ValidadeDoc = validadeDoc;
        Nif = nif;
        NrUtente = nrUtente;
        Status = status;
    }
    
  
}
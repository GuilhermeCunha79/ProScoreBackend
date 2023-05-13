namespace ConsoleApp1.Domain.Associacao;

public class AssociacaoDTO
{
    public Guid Id;
    public string NomeAssociacao { get;set; }
  //  public string NomeCurto { get;set; }

    public AssociacaoDTO(Guid id,string nome)
    {
        Id = id;
        NomeAssociacao = nome;
       // NomeCurto = nomeCurto;
    }
}
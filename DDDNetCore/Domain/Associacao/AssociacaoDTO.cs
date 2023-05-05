namespace ConsoleApp1.Domain.Associacao;

public class AssociacaoDTO
{
    public Guid Id;
    public string NomeAsscoicao { get;set; }

    public AssociacaoDTO(Guid id,string nome)
    {
        Id = id;
        NomeAsscoicao = nome;
    }
}
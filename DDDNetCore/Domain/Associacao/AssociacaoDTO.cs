namespace ConsoleApp1.Domain.Associacao;

public class AssociacaoDTO
{
    public Guid Id;
    public string NomeAssociacao { get;set; }
    public string NomeCurto { get;set; }

    public string Acronimo { get; set; }

    public AssociacaoDTO(Guid id,string nome,string nomeCurto,string acronimo)
    {
        Id = id;
        NomeAssociacao = nome;
        NomeCurto = nomeCurto;
        Acronimo = acronimo;
    }
}
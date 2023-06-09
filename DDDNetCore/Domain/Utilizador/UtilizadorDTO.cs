using ConsoleApp1.Domain.Pessoa;

namespace ConsoleApp1.Domain.Utilizador;

public class UtilizadorDTO
{
    public Guid Id;
    public string EmailUtilizador { get; set; }
    public int Role { get; set; }
    public string Password { get; set; }
    
    public int CodigoClube { get; set; }
    public string NomeAssociacao { get; set; }

    public UtilizadorDTO(Guid id,string email, int role, string password, string? nomeAssociacao,int codClube)
    {
        Id = id;
        EmailUtilizador = email;
        Role = role;
        Password = password;
        NomeAssociacao = nomeAssociacao;
        CodigoClube = codClube;

    }
    
}
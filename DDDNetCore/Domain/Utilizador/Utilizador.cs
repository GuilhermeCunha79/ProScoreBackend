using System.ComponentModel.Design;
using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Utilizador;

public class Utilizador : Entity<Identifier>
{
    public EmailUtilizador EmailUtilizador { get; set; }
    public Role Role { get; set; }
    public Password Password { get; set; }
    public NomeAssociacao? NomeAssociacao { get; set; }
    public CodigoClube? CodigoClube { get; set; }
    
    public bool Active { get; set; }
    public Associacao.Associacao Associacao { get; set; }
    public Clube.Clube Clube { get; set; }

    public Utilizador()
    {
        
    }
    public Utilizador(string email, int role, string password, string? nomeAssociacao, string? codClube)
    {
        Id = new Identifier(Guid.NewGuid());
        EmailUtilizador = new EmailUtilizador(email);
        Role = new Role(role);
        Password = new Password(password);
        if (nomeAssociacao == null | nomeAssociacao == "")
        {
            NomeAssociacao = new NomeAssociacao("");
        }
        NomeAssociacao = new NomeAssociacao(nomeAssociacao);
        if (SharedMethods.onlyNumbers(codClube) == null) 
        {
            CodigoClube = new CodigoClube(-1);
        }
        CodigoClube = new CodigoClube(Int32.Parse(codClube));
        Active = true;
    }
}
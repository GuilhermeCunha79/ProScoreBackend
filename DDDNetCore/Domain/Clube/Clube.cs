using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Domain.Clube;

public class Clube: Entity<Identifier>,IAggregateRoot
{

    public NomeClube NomeClube { get; set; }
    public NomeAssociacao NomeAssociacao { get; set; }
    public CodigoClube CodigoClube { get; set; }
    public Morada Morada { get; set; }
    public TelefoneClube TelefoneClube { get; set; }
    public NrEquipas NrEquipas { get; set; }
    public NifClube NifClube { get; set; }
    public ICollection<InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa> InscricaoProvisoriaClubeEquipa { get; set; }
    public ICollection<InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador> InscricaoProvisoriaClubeJogador{ get; set; }
    private static int totalEquipas = 0;
    public ICollection<Equipa.Equipa> Equipas { get; set; }
    public Associacao.Associacao Associacao { get; set; }

    public Clube()
    {
        
    }

    public Clube(string nomeAss,string nomeClube, string nifClube, string? morada, string telefoneClube)
    {
        Id = new Identifier(Guid.NewGuid());
        NomeAssociacao = new NomeAssociacao(nomeAss);
        CodigoClube = new CodigoClube(totalEquipas++);
        NomeClube = new NomeClube(nomeClube);
        Morada = new Morada(morada);
        NrEquipas = new NrEquipas();
        TelefoneClube = new TelefoneClube(telefoneClube);
        NifClube = new NifClube(nifClube);
    }

    public void ChangeNomeClube(string s)
    {
        NomeClube = new NomeClube(s);
    }

    
}
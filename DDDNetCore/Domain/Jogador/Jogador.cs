using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Jogador;

public class Jogador : Entity<Identifier>
{
    public EstatutoFpF EstatutoFpF { get; set; }
    public Licenca Licenca { get; set; }
    public IdentificadorPessoa IdentificadorPessoa { get; set; }
    public IdentificadorEquipa IdentificadorEquipa { get; set; }

    public Equipa.Equipa Equipa { get; set; }
    public Pessoa.Pessoa Pessoa { get; set; }
    public bool Active { get; set; }

    public ICollection<InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador> InscricaoDefinitivaAssociacaoJogador { get; set; }
    public ICollection<InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador> InscricaoProvisoriaClubeJogador{ get; set; }


    public Jogador()
    {
        Active = true;
    }

    public Jogador(string estatuto, int idPessoa, string idEquipa)
    {
        Id = new Identifier(Guid.NewGuid());
        Licenca = new Licenca();
        EstatutoFpF = new EstatutoFpF(estatuto);
        IdentificadorPessoa = new IdentificadorPessoa(idPessoa);
        IdentificadorEquipa = new IdentificadorEquipa(idEquipa);
        Active = true;
    }

    public void MarkAsInative()
    {
        if (!Active)
        {
            throw new BusinessRuleValidationException("O 'Jogador' já está inativo!");
        }

        Active = false;
    }

    public void MarkAsAtive()
    {
        if (Active)
        {
            throw new BusinessRuleValidationException("O 'Jogador' já está ativo!");
        }

        Active = true;
    }
}
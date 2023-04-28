using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class Jogador: Entity<Identifier>
{
    public EstatutoFpF EstatutoFpF { get; set; }
    public Licenca Licenca { get; set; }
    public IdentificadorPessoa IdentificadorPessoa { get; set; }
    public IdentificadorEquipa IdentificadorEquipa { get; set; }

    public bool Active { get; set; }

    public Jogador(string estatuto, string idPessoa, string idEquipa)
    {
        Id = new Identifier(Guid.NewGuid());
        Licenca = new Licenca();
        EstatutoFpF = new EstatutoFpF(estatuto);
        IdentificadorPessoa = new IdentificadorPessoa(idPessoa);
        IdentificadorEquipa= new IdentificadorEquipa(idEquipa);
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
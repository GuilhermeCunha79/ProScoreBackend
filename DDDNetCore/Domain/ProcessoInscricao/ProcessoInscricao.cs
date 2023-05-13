using System.Data;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class ProcessoInscricao : Entity<Identifier>
{
    public CodOperacao CodOperacao { get; set; }

    public TipoProcesso TipoProcesso { get; set; }
    public Estado Estado { get; set; }
    public EpocaDesportiva EpocaDesportiva { get; set; }
    public DataRegisto DataRegisto { get; set; }


    public DataSubscricao DataSubscricao { get; set; }

    public InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa InscricaoProvisoriaClubeEquipa { get; set;}
    public InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa InscricaoDefinitivaAssociacaoEquipa { get; set;}
    public InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador InscricaoProvisoriaClubeJogador { get; set;}
    public InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador InscricaoDefinitivaAssociacaoJogador { get; set;}
    
    public ProcessoInscricao()
    {
        
    }
    public ProcessoInscricao(string tipoProcesso, string epoca)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao();
        TipoProcesso = new TipoProcesso(tipoProcesso);
        Estado = new Estado();
        EpocaDesportiva = new EpocaDesportiva(epoca);
        DataSubscricao = new DataSubscricao();
    }
    

    public void ChangeEstadoAprovado()
    {
        Estado = new Estado("Aprovado");
    }
    
    public void ChangeEstadoReprovado()
    {
        Estado = new Estado("Reprovado");
    }

    public void ChangeEpocaDesportiva(string epoca)
    {
        if (epoca == null)
        {
            throw new NoNullAllowedException("A 'Época Desportiva' deve ser preenchida!");
        }
        EpocaDesportiva = new EpocaDesportiva(epoca);
    }

    public void ChangeTipoProcesso(string tipo)
    {
        if (tipo == null)
        {
            throw new NoNullAllowedException("O 'Tipo de Inscrição' deve ser preenchido!");
        }
    }
}
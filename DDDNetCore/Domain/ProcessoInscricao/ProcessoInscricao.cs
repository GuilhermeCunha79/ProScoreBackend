using System.Data;
using Azure.Identity;
using ConsoleApp1.Domain.DocumentosProcesso;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class ProcessoInscricao : Entity<Identifier>
{
    public CodOperacao CodOperacao { get; set; }

    public TipoProcesso TipoProcesso { get; set; }
    public Estado Estado { get; set; }
    public EpocaDesportiva EpocaDesportiva { get; set; }
    public DataRegisto? DataRegisto { get; set; }


    public DataSubscricao DataSubscricao { get; set; }

    public InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa InscricaoProvisoriaClubeEquipa { get; set;}
    public InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa InscricaoDefinitivaAssociacaoEquipa { get; set;}
    public InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador InscricaoProvisoriaClubeJogador { get; set;}
    public InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador InscricaoDefinitivaAssociacaoJogador { get; set;}
    public DocumentosProcesso.DocumentosProcesso? DocumentosProcesso { get; set; }


    public ProcessoInscricao()
    {
        
    }
    public ProcessoInscricao(string tipoProcesso,string codOperacao)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao(codOperacao);
        TipoProcesso = new TipoProcesso(tipoProcesso);
        Estado = new Estado();
        EpocaDesportiva = new EpocaDesportiva();
        DataSubscricao = new DataSubscricao();
        DataRegisto = new DataRegisto();
    }
    
    

    public void ChangeEstadoAprovado()
    {
        Estado = new Estado("APROVADO");
    }
    
    public void ChangeEstadoReprovado()
    {
        Estado = new Estado("Reprovado");
    }
    
    public void ChangeDataRegisto()
    {
        DataRegisto = new DataRegisto(DateTime.Today.ToString());
    }

    public void ChangeTipoProcesso(string tipo)
    {
        if (tipo == null)
        {
            throw new NoNullAllowedException("O 'Tipo de Inscrição' deve ser preenchido!");
        }
    }
}
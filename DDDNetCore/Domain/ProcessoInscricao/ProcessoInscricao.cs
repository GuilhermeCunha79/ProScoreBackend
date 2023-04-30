using System.Data;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class ProcessoInscricao : Entity<Identifier>
{
    public CodOperacao CodOperacao { get; set; }
    public NrProcesso NrProcesso { get; set; }
    public TipoProcesso TipoProcesso { get; set; }
    public Estado Estado { get; set; }
    public EpocaDesportiva EpocaDesportiva { get; set; }
    public DataRegisto DataRegisto { get; set; }


    public ProcessoInscricao(string tipoProcesso, string epoca)
    {
        Id = new Identifier(Guid.NewGuid());
        CodOperacao = new CodOperacao();
        NrProcesso = new NrProcesso();
        Enum.TryParse(tipoProcesso, out TipoProcesso proc);
        TipoProcesso = proc;
        Estado = Estado.AGUARDAR_APROVACAO_ASSOCIACAO;
        EpocaDesportiva = new EpocaDesportiva(epoca);
        DataRegisto = new DataRegisto();
    }

    public void ChangeEstadoAprovado()
    {
        Estado = Estado.APROVADO;
    }
    
    public void ChangeEstadoReprovado()
    {
        Estado = Estado.REPROVADO;
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
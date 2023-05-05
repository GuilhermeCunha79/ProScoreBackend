using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class TipoProcesso
{

    public string ProcessoTipo { get; set; }

    public TipoProcesso()
    {
        
    }

    public TipoProcesso(string tipo)
    {
        ProcessoTipo = validateTipoProcesso(tipo);
    }

    public string validateTipoProcesso(string tipo)
    {
        if (tipo == null)
        {
            throw new BusinessRuleValidationException("O 'Tipo de Processo' necessita de ser preenchido!");
        }

        return tipo;
    }
   /* PRIMEIRA,
    REVALIDACAO,
    INSCRICAO_TRANSFERENCIA_NACIONAL,
    INSCRICAO_TRANSFERENCIA_INTERNACIONAL*/
}
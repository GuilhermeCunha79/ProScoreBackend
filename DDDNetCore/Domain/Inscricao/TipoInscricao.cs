namespace ConsoleApp1.Domain.Forms;

public class TipoInscricao
{
    public string Inscricao { get; set; }

    public TipoInscricao(string inscricao)
    {
        Inscricao = inscricao;
    }

    public override string ToString()
    {
        return Inscricao;
    }
}
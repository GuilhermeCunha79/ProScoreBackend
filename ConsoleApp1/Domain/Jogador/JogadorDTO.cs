namespace ConsoleApp1.Domain.Forms;

public class JogadorDTO
{
    public Guid Id;
    public string EstatutoFPF { get; set; }
    public string Licenca { get; set; }
    public string IdentificadorPessoa { get; set; }
    public string IdentificadorEquipa { get; set; }
    public string Status { get; set; }

    public JogadorDTO(Guid id,string estatuto, string licenca, string identificadorPessoa, string identificadorEquipa, string status)
    {
        Id = id;
        EstatutoFPF = estatuto;
        Licenca = licenca;
        IdentificadorPessoa = identificadorPessoa;
        IdentificadorEquipa=identificadorEquipa;
        Status = status;
    }
}
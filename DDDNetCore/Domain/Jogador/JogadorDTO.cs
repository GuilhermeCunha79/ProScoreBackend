namespace ConsoleApp1.Domain.Jogador;

public class JogadorDTO
{
    public Guid Id;
    public string EstatutoFPF { get; set; }
    public int IdentificadorPessoa { get; set; }
    public int IdentificadorEquipa { get; set; }
    public string Status { get; set; }

    public Licenca Licenca;

    public JogadorDTO(Guid id,string estatuto, int identificadorPessoa, int identificadorEquipa, string status)
    {
        Id = id;
        EstatutoFPF = estatuto;
        Licenca = new Licenca();
        IdentificadorPessoa = identificadorPessoa;
        IdentificadorEquipa=identificadorEquipa;
        Status = status;
    }
}
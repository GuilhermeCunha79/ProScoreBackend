namespace ConsoleApp1.Domain.Jogador;

public class JogadorDTO
{
    public Guid Id;
    public string EstatutoFpF { get; set; }
    public int IdentificadorPessoa { get; set; }
    public int IdentificadorEquipa { get; set; }
    public string Status { get; set; }

    public int Licenca;

    public JogadorDTO(Guid id,int lic ,string est, int identificadorPessoa, int identificadorEquipa, string status)
    {
        Id = id;
        EstatutoFpF = est;
        Licenca = lic;
        IdentificadorPessoa = identificadorPessoa;
        IdentificadorEquipa=identificadorEquipa;
        Status = status;
    }
    

}
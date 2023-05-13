namespace ConsoleApp1.Domain.Jogador;

public class JogadorDTO
{
    public Guid Id;
    public string EstatutoFpF { get; set; }
    public int IdentificadorPessoa { get; set; }
    public int IdentificadorEquipa { get; set; }
    public string Status { get; set; }

    public Licenca Licenca;

    public JogadorDTO(Guid id,int lic ,string est, int identificadorPessoa, int identificadorEquipa, string status)
    {
        Id = id;
        EstatutoFpF = est;
        Licenca = new Licenca(lic.ToString());
        IdentificadorPessoa = identificadorPessoa;
        IdentificadorEquipa=identificadorEquipa;
        Status = status;
    }
    
    public JogadorDTO(Guid id ,string est, int identificadorPessoa, int identificadorEquipa, string status)
    {
        Id = id;
        EstatutoFpF = est;
        Licenca = new Licenca();
        IdentificadorPessoa = identificadorPessoa;
        IdentificadorEquipa=identificadorEquipa;
        Status = status;
    }
}
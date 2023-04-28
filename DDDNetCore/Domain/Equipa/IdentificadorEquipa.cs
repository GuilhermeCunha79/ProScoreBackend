namespace ConsoleApp1.Domain.Equipa;

public class IdentificadorEquipa
{
    public string IdEquipa { get; set; }
    public int nr;

    public IdentificadorEquipa()
    {
        IdEquipa=(nr++).ToString();
    }
    public IdentificadorEquipa(string idEquipa)
    {
        IdEquipa = idEquipa;
    }
}
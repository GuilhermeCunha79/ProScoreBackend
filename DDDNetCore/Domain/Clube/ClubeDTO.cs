namespace ConsoleApp1.Domain.Clube;

public class ClubeDTO
{
    public Guid Id;

    public string NomeAssociacao { get; set; }
    public string NomeClube { get; set; }
    public int CodigoClube { get; set; }
    public string? Morada { get; set; }
    public string TelefoneClube { get; set; }
    public int NrEquipas { get; set; }
    public int NifClube { get; set; }
    public string Status { get; set; }

    public ClubeDTO(Guid id, string nomeAssociacao,string nomeClube, int codigoClube, string? morada, string telefoneClube, int nrEquipas, int nifClube,string status )
    {
        Id = id;
        NomeAssociacao = nomeAssociacao;
        NomeClube = nomeClube;
        CodigoClube = codigoClube;
        Morada = morada;
        TelefoneClube = telefoneClube;
        NrEquipas = nrEquipas;
        NifClube = nifClube;
        Status = status;
    }


}
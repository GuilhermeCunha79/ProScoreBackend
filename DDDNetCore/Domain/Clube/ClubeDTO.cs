namespace ConsoleApp1.Domain.Clube;

public class ClubeDTO
{
    public Guid Id;
    public string NomeClube { get; set; }
    public CodigoClube CodigoClube { get; set; }
    public string? Morada { get; set; }
    public string TelefoneClube { get; set; }
    public NrEquipas NrEquipas { get; set; }
    public string NifClube { get; set; }
    public string Status { get; set; }

    public ClubeDTO(Guid id, string nomeClube, CodigoClube codigoClube, string? morada, string telefoneClube, NrEquipas nrEquipas, string nifClube,string status )
    {
        Id = id;
        NomeClube = nomeClube;
        CodigoClube = codigoClube;
        Morada = morada;
        TelefoneClube = telefoneClube;
        NrEquipas = nrEquipas;
        NifClube = nifClube;
        Status = status;
    }
}
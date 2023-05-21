using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Domain.ProcessoInscricao;

namespace ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;

public class InscricaoDefinitivaAssociacaoEquipaDTO
{
   public Guid Id;
   public string CodOperacao { get; set; }
   public string NomeAssociacao { get; set; }
   public int IdentificadorEquipa { get; set; }
   
   public string Status { get; set; }

   public InscricaoDefinitivaAssociacaoEquipaDTO(Guid id,string codOperacao,string nomeAssociacao,int identificadorEquipa,string status)
   {
      Id = id;
      CodOperacao = codOperacao;
      NomeAssociacao = nomeAssociacao;
      IdentificadorEquipa = identificadorEquipa;
      Status = status;
   }
}
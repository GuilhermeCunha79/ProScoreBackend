namespace ConsoleApp1.Domain.Clube;

public static class ClubeMapper{
        
    public static ClubeDTO toDto(Clube del){
        return new ClubeDTO(del.Id.AsGuid(), del.NomeAssociacao.NomeAss, del.NomeClube.NomeClub,
            del.CodigoClube.CodClube,
            del.Morada.Morad, del.TelefoneClube.TelefoneClub, del.NrEquipas.NumeroEquipas,
            del.NifClube.ClubeNif, CheckStatus(del.Active));
    }
    
    /*public static JogadorDTO toDto1(Jogador del){
        return new JogadorDTO(  del.Id.AsGuid(),del.EstatutoFpF.Estatuto, del.IdentificadorPessoa.IdPessoa, del.IdentificadorEquipa.IdEquipa,  CheckStatus(del.Active));
    }*/



    private static string CheckStatus(bool status)
    {
        if (status)
        {
            return "Active";
        }

        return "Inactive";
    }
}
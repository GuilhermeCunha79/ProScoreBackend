namespace ConsoleApp1.Domain.Associacao;


public static class AssociacaoMapper{
        
    public static AssociacaoDTO toDto(Associacao associacao){
        return new AssociacaoDTO(associacao.Id.AsGuid(),associacao.NomeAssociacao.NomeAss,
            associacao.NomeCurto.NomeCurt,associacao.Acronimo.Acronimoo);
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
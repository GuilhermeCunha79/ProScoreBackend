namespace ConsoleApp1.Domain.Jogador;

public static class JogadorMapper{
        
    public static JogadorDTO toDto(Jogador del){
        return new JogadorDTO(  del.Id.AsGuid(), del.Licenca.Lic,del.EstatutoFpF.Estatuto, del.IdentificadorPessoa.IdPessoa, del.IdentificadorEquipa.IdEquipa,  CheckStatus(del.Active));
    }
    
    /*public static JogadorDTO toDto1(Jogador del){
        return new JogadorDTO(  del.Id.AsGuid(),del.EstatutoFpF.Estatuto, del.IdentificadorPessoa.IdPessoa, del.IdentificadorEquipa.IdEquipa,  CheckStatus(del.Active));
    }*/

    public static Jogador toDomain(JogadorDTO dto){
        return  new Jogador(dto.EstatutoFpF,dto.IdentificadorPessoa,dto.IdentificadorEquipa);
    }
    
    public static Jogador toDomain1(JogadorDTO dto){
        return  new Jogador(dto.Licenca,dto.EstatutoFpF,dto.IdentificadorPessoa,dto.IdentificadorEquipa);
    }

    private static string CheckStatus(bool status)
    {
        if (status)
        {
            return "Active";
        }

        return "Inactive";
    }
}
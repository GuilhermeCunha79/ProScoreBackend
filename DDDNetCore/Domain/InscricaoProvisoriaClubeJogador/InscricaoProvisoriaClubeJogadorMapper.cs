namespace ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;


public static class InscricaoProvisoriaClubeJogadorMapper{
        
    public static InscricaoProvisoriaClubeJogadorDTO toDto(InscricaoProvisoriaClubeJogador del){
        return new InscricaoProvisoriaClubeJogadorDTO(  del.Id.AsGuid(), del.CodOperacao.CodOpe, del.CodigoClube.CodClube,del.Licenca.Lic, CheckStatus(del.Active));
    }



    public static InscricaoProvisoriaClubeJogador toDomain(InscricaoProvisoriaClubeJogadorDTO dto){
        return  new InscricaoProvisoriaClubeJogador(dto.CodigoClube);
    }
    
    public static InscricaoProvisoriaClubeJogador toDomain1(InscricaoProvisoriaClubeJogadorDTO dto){
        return  new InscricaoProvisoriaClubeJogador(dto.CodigoClube,dto.Licenca.ToString());
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
namespace ConsoleApp1.Domain.Equipa;

public static class EquipaMapper{
        
    public static EquipaDTO toDto(Equipa del){
        return new EquipaDTO(del.Id.AsGuid(),del.IdentificadorEquipa.IdEquipa,del.NomeDivisao.Divisao,del.CodigoClube.CodClube,
            del.TipoCategoria.Categoria,del.TipoGenero.Genero,del.TipoModalidade.Modalidade);
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
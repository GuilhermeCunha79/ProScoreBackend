namespace ConsoleApp1.Domain.Pessoa;

public static class PessoaMapper{
        
    public static PessoaDTO toDto(Pessoa del){
        return new PessoaDTO(  del.Id.AsGuid(), del.IdentificadorPessoa.IdPessoa,del.Nome.Nomee, del.DataNascimento.DataNasc, del.TipoGenero.Genero,del.Email.Emaill,del.NrIdentificacao.NumeroId.ToString(),del.NascencaPais.PaisNascenca,del.NacionalidadePais.NacionalidadePaiss,  CheckStatus(del.Active),del.Telefone.Telemovel,del.ConcelhoResidência.Concelho);
    }

    public static Pessoa toDomain(PessoaDTO dto){
        return  new Pessoa(dto.Nome,dto.IdentificadorPessoa,dto.DataNascimento,dto.TipoGenero,dto.Email,dto.NrIdentificacao,dto.NascencaPais,dto.NacionalidadePais);
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
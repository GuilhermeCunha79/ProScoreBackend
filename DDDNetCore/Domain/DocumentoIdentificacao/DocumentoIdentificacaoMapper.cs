using ConsoleApp1.Domain.DocumentosProcesso;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;



public static class DocumentoIdentificacaoMapper
{

    public static DocIdentificacaoDTO toDto(DocIdentificacao del)
    {
        return new DocIdentificacaoDTO(del.Id.AsGuid(), del.NrIdentificacao.NumeroId.ToString(),del.LetrasDoc.LetrasDocumento, del.CheckDigit.CheckDig,
            del.ValidadeDoc.Data, del.Nif.NumIdFis,del.NrUtente.NumUtente, CheckStatus(del.Active));
    }

  



    public static DocIdentificacao toDomain(DocIdentificacaoDTO dto)
    {
        return new DocIdentificacao(dto.NrIdentificacao,dto.LetrasDoc,dto.CheckDigit,dto.ValidadeDoc,dto.Nif,dto.NrUtente);
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
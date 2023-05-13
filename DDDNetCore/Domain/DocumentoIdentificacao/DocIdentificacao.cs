using System.Data;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public class DocIdentificacao: Entity<Identifier>
{
    public NrIdentificacao NrIdentificacao { get; set; }
    public LetrasDoc LetrasDoc { get; set; }
    public CheckDigit CheckDigit { get; set; }
    public ValidadeDoc ValidadeDoc { get; set; }
    public NrUtente NrUtente { get; set; }
    public Nif Nif { get; set; }
    public bool Active { get; set; }
    public Pessoa.Pessoa Pessoa { get; set; }

    public DocIdentificacao()
    {
        
    }
    public DocIdentificacao(string nrId, string letrasId, string checkDigit, string validade, string nif, string nrUtente)
    {

        Id = new Identifier(Guid.NewGuid());
        NrIdentificacao = new NrIdentificacao(nrId);
        LetrasDoc = new LetrasDoc(letrasId);
        CheckDigit = new CheckDigit(checkDigit);
        ValidadeDoc = new ValidadeDoc(validade);
        Nif = new Nif(nif) ;
        NrUtente = new NrUtente(nrUtente);
        Active = true;
    }


    public void ChangeNrIdentificacao(string newId)
    {
        if (newId == null)
            throw new NoNullAllowedException("O 'Número de Identificação' necessita de ser preenchido!");
        NrIdentificacao = new NrIdentificacao(newId);
    }
    
    public void ChangeLetrasDoc(string newId)
    {
        if (newId == null)
            throw new NoNullAllowedException("As 'Letras do Documento de Identificação' necessitam de ser preenchidas!");
        LetrasDoc = new LetrasDoc(newId);
    }
    
    public void ChangeCheckDigit(string newId)
    {
        if (newId == null)
            throw new NoNullAllowedException("O 'CheckDigit' necessita de ser preenchido!");
        CheckDigit = new CheckDigit(newId);
    }
    
    public void ChangeValidadeDoc(string newId)
    {
        if (newId == null)
            throw new NoNullAllowedException("O 'Validade do Documento de Identificação' necessita de ser preenchida!");
        ValidadeDoc = new ValidadeDoc(newId);
    }
    
    public void ChangeNif(string newId)
    {
        ValidadeDoc = new ValidadeDoc(newId);
    }
    
    public void ChangeNumUtente(string newId)
    {
        NrUtente = new NrUtente(newId);
    }
    
    public void MarkAsInative()
    {
        if (!Active)
        {
            throw new BusinessRuleValidationException("A Associação já está inativa!");
        }

        Active = false;
    }

    public void MarkAsAtive()
    {
        if (Active)
        {
            throw new BusinessRuleValidationException("A Associação já está ativa!");
        }

        Active = true;
    }
    
    public override string ToString()
    {
        return NrIdentificacao.ToString()+ '/' + '[' + CheckDigit + ']' + LetrasDoc ;
    }
}
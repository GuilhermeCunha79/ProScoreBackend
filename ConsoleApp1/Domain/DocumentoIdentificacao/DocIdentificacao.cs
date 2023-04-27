

using System.Data;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Forms;

public class DocIdentificacao: Entity<Identifier>
{
    public Identifier Id { get; set; }
    public NrIdentificacao NrIdentificacao { get; set; }
    public LetrasDoc LetrasDoc { get; set; }
    public CheckDigit CheckDigit { get; set; }
    public ValidadeDoc ValidadeDoc { get; set; }
    public NrUtente NrUtente { get; set; }
    public Nif Nif { get; set; }
    public bool Active { get; set; }

    public DocIdentificacao(string nrId, string letrasId, string checkDigit, string validade, string nif, string nrUtente)
    {
        Id = new Identifier(Guid.NewGuid());
        NrIdentificacao = new NrIdentificacao(nrId);
        LetrasDoc = new LetrasDoc(letrasId);
        CheckDigit = new CheckDigit(checkDigit);
        ValidadeDoc = new ValidadeDoc(validade);
        Nif = new Nif(nif);
        NrUtente = new NrUtente(nrUtente);
        Active = true;
    }

    public void changeNrIdentificacao(string newId)
    {
        if (newId == null)
            throw new NoNullAllowedException("O 'Número de Identificação' necessita de ser preenchido!");
        NrIdentificacao = new NrIdentificacao(newId);
    }
    
    public void changeLetrasDoc(string newId)
    {
        if (newId == null)
            throw new NoNullAllowedException("As 'Letras do Documento de Identificação' necessitam de ser preenchidas!");
        LetrasDoc = new LetrasDoc(newId);
    }
    
    public void changeCheckDigit(string newId)
    {
        if (newId == null)
            throw new NoNullAllowedException("O 'CheckDigit' necessita de ser preenchido!");
        CheckDigit = new CheckDigit(newId);
    }
    
    public void changeValidadeDoc(string newId)
    {
        if (newId == null)
            throw new NoNullAllowedException("O 'Validade do Documento de Identificação' necessita de ser preenchida!");
        ValidadeDoc = new ValidadeDoc(newId);
    }
    
    public void changeNif(string newId)
    {
        ValidadeDoc = new ValidadeDoc(newId);
    }
    
    public void changeNumUtente(string newId)
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
        return NrIdentificacao.ToString()+ '/' + LetrasDoc + '[' + CheckDigit + ']' ;
    }
}
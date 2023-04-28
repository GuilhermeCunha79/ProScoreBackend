using System.Data;
using ConsoleApp1.Domain.Categoria;
using ConsoleApp1.Domain.Forms;
using ConsoleApp1.Domain.Genero;
using ConsoleApp1.Domain.Modalidade;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Equipa;

public class Equipa: Entity<Identifier>
{
    public IdentificadorEquipa IdentificadorEquipa { get; set; }
    public Divisao Divisao { get; set; }
    public CodigoClube CodigoClube { get; set; }
    public TipoCategoria TipoCategoria { get; set; }
    public TipoModalidade TipoModalidade { set; get; }
    public TipoGenero TipoGenero { set; get; }
    public bool Active { get; set; }

    public Equipa(string divisao, string codClube, string tipoCategoria, string tipoModalidade, string tipoGenero)
    {
        Id = new Identifier(Guid.NewGuid());
        IdentificadorEquipa = new IdentificadorEquipa();
        Divisao = new Divisao(divisao);
        CodigoClube = new CodigoClube(codClube);
        TipoCategoria=(TipoCategoria)Enum.Parse(typeof(TipoCategoria), tipoCategoria);
        TipoModalidade=(TipoModalidade)Enum.Parse(typeof(TipoModalidade), tipoModalidade);
        TipoGenero=(TipoGenero)Enum.Parse(typeof(TipoGenero), tipoGenero);
        Active = true;
    }

    public void ChangeDivisao(string divisao)
    {
        if (divisao == null)
        {
            throw new NoNullAllowedException("A 'Divisão' da Equipa deve ser preenchida!");
        }

        Divisao = new Divisao(divisao);
    }

    public void ChangeCodClube(string codClube)
    {
        if (codClube == null)
        {
            throw new NoNullAllowedException("O 'Código do Clube' a qual a Equipa pertence deve ser preenchido!");
        }

        CodigoClube = new CodigoClube(codClube);
    }

    public void ChangeTipoCategoria(string categoria)
    {
        if (categoria == null)
        {
            throw new NoNullAllowedException("A 'Categoria' da Equipa deve ser preenchida!");
        }
        
        TipoCategoria= (TipoCategoria)Enum.Parse(typeof(TipoCategoria), categoria);
    }
    
    public void ChangeTipoModalidade(string modalidade)
    {
        if (modalidade == null)
        {
            throw new NoNullAllowedException("A 'Modalidade' da Equipa deve ser preenchida!");
        }
        
        TipoModalidade= (TipoModalidade)Enum.Parse(typeof(TipoModalidade), modalidade);
    }
    
    public void ChangeTipoGenero(string genero)
    {
        if (genero == null)
        {
            throw new NoNullAllowedException("O 'Género' da Equipa deve ser preenchido!");
        }
        
        TipoGenero= (TipoGenero)Enum.Parse(typeof(TipoGenero), genero);
    }
    
    public void MarkAsInative()
    {
        if (!Active)
        {
            throw new BusinessRuleValidationException("A 'Equipa' já está inativa!");
        }

        Active = false;
    }

    public void MarkAsAtive()
    {
        if (Active)
        {
            throw new BusinessRuleValidationException("A 'Equipa' já está ativa!");
        }

        Active = true;
    }
}
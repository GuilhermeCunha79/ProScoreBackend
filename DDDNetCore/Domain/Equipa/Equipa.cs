
using System.Data;
using ConsoleApp1.Domain.Categoria;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.Genero;
using ConsoleApp1.Domain.Modalidade;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Equipa;

public class Equipa: Entity<Identifier>,IAggregateRoot
{
    public IdentificadorEquipa IdentificadorEquipa { get; set; }
   
    private static int totalEquipas = 1;
    public CodigoClube CodigoClube { get; set; }
    public TipoCategoria TipoCategoria { get; set; }
    public TipoModalidade TipoModalidade { set; get; }
    public TipoGenero TipoGenero { set; get; }
    public bool Active { get; set; }
    public Divisao Divisao { get; set; }
    public ICollection<Jogador.Jogador> Jogadores { get; set; }

    public Clube.Clube Clube { get; set; }
    public Genero.Genero Genero { get; set; }
    public Categoria.Categoria Categoria{ get; set; }
    public Modalidade.Modalidade Modalidade { get; set; }

    public ICollection<InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa> InscricaoProvisoriaClubeEquipa { get; set; }
    public ICollection<InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa> InscricaoDefinitivaAssociacaoEquipa { get; set; }


    public Equipa()
    {
        
    }
    public Equipa(string divisao, int codClube, string tipoCategoria, string tipoModalidade, string tipoGenero)
    {
        Id = new Identifier(Guid.NewGuid());
        IdentificadorEquipa = new IdentificadorEquipa(totalEquipas++);
        Divisao = new Divisao(divisao);
        CodigoClube = new CodigoClube(codClube);
        TipoCategoria=new TipoCategoria(tipoCategoria);
        TipoModalidade=new TipoModalidade(tipoModalidade);
        TipoGenero=new TipoGenero(tipoGenero);
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

    public void ChangeCodClube(int codClube)
    {
        /*if (codClube == null)
        {
            throw new NoNullAllowedException("O 'Código do Clube' a qual a Equipa pertence deve ser preenchido!");
        }*/

        CodigoClube = new CodigoClube(codClube);
    }

    public void ChangeTipoCategoria(string categoria)
    {
        if (categoria == null)
        {
            throw new NoNullAllowedException("A 'Categoria' da Equipa deve ser preenchida!");
        }
        
        TipoCategoria= new TipoCategoria(categoria);
    }
    
    public void ChangeTipoModalidade(string modalidade)
    {
        if (modalidade == null)
        {
            throw new NoNullAllowedException("A 'Modalidade' da Equipa deve ser preenchida!");
        }
        
        TipoModalidade= new TipoModalidade(modalidade);
    }
    
    public void ChangeTipoGenero(string genero)
    {
        if (genero == null)
        {
            throw new NoNullAllowedException("O 'Género' da Equipa deve ser preenchido!");
        }
        
        TipoGenero= new TipoGenero(genero);
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
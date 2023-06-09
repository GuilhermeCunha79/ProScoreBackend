using ConsoleApp1.Domain.Divisao;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Utilizador;
using ConsoleApp1.Infraestructure.Associacao;
using ConsoleApp1.Infraestructure.Categoria;
using ConsoleApp1.Infraestructure.Clube;
using ConsoleApp1.Infraestructure.CodigoPaises;
using ConsoleApp1.Infraestructure.Divisao;
using ConsoleApp1.Infraestructure.DocumentoIdentificacao;
using ConsoleApp1.Infraestructure.DocumentosProcesso;
using ConsoleApp1.Infraestructure.Equipa;
using ConsoleApp1.Infraestructure.Genero;
using ConsoleApp1.Infraestructure.InscricaoDefinitivaAssociacaoEquipa;
using ConsoleApp1.Infraestructure.InscricaoDefinitivaAssociacaoJogador;
using ConsoleApp1.Infraestructure.InscricaoProvisoriaClubeEquipa;
using ConsoleApp1.Infraestructure.InscricaoProvisoriaClubeJogador;
using ConsoleApp1.Infraestructure.Jogador;
using ConsoleApp1.Infraestructure.Modalidade;
using ConsoleApp1.Infraestructure.Nacionalidade;
using ConsoleApp1.Infraestructure.Pais;
using ConsoleApp1.Infraestructure.PaisCodigo;
using ConsoleApp1.Infraestructure.PaisNascenca;
using ConsoleApp1.Infraestructure.Pessoa;
using ConsoleApp1.Infraestructure.ProcessoInscricao;
using ConsoleApp1.Infraestructure.Utilizador;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure;

public class DDDSample1DbContext : DbContext
{
    public DbSet<Domain.Jogador.Jogador> Jogadores { get; set; }
    public DbSet<Domain.Equipa.Equipa> Equipas { get; set; }
    
    public DbSet<Domain.Associacao.Associacao> Associacoes { get; set; }
    
    public DbSet<Domain.Nacionalidade.Nacionalidade> Nacionalidades { get; set; }
    
    public DbSet<Domain.PaisNascenca.PaisNascenca> PaisNascenca { get; set; }
    public DbSet<Domain.InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa> InscricaoDefinitivaAssociacaoEquipas { get; set; }
    public DbSet<Domain.InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador> InscricaoDefinitivaAssociacaoJogador { get; set; }
    
    public DbSet<Domain.InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa> InscricaoProvisoriaClubeEquipa { get; set; }
    public DbSet<Domain.InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador> InscricaoProvisoriaClubeJogador { get; set; }
    public DbSet<DocIdentificacao> DocId { get; set; }
    public DbSet<Domain.DocumentosProcesso.DocumentosProcesso> DocumentosProcessos { get; set; }
    public DbSet<Domain.Clube.Clube> Clubes { get; set; }
    public DbSet<Domain.ProcessoInscricao.ProcessoInscricao> Processos { get; set; }
    public DbSet<Domain.Pessoa.Pessoa> Pessoas { get; set; }

    public DbSet<Domain.Utilizador.Utilizador> Utilizadores { get; set; }

    public int ObterNumeroDeJogadores()
    {
        return Jogadores.Count()+1;
    }
    
    public int ObterNumeroDeClubes()
    {
        return Clubes.Count()+1;
    }

    public int ObterNumeroDePessoas()
    {
        return Pessoas.Count()+1;
    }

    public int ObterNumeroDeEquipas()
    {
        return Equipas.Count()+1;
    }

    public int ObterNumeroDeProcessos()
    {
        return Processos.Count()+1;
    }
    public DDDSample1DbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=192.168.1.72\\FPFSCOREDEV;Database=EstagioGuilherme;User Id=ads;Password=ads;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfiguration(new JogadorEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CategoriaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new NacionalidadeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PessoaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GeneroEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentoIdentificacaoEntityTypeConiguration());

        modelBuilder.ApplyConfiguration(new PaisEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PaisCodigoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PaisNascencaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CodigoPaisesEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProcessoInscricaoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InscricaoDefinitivaAssociacaoEquipaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InscricaoProvisoriaClubeEquipaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InscricaoProvisoriaClubeJogadorEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InscricaoDefinitivaAssociacaoJogadorEntityTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new ModalidadeEntityTypeConfiguration());
      
        modelBuilder.ApplyConfiguration(new ClubeEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new EquipaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AssociacaoEntityTypeConfiguration());
       
        modelBuilder.ApplyConfiguration(new UtilizadorEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentosProcessoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DivisaoEntityTypeConfigurationType());
    }
}
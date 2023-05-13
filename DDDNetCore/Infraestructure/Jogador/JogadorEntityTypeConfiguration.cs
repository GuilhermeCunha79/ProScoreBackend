using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Jogador;


internal class JogadorEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Jogador.Jogador>
{
    public void Configure(EntityTypeBuilder<Domain.Jogador.Jogador> builder)
    {
        builder.ToTable("Jogador", SchemaNames.DDDSample1);
        builder.HasKey(b => b.Licenca);

        //builder.Property<bool>("_active").HasColumnName("Active");

        builder.HasOne(j => j.Equipa)
            .WithMany(e => e.Jogadores)
            .HasForeignKey(j => j.IdentificadorEquipa);
        
       
        
        builder.Property(b => b.EstatutoFpF)
            .HasConversion(
                v => v.Estatuto,
                v => new EstatutoFpF(v));
        
        builder.Property(b => b.IdentificadorEquipa)
            .HasConversion(
                v => v.IdEquipa,
                v => new IdentificadorEquipa(v));
        
        builder.Property(b => b.Licenca)
            .HasConversion(
                v => v.Lic,
                v => new Licenca(v.ToString()));
        
        
        builder.Property(b => b.IdentificadorPessoa)
            .HasConversion(
                v => v.IdPessoa,
                v => new IdentificadorPessoa(v));
        
        
        builder
            .HasMany(e => e.InscricaoDefinitivaAssociacaoJogador)
            .WithOne(j => j.Jogador)
            .HasForeignKey(e=>e.Licenca)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(e => e.InscricaoProvisoriaClubeJogador)
            .WithOne(j => j.Jogador)
            .HasForeignKey(e=>e.Licenca)
            .OnDelete(DeleteBehavior.Restrict);

        
    }
}

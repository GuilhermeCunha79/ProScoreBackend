using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Associacao;

internal class AssociacaoEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Associacao.Associacao>
{
    public void Configure(EntityTypeBuilder<Domain.Associacao.Associacao> builder)
    {
        builder.ToTable("Associacao", SchemaNames.DDDSample1);
        builder.HasKey(b => b.NomeAssociacao);

        //builder.Property<bool>("_active").HasColumnName("Active");

        builder.Property(b => b.Id)
            .HasConversion(
                v => v.ToString(),
                v => new Identifier(Guid.Parse(v)));

        builder.Property(b => b.NomeAssociacao)
            .HasConversion(
                v => v.NomeAss,
                v => new NomeAssociacao(v.ToString()));
        
        builder.Property(b => b.NomeCurto)
            .HasConversion(
                v => v.NomeCurt,
                v => new NomeCurto(v.ToString()));
        
        builder.Property(b => b.Acronimo)
            .HasConversion(
                v => v.Acronimoo,
                v => new Acronimo(v.ToString()));
        
        builder
            .HasMany(e => e.Clubes)
            .WithOne(j => j.Associacao)
            .HasForeignKey(e => e.NomeAssociacao)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(e => e.InscricaoDefinitivaAssociacaoJogador)
            .WithOne(j => j.Associacao)
            .HasForeignKey(e=>e.NomeAssociacao)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(e => e.InscricaoDefinitivaAssociacaoEquipa)
            .WithOne(j => j.Associacao)
            .HasForeignKey(e=>e.NomeAssociacao)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(e => e.Utilizadores)
            .WithOne(j => j.Associacao)
            .HasForeignKey(e=>e.NomeAssociacao)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
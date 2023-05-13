using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Equipa;

internal class EquipaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Equipa.Equipa>
{
    public void Configure(EntityTypeBuilder<Domain.Equipa.Equipa> builder)
    {
        builder.ToTable("Equipa", SchemaNames.DDDSample1);
        builder.HasKey(b => b.IdentificadorEquipa);
        
        //builder.Property<bool>("_active").HasColumnName("Active");
        
        builder.Property(b => b.Divisao)
            .HasConversion(
                v => v.Div,
                v => new Divisao(v));
        
        builder
            .HasMany(e => e.Jogadores)
            .WithOne(j => j.Equipa)
            .HasForeignKey(e => e.IdentificadorEquipa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(e => e.InscricaoProvisoriaClubeEquipa)
            .WithOne(j => j.Equipa)
            .HasForeignKey(e => e.IdentificadorEquipa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(e => e.InscricaoDefinitivaAssociacaoEquipa)
            .WithOne(j => j.Equipa)
            .HasForeignKey(e => e.IdentificadorEquipa)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(b => b.IdentificadorEquipa)
            .HasConversion(
                v => v.IdEquipa,
                v => new IdentificadorEquipa(v));
    }

}
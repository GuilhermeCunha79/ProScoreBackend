using ConsoleApp1.Domain.Genero;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Genero;

internal class GeneroEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Genero.Genero>
{
    public void Configure(EntityTypeBuilder<Domain.Genero.Genero> builder)
    {
        builder.ToTable("Genero", SchemaNames.DDDSample1);
        builder.HasKey(b => b.TipoGenero);

        //builder.Property<bool>("_active").HasColumnName("Active");

        builder
            .HasMany(e => e.Pessoa)
            .WithOne(j => j.Genero)
            .HasForeignKey(e => e.TipoGenero).OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(e => e.Equipa)
            .WithOne(j => j.Genero)
            .HasForeignKey(e => e.TipoGenero)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(b => b.Id)
            .HasConversion(
                v => v.ToString(),
                v => new Identifier(Guid.Parse(v)));

        builder.Property(b => b.TipoGenero)
            .HasConversion(
                v => v.Genero,
                v => new TipoGenero(v));
    }
}
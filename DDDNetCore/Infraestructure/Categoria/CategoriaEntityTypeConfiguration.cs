using ConsoleApp1.Domain.Categoria;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Categoria;

internal class CategoriaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Categoria.Categoria>
{
    public void Configure(EntityTypeBuilder<Domain.Categoria.Categoria> builder)
    {
        builder.ToTable("Categoria", SchemaNames.DDDSample1);
        builder.HasKey(b => b.TipoCategoria);

        //builder.Property<bool>("_active").HasColumnName("Active");

        builder.Property(b => b.Id)
            .HasConversion(
                v => v.ToString(),
                v => new Identifier(Guid.Parse(v)));
        
        builder.Property(b => b.TipoCategoria)
            .HasConversion(
                v => v.Categoria,
                v => new TipoCategoria(v));
        
        builder
            .HasMany(e => e.Equipas)
            .WithOne(j => j.Categoria)
            .HasForeignKey(e=>e.TipoCategoria)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
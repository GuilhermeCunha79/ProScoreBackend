using ConsoleApp1.Domain.Pais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Pais;

internal class PaisEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Pais.Pais>
{
    public void Configure(EntityTypeBuilder<Domain.Pais.Pais> builder)
    {
        builder.ToTable("Pais", SchemaNames.DDDSample1);
        builder.HasKey(b => b.NomePais);

        //builder.Property<bool>("_active").HasColumnName("Active");
        builder
            .HasMany(e => e.PaisCodigo)
            .WithOne(j => j.Pais)
            .HasForeignKey(e=>e.NomePais);
        
        builder.Property(b => b.NomePais)
            .HasConversion(
                v => v.Nome,
                v => new NomePais(v));
    }
}
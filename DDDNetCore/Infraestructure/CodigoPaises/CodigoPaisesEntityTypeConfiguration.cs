using ConsoleApp1.Domain.CodigoPaises;
using ConsoleApp1.Domain.Pais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.CodigoPaises;

internal class CodigoPaisesEntityTypeConfiguration : IEntityTypeConfiguration<Domain.CodigoPaises.CodigoPaises>
{
    public void Configure(EntityTypeBuilder<Domain.CodigoPaises.CodigoPaises> builder)
    {
        builder.ToTable("CodigoPaises", SchemaNames.DDDSample1);
        builder.HasKey(b => b.CodPais);

        //builder.Property<bool>("_active").HasColumnName("Active");
        builder
            .HasMany(e => e.PaisCodigo)
            .WithOne(j => j.CodigoPaises)
            .HasForeignKey(e => e.CodPaises);
        
        builder.Property(b => b.CodPais)
            .HasConversion(
                v => v.CodigoPais,
                v => new CodPaises(v));
    }
}
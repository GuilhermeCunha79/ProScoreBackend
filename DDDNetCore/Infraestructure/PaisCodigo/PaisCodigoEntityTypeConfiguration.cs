using ConsoleApp1.Domain.CodigoPaises;
using ConsoleApp1.Domain.Pais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.PaisCodigo;

internal class PaisCodigoEntityTypeConfiguration : IEntityTypeConfiguration<Domain.PaisCodigo.PaisCodigo>
{
    public void Configure(EntityTypeBuilder<Domain.PaisCodigo.PaisCodigo> builder)
    {
        builder.ToTable("PaisCodigo", SchemaNames.DDDSample1);
        builder.HasKey( b=> new {b.NomePais,b.CodPaises});
  

        //builder.Property<bool>("_active").HasColumnName("Active");
        
        
        builder
            .HasOne(e => e.PaisNascenca)
            .WithOne(j => j.PaisCodigo)
            .HasForeignKey<Domain.PaisNascenca.PaisNascenca>(b=> new {b.NomePais,b.CodPaises})
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(e => e.Nacionalidade)
            .WithOne(j => j.PaisCodigo)
            .HasForeignKey<Domain.Nacionalidade.Nacionalidade>(b=> new {b.NomePais,b.CodPaises})
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(b => b.NomePais)
            .HasConversion(
                v => v.Nome,
                v => new NomePais(v));
        
        builder.Property(b => b.CodPaises)
            .HasConversion(
                v => v.CodigoPais,
                v => new CodPaises(v));
    }
}
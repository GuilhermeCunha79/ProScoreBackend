using ConsoleApp1.Domain.Clube;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.InscricaoProvisoriaClubeEquipa;


internal class InscricaoProvisoriaClubeEquipaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa>
{
    public void Configure(EntityTypeBuilder<Domain.InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa> builder)
    {
        builder.ToTable("InscricaoProvisoriaClubeEquipa", SchemaNames.DDDSample1);
        builder.HasKey( b=> new {b.CodOperacao,b.IdentificadorEquipa,b.CodigoClube});
        
        //builder.Property<bool>("_active").HasColumnName("Active");
        
        builder.Property(b => b.CodigoClube)
            .HasConversion(
                v => v.CodClube,
                v => new CodigoClube(v));
    }
}
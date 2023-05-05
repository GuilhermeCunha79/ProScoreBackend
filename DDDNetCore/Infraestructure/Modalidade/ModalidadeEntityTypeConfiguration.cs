using ConsoleApp1.Domain.Categoria;
using ConsoleApp1.Domain.Modalidade;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Modalidade;


internal class ModalidadeEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Modalidade.Modalidade>
{
    public void Configure(EntityTypeBuilder<Domain.Modalidade.Modalidade> builder)
    {
        builder.ToTable("Modalidade", SchemaNames.DDDSample1);
        builder.HasKey(b => b.TipoModalidade);

        //builder.Property<bool>("_active").HasColumnName("Active");

        builder.Property(b => b.Id)
            .HasConversion(
                v => v.ToString(),
                v => new Identifier(Guid.Parse(v)));
        
        builder.Property(b => b.TipoModalidade)
            .HasConversion(
                v => v.Modalidade,
                v => new TipoModalidade(v));
        
        builder
            .HasMany(e => e.Equipas)
            .WithOne(j => j.Modalidade)
            .HasForeignKey(e=>e.TipoModalidade)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
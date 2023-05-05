using ConsoleApp1.Domain.Categoria;
using ConsoleApp1.Domain.Nacionalidade;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Nacionalidade;

internal class NacionalidadeEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Nacionalidade.Nacionalidade>
{
    public void Configure(EntityTypeBuilder<Domain.Nacionalidade.Nacionalidade> builder)
    {
        builder.ToTable("Nacionalidade", SchemaNames.DDDSample1);
        builder.HasKey(b => b.NacionalidadePais);

        //builder.Property<bool>("_active").HasColumnName("Active");
        
        builder
            .HasOne(e => e.Pessoa)
            .WithOne(j => j.Nacionalidade)
            .HasForeignKey<Domain.Pessoa.Pessoa>(e=>e.NacionalidadePais);
        
        builder.Property(b => b.NacionalidadePais)
            .HasConversion(
                v => v.NacionalidadePaiss,
                v => new NacionalidadePais(v.ToString()));

    }
}

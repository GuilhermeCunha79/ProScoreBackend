using ConsoleApp1.Domain.PaisNascenca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.PaisNascenca;


internal class PaisNascencaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.PaisNascenca.PaisNascenca>
{
    public void Configure(EntityTypeBuilder<Domain.PaisNascenca.PaisNascenca> builder)
    {
        builder.ToTable("PaisNascenca", SchemaNames.DDDSample1);
        builder.HasKey(b => b.NascencaPais);

        //builder.Property<bool>("_active").HasColumnName("Active");

        builder
            .HasOne(e => e.Pessoa)
            .WithOne(j => j.PaisNascenca)
            .HasForeignKey<Domain.Pessoa.Pessoa>(e => e.NascencaPais);
        
        builder.Property(b => b.NascencaPais)
            .HasConversion(
                v => v.PaisNascenca,
                v => new NascencaPais(v.ToString()));
    }
}
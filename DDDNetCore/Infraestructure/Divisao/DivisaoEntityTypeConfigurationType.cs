using ConsoleApp1.Domain.Divisao;
using ConsoleApp1.Domain.Nacionalidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure;


internal class DivisaoEntityTypeConfigurationType : IEntityTypeConfiguration<Divisao>
{
    public void Configure(EntityTypeBuilder<Divisao> builder)
    {
        builder.ToTable("Divisao", SchemaNames.DDDSample1);
        builder.HasKey(b => b.NomeDivisao);

        //builder.Property<bool>("_active").HasColumnName("Active");
        
        builder
            .HasMany(e => e.Equipa)
            .WithOne(j => j.Divisao)
            .HasForeignKey(e=>e.NomeDivisao)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.Property(b => b.NomeDivisao)
            .HasConversion(
                v => v.Divisao,
                v => new NomeDivisao(v));

        
        

    }
}
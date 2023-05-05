using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Clube;


internal class ClubeEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Clube.Clube>
{
    public void Configure(EntityTypeBuilder<Domain.Clube.Clube> builder)
    {
        builder.ToTable("Clube", SchemaNames.DDDSample1);
        builder.HasKey(b => b.CodigoClube);
        builder.OwnsOne(b => b.NomeClube);

       builder.OwnsOne(b => b.TelefoneClube);
        builder.OwnsOne(b => b.NrEquipas);
        builder.OwnsOne(b => b.NifClube);
        builder.OwnsOne(b => b.Morada);
    builder.Property(b => b.CodigoClube)
        .HasConversion(
            v => v.CodClube,
            v => new CodigoClube(v.ToString()));
        
        builder.Property(b => b.Id)
            .HasConversion(
                v => v.ToString(),
                v => new Identifier(Guid.Parse(v)));

        //builder.Property<bool>("_active").HasColumnName("Active");
          builder
             .HasMany(e => e.InscricaoProvisoriaClubeEquipa)
             .WithOne(j => j.Clube)
             .HasForeignKey(e=>e.CodigoClube)
             .OnDelete(DeleteBehavior.Restrict);
         
        builder
             .HasMany(e => e.InscricaoProvisoriaClubeJogador)
             .WithOne(j => j.Clube)
             .HasForeignKey(e=>e.CodigoClube)
             .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(e => e.Equipas)
            .WithOne(j => j.Clube)
            .HasForeignKey(e=>e.CodigoClube)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(b => b.NomeAssociacao)
            .HasConversion(
                v => v.NomeAss,
                v => new NomeAssociacao(v.ToString()));

    }
}
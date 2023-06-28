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

        builder.Property(b => b.NomeClube)
            .HasConversion(
                v => v.NomeClub,
                v => new NomeClube(v)).IsRequired();

        builder.Property(b => b.TelefoneClube)
            .HasConversion(
                v => v.TelefoneClub,
                v => new TelefoneClube(v)).IsRequired();

        builder.Property(b => b.NrEquipas)
            .HasConversion(
                v => v.NumeroEquipas,
                v => new NrEquipas(v)).IsRequired();

        builder.Property(b => b.NifClube)
            .HasConversion(
                v => v.ClubeNif,
                v => new NifClube(v.ToString())).IsRequired();

        builder.Property(b => b.Morada)
            .HasConversion(
                v => v.Morad,
                v => new Morada()).IsRequired();

        builder.Property(b => b.CodigoClube)
            .HasConversion(
                v => v.CodClube,
                v => new CodigoClube(v)).IsRequired();
        

        //builder.Property<bool>("_active").HasColumnName("Active");
        builder
            .HasMany(e => e.InscricaoProvisoriaClubeEquipa)
            .WithOne(j => j.Clube)
            .HasForeignKey(e => e.CodigoClube)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(e => e.InscricaoProvisoriaClubeJogador)
            .WithOne(j => j.Clube)
            .HasForeignKey(e => e.CodigoClube)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(e => e.Equipas)
            .WithOne(j => j.Clube)
            .HasForeignKey(e => e.CodigoClube)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(b => b.NomeAssociacao)
            .HasConversion(
                v => v.NomeAss,
                v => new NomeAssociacao(v.ToString()));
        
        builder
            .HasMany(e => e.Utilizadores)
            .WithOne(j => j.Clube)
            .HasForeignKey(e=>e.CodigoClube)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
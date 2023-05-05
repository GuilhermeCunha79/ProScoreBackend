using ConsoleApp1.Domain.Associacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.InscricaoDefinitivaAssociacaoEquipa;


internal class InscricaoDefinitivaAssociacaoEquipaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa>
{
    public void Configure(EntityTypeBuilder<Domain.InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa> builder)
    {
        builder.ToTable("InscricaoDefinitivaAssociacaoEquipa", SchemaNames.DDDSample1);
        builder.HasKey( b=> new {b.CodOperacao,b.IdentificadorEquipa,b.NomeAssociacao});
        
        //builder.Property<bool>("_active").HasColumnName("Active");
        
        builder.Property(b => b.NomeAssociacao)
            .HasConversion(
                v => v.NomeAss,
                v => new NomeAssociacao(v.ToString()));
    }
}
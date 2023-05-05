using ConsoleApp1.Domain.Associacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.InscricaoDefinitivaAssociacaoJogador;


internal class InscricaoDefinitivaAssociacaoJogadorEntityTypeConfiguration : IEntityTypeConfiguration<Domain.InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador>
{
    public void Configure(EntityTypeBuilder<Domain.InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador> builder)
    {
        builder.ToTable("InscricaoDefinitivaAssociacaoJogador", SchemaNames.DDDSample1);
        builder.HasKey( b=> new {b.CodOperacao,b.Licenca,b.NomeAssociacao});
        
        //builder.Property<bool>("_active").HasColumnName("Active");
        
        builder.Property(b => b.NomeAssociacao)
            .HasConversion(
                v => v.NomeAss,
                v => new NomeAssociacao(v.ToString()));
    }
}
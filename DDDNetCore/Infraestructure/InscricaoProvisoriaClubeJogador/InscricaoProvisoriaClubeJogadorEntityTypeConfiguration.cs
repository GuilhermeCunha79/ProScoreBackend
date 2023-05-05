using ConsoleApp1.Domain.Genero;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.InscricaoProvisoriaClubeJogador;


internal class InscricaoProvisoriaClubeJogadorEntityTypeConfiguration : IEntityTypeConfiguration<Domain.InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador>
{
    public void Configure(EntityTypeBuilder<Domain.InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador> builder)
    {
        builder.ToTable("InscricaoProvisoriaClubeJogador", SchemaNames.DDDSample1);
        builder.HasKey( b=> new {b.CodOperacao,b.Licenca,b.CodigoClube});
        
        //builder.Property<bool>("_active").HasColumnName("Active");
    }
}
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.DocumentoIdentificacao;


    internal class DocumentoIdentificacaoEntityTypeConiguration : IEntityTypeConfiguration<DocIdentificacao>
{
    public void Configure(EntityTypeBuilder<DocIdentificacao> builder)
    {
        builder.ToTable("DocumentoIdentificacao", SchemaNames.DDDSample1);
        builder.HasKey(b => b.NrIdentificacao);
        builder.OwnsOne(b => b.LetrasDoc);
        builder.OwnsOne(b => b.CheckDigit);
        builder.OwnsOne(b => b.ValidadeDoc);
        builder.OwnsOne(b => b.NrUtente);
        builder.OwnsOne(b => b.Nif);
        
        builder
            .HasOne(e => e.Pessoa)
            .WithOne(j => j.DocIdentificacao)
            .HasForeignKey<Domain.Pessoa.Pessoa>(e=>e.NrIdentificacao);


        //builder.Property<bool>("_active").HasColumnName("Active");

        builder.Property(b => b.Id)
            .HasConversion(
                v => v.ToString(),
                v => new Identifier(Guid.Parse(v)));
        
        builder.Property(b => b.NrIdentificacao)
            .HasConversion(
                v => v.NumeroId,
                v => new NrIdentificacao(v.ToString()));
    }
}
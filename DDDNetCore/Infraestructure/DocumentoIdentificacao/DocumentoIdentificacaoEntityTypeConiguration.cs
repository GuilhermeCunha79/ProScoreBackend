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

        builder.Property(b => b.LetrasDoc)
            .HasConversion(
                v => v.LetrasDocumento,
                v => new LetrasDoc(v)).IsRequired();
        
        builder.Property(b => b.CheckDigit)
            .HasConversion(
                v => v.CheckDig,
                v => new CheckDigit(v.ToString())).IsRequired();
        
        builder.Property(b => b.ValidadeDoc)
            .HasConversion(
                v => v.Data,
                v => new ValidadeDoc(v)).IsRequired();
        
        builder.Property(b => b.NrUtente)
            .HasConversion(
                v => v.NumUtente,
                v => new NrUtente(v));
        
        builder.Property(b => b.Nif)
            .HasConversion(
                v => v.NumIdFis,
                v => new Nif(v));
        
        builder
            .HasOne(e => e.Pessoa)
            .WithOne(j => j.DocIdentificacao)
            .HasForeignKey<Domain.Pessoa.Pessoa>(e=>e.NrIdentificacao);


        //builder.Property<bool>("_active").HasColumnName("Active");


        builder.Property(b => b.NrIdentificacao)
            .HasConversion(
                v => v.NumeroId,
                v => new NrIdentificacao(v.ToString()));
    }
}
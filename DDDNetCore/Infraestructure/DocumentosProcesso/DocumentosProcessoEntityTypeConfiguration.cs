using ConsoleApp1.Domain.DocumentosProcesso;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.DocumentosProcesso;



internal class DocumentosProcessoEntityTypeConfiguration : IEntityTypeConfiguration<Domain.DocumentosProcesso.DocumentosProcesso>
{
    public void Configure(EntityTypeBuilder<Domain.DocumentosProcesso.DocumentosProcesso> builder)
    {
        builder.ToTable("DocumentosProcesso", SchemaNames.DDDSample1);
        builder.HasKey(b => b.Id);

        //builder.Property<bool>("_active").HasColumnName("Active");


        builder.Property(b => b.CapturaBoletim)
            .HasConversion(
                v => v.BoletimCaptura,
                v => new CapturaBoletim(v));

        builder.Property(b => b.CapturaDocIdentificacao)
            .HasConversion(
                v => v.DocIdentificacaoCaptura,
                v => new CapturaDocIdentificacao(v));

        

    }
}
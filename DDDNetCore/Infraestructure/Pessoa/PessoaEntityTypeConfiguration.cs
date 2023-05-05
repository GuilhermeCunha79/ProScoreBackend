using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.Genero;
using ConsoleApp1.Domain.Nacionalidade;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Pessoa;

internal class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Pessoa.Pessoa>
{
    public void Configure(EntityTypeBuilder<Domain.Pessoa.Pessoa> builder)
    {
        builder.ToTable("Pessoa", SchemaNames.DDDSample1);
        builder.HasKey(b => b.IdentificadorPessoa);
        builder.OwnsOne(b => b.Nome);
        builder.OwnsOne(b => b.DataNascimento);
        builder.OwnsOne(b => b.Telefone);
        builder.OwnsOne(b => b.Email);
        builder.OwnsOne(b => b.ConcelhoResidência);


        builder
            .HasOne(e => e.Jogador)
            .WithOne(j => j.Pessoa)
            .HasForeignKey<Domain.Jogador.Jogador>(e=>e.IdentificadorPessoa)
            .OnDelete(DeleteBehavior.Restrict);;
        

        //builder.Property<bool>("_active").HasColumnName("Active");

        builder.Property(b => b.Id)
            .HasConversion(
                v => v.ToString(),
                v => new Identifier(Guid.Parse(v)));
        
        builder.Property(b => b.NrIdentificacao)
            .HasConversion(
                v => v.NumeroId,
                v => new NrIdentificacao(v.ToString()));
        
        builder.Property(b => b.NacionalidadePais)
            .HasConversion(
                v => v.NacionalidadePaiss,
                v => new NacionalidadePais(v.ToString()));
        
        builder.Property(b => b.IdentificadorPessoa)
            .HasConversion(
                v => v.IdPessoa,
                v => new IdentificadorPessoa(v));
    }
}
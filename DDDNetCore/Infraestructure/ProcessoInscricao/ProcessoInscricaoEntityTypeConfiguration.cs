using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;
using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;
using ConsoleApp1.Domain.ProcessoInscricao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.ProcessoInscricao;


    internal class ProcessoInscricaoEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ProcessoInscricao.ProcessoInscricao>
    {
        public void Configure(EntityTypeBuilder<Domain.ProcessoInscricao.ProcessoInscricao> builder)
        {
            builder.ToTable("ProcessoInscricao", SchemaNames.DDDSample1);
            builder.HasKey(b => b.CodOperacao);
            builder.OwnsOne(b => b.TipoProcesso);
            builder.OwnsOne(b => b.Estado);
            builder.OwnsOne(b => b.EpocaDesportiva);
            builder.OwnsOne(b => b.DataRegisto);
            builder.OwnsOne(b => b.DataSubscricao);

            //builder.Property<bool>("_active").HasColumnName("Active");
        
            builder
                .HasOne(e => e.InscricaoDefinitivaAssociacaoEquipa)
                .WithOne(j => j.ProcessoInscricao)
                .HasForeignKey<Domain.InscricaoDefinitivaAssociacaoEquipa.InscricaoDefinitivaAssociacaoEquipa>(e=>e.CodOperacao);
            
            builder
                .HasOne(e => e.InscricaoDefinitivaAssociacaoJogador)
                .WithOne(j => j.ProcessoInscricao)
                .HasForeignKey<Domain.InscricaoDefinitivaAssociacaoJogador.InscricaoDefinitivaAssociacaoJogador>(e=>e.CodOperacao);
            
            builder
                .HasOne(e => e.InscricaoProvisoriaClubeEquipa)
                .WithOne(j => j.ProcessoInscricao)
                .HasForeignKey<Domain.InscricaoProvisoriaClubeEquipa.InscricaoProvisoriaClubeEquipa>(e=>e.CodOperacao);
            
            builder
                .HasOne(e => e.InscricaoProvisoriaClubeJogador)
                .WithOne(j => j.ProcessoInscricao)
                .HasForeignKey<Domain.InscricaoProvisoriaClubeJogador.InscricaoProvisoriaClubeJogador>(e=>e.CodOperacao);
            

            builder.Property(b => b.CodOperacao)
                .HasConversion(
                    v => v.CodOpe,
                    v => new CodOperacao(v.ToString()));
        }
    }
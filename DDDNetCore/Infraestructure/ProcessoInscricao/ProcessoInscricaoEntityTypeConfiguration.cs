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
          

            //builder.Property<bool>("_active").HasColumnName("Active");
            
            builder.Property(b => b.TipoProcesso)
                .HasConversion(
                    v => v.ProcessoTipo,
                    v => new TipoProcesso(v)).IsRequired();
            
            builder.Property(b => b.Estado)
                .HasConversion(
                    v => v.Status,
                    v => new Estado(v)).IsRequired();
            
            builder.Property(b => b.EpocaDesportiva)
                .HasConversion(
                    v => v.EpocaDesp,
                    v => new EpocaDesportiva()).IsRequired();
            
            builder.Property(b => b.DataRegisto)
                .HasConversion(
                    v => v.DataReg,
                    v => new DataRegisto()).IsRequired();
            
            builder.Property(b => b.DataSubscricao)
                .HasConversion(
                    v => v.DataSubs,
                    v => new DataSubscricao()).IsRequired();
        
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
            
            builder
                .HasOne(e => e.DocumentosProcesso)
                .WithOne(j => j.ProcessoInscricao)
                .HasForeignKey<Domain.DocumentosProcesso.DocumentosProcesso>(e=>e.CodOperacao);
            

            builder.Property(b => b.CodOperacao)
                .HasConversion(
                    v => v.CodOpe,
                    v => new CodOperacao(v.ToString()));
        }
    }
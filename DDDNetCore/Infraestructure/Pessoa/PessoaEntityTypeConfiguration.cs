﻿using ConsoleApp1.Domain.DocumentoIdentificacao;
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
        

        builder.Property(b => b.Nome)
            .HasConversion(
                v => v.Nomee,
                v => new Nome(v)).IsRequired();
        
        builder.Property(b => b.DataNascimento)
            .HasConversion(
                v => v.DataNasc,
                v => new DataNascimento(v)).IsRequired();
        
        builder.Property(b => b.Telefone)
            .HasConversion(
                v => v.Telemovel,
                v => new Telefone(v)).IsRequired();
        
        builder.Property(b => b.Email)
            .HasConversion(
                v => v.Emaill,
                v => new Email(v)).IsRequired();
        
        builder.Property(b => b.ConcelhoResidência)
            .HasConversion(
                v => v.Concelho,
                v => new ConcelhoResidência(v)).IsRequired();
        
        
        builder
            .HasOne(e => e.Jogador)
            .WithOne(j => j.Pessoa)
            .HasForeignKey<Domain.Jogador.Jogador>(e=>e.IdentificadorPessoa)
            .OnDelete(DeleteBehavior.Restrict);;
        

        //builder.Property<bool>("_active").HasColumnName("Active");
        
        
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
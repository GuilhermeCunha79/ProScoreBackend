using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Infraestructure.Jogador;


    internal class JogadorEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Forms.Jogador>
    {
        public void Configure(EntityTypeBuilder<Domain.Forms.Jogador> builder)
        {
            //builder.ToTable("Jogadores", SchemaNames.DDDSample1);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.Licenca);
            builder.OwnsOne(b => b.IdentificadorEquipa);
            builder.OwnsOne(b => b.EstatutoFpF);
            builder.OwnsOne(b => b.IdentificadorPessoa);
            //builder.Property<bool>("_active").HasColumnName("Active");
        }

        
    }

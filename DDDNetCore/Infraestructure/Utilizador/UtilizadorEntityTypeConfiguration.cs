using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Domain.Utilizador;


internal class UtilizadorEntityTypeConfiguration : IEntityTypeConfiguration<Utilizador>
{
    public void Configure(EntityTypeBuilder<Utilizador> builder)
    {
        builder.ToTable("Utilizador", SchemaNames.DDDSample1);
        builder.HasKey(b => b.EmailUtilizador);

        //builder.Property<bool>("_active").HasColumnName("Active");
        

        builder.Property(b => b.Password)
            .HasConversion(
                v => v.Pass,
                v => new Password(v.ToString()));
        
        builder.Property(b => b.Role)
            .HasConversion(
                v => v.RoleId,
                v => new Role(v));
        
        builder.Property(b => b.EmailUtilizador)
            .HasConversion(
                v => v.Email,
                v => new EmailUtilizador(v));
       
    }
}
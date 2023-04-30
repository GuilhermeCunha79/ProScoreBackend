using ConsoleApp1.Domain.Forms;
using ConsoleApp1.Infraestructure.Jogador;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure;

public class DDDSample1DbContext : DbContext
{
    public DbSet<Domain.Forms.Jogador> Jogadores { get; set; }
    

    public DDDSample1DbContext(DbContextOptions options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer(
    //         @"jdbc:mysql://vs285.dei.isep.ipp.pt:3306/");
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JogadorEntityTypeConfiguration());
      
    }
}
using System.ComponentModel.DataAnnotations;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Domain.Categoria;

public class Categoria: Entity<Identifier>
{
    public TipoCategoria TipoCategoria { get; set; }
    public ICollection<Equipa.Equipa> Equipas { get; set; }
    public Categoria()
    {
        
    }
    public Categoria(string categoria)
    {
        TipoCategoria = new TipoCategoria(categoria);
    }
}
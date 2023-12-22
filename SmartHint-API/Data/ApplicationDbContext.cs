// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using SmartHint_API.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Itens { get; set; }
    public DbSet<Cliente> Clientes{ get; set; }
}
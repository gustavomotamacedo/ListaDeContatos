using ListaContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaContatos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<FilmeModel> Filmes { get; set; }
    }
}

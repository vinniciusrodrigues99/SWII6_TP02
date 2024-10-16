using Microsoft.EntityFrameworkCore;
using TP01_WII6.Models;

namespace TP01_WII6.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
           .HasMany(b => b.Authors)
           .WithMany(a => a.Books) // Configurando o relacionamento bidirecional
           .UsingEntity<Dictionary<string, object>>(
               "BookAuthor",
               j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
               j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"));

        }
    }
}

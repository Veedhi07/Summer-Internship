using BooksApi.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Entities.Context
{
    public class BookDbContext(DbContextOptions<BookDbContext> options) : DbContext(options)
    {
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            id = 1,
                Name = "admin",
                Email = "admin@tatvasoft.com",
                Role = "admin"
                Password = "admin"
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }

}

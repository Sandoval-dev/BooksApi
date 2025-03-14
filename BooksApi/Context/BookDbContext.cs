using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Context
{
    public class BookDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ERDEM\\SQLEXPRESS; database=BookApi; Integrated Security=True; TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }
    }
}

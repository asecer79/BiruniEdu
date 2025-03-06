using Microsoft.EntityFrameworkCore;
using Week5.Models.Entities;

namespace Week5.Data
{
    public class MyDatabaseContext:DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost;database = MyDatabase;Trusted_Connection=True;Encrypt=true; TrustServerCertificate=True");
        //}
    }
}

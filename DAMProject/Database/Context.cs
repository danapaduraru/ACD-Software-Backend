using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class Context: DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1PE5EKU\SQLEXPRESS;Initial Catalog=DAMProject; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //asdasd
        }
    }
}

using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class Context: DbContext
    {
        public DbSet<TestToQuestions> TestToQuestions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1PE5EKU\SQLEXPRESS;Initial Catalog=DAMProject; Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DAM; Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RG20533\SQLEXPRESS;Initial Catalog=dam; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new branch
            //test pull request
            //modified
        }
    }
}

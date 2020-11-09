using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class Context: DbContext
    {
        //Relations
        public DbSet<TestToQuestions> TestToQuestions { get; set; }

        //Main entities
        public DbSet<Person> Persons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }




        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DAM; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new branch
            //test pull request
            //modified
        }
    }
}

﻿using Entities;
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
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DAM; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new branch
            //test pull request
        }
    }
}